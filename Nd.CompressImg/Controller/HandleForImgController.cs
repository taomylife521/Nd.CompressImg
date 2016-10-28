using Nd.CompressImg.handler;
using Nd.CompressImg.logcontext;
using Nd.CompressImg.model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nd.CompressImg.Controller
{
    public class HandleForImgController
    {
        ConcurrentBag<Task<DealResult>> tasks = new ConcurrentBag<Task<DealResult>>();
        CancellationTokenSource importCts = new CancellationTokenSource();//是否取消
        public static event EventHandler<EventMessage> onProcessingHandler;//处理中的事件
        public static event EventHandler<EventMessage> onProcessCompleteHandler;//处理完成后的事件

        public static event EventHandler<EventMessage> onAllTaskCompleteHandler;//处理所有任务完成后的事件
        /// <summary>
        /// 开启多线程
        /// </summary>
        /// <param name="dealDataCollection">要处理的数据集合</param>
        /// <param name="singleDealCount">单次处理数据量</param>
        /// <param name="maxTaskCount">最大开启的线程数</param>
        public void StartWork(List<string> dealDataCollection,Dictionary<string,List<string>> dicAllFile,string InPuth,string outPutPath,int singleDealCount,int dHeight=0,int dWidth = 0,int quality=60,int maxTaskCount = 10,bool isCopyOtherFile=true)
        {
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();
                DealResult dResult = new DealResult();
                if (isCopyOtherFile)
                {
                    onProcessCompleteHandler(this, new EventMessage { msg = "开始复制其它文件..." });
                    //专门复制其他文件的线程
                    Task<DealResult>.Factory.StartNew(() =>
                    {
                        string tempPath = "";
                        string tempDic = "";
                        int sumCount = 0;
                        Stopwatch st2 = new Stopwatch();
                        DealResult dResult2 = new DealResult();
                        st.Start();
                        foreach (KeyValuePair<string, List<string>> item in dicAllFile)
                        {
                            if (item.Key != ".img")
                            {
                                item.Value.ForEach(x =>
                                {
                                    tempPath = x;
                                    tempDic = Path.GetDirectoryName(x.Replace(InPuth, outPutPath));
                                    if (!Directory.Exists(tempDic))
                                    {
                                        Directory.CreateDirectory(tempDic);
                                    }
                                    File.Copy(tempPath, x.Replace(InPuth, outPutPath));
                                    sumCount++;
                                });
                            }
                        }
                        st2.Stop();
                        dResult2.sucessCount = sumCount;
                        dResult2.failCount = 0;
                        dResult2.totalTime = st2.ElapsedMilliseconds / 1000;
                        return dResult2;

                    }, importCts.Token).ContinueWith(task =>
                    {
                        onProcessCompleteHandler(this, new EventMessage { msg = "其它文件全部复制完毕！" });
                    }, importCts.Token);
                }


                //开启管理Task
                Task.Factory.StartNew(() =>
                {
                    int currentTaskCount = 0;
                    DealResult dresult = new DealResult();
                    while (dealDataCollection.Count > 0 && !importCts.Token.IsCancellationRequested)
                    {
                        
                        while (currentTaskCount >= maxTaskCount)
                        {

                          int index=  Task.WaitAny(tasks.ToArray());//等待任何一个task完成 
                        // Task<DealResult> task = tasks[index] as Task<DealResult>;
                          onProcessCompleteHandler(this, new EventMessage { msg = "线程" + tasks.ToArray()[index].Id.ToString() + "处理完成,成功数量:" + tasks.ToArray()[index].Result.sucessCount.ToString() + ",失败数量:" + tasks.ToArray()[index].Result.failCount.ToString() + ",耗时:" + tasks.ToArray()[index].Result.totalTime.ToString() + "" });
                          currentTaskCount--;
                           
                        }
                       // Thread.Sleep(50);
                       
                        List<string> childData = dealDataCollection.Take(singleDealCount).ToList();
                      
                        if (childData.Count > 0)
                        {
                            dealDataCollection.RemoveRange(0, childData.Count);
                            Task<DealResult> subTask = Task<DealResult>.Factory.StartNew(() =>
                            {
                                
                                return DoSomeWork(childData, importCts.Token, outPutPath, InPuth,dHeight,dWidth,quality);
                            }, importCts.Token);
                            //dResult.failCount += subTask.Result.failCount;
                            //dResult.sucessCount += subTask.Result.sucessCount;
                            //dResult.totalTime += subTask.Result.totalTime;
                            // onProcessCompleteHandler(this, new EventMessage { msg = "线程" + subTask.Id.ToString() + "处理完成,成功数量:" + subTask.Result.sucessCount.ToString() + ",失败数量:" + subTask.Result.failCount.ToString() + ",耗时:" + subTask.Result.totalTime.ToString() + "" });
                         
                            currentTaskCount++;
                            tasks.Add(subTask);
                        }
                        else //如果分配完毕currentTaskCount<maxTaskCount,则让maxTaskCount=currentTaskCount
                        {
                           
                            showMsg(this, new EventMessage { msg = "全部分配完毕" });
                        }
                    }
                   
                    if(dealDataCollection.Count <= 0)
                    {
                        onAllTaskCompleteHandler(this, new EventMessage { msg = "任务全部分配完毕，共开启线程数量:"+tasks.Count.ToString() });
                    }
                }, importCts.Token).ContinueWith(task =>
                {
                  
                    //showMsg(this, new EventMessage { msg = "" });
                    Task.WaitAll(tasks.ToArray());//防止管理线程分配完毕，子线程还没有处理完毕
                    st.Stop();
                    tasks.ToList().ForEach(x =>
                    {
                        
                        dResult.failCount += x.Result.failCount;
                        dResult.sucessCount += x.Result.sucessCount;
                    });
                    if(!importCts.Token.IsCancellationRequested)
                    {
                        onAllTaskCompleteHandler(this, new EventMessage { msg = "全部处理完毕" });
                    }
                   
                    onProcessCompleteHandler(this, new EventMessage { msg = "成功数量:" + dResult.sucessCount.ToString() + ",失败数量:" + dResult.failCount.ToString() + ",耗时:" + (st.ElapsedMilliseconds/1000).ToString() + "" });
                });
            }
            catch(Exception ex)
            {

            }
        }

        public void StopWork()
        {
            importCts.Cancel();
        }
        private DealResult DoSomeWork(List<string> srcColletion, CancellationToken token, string outPutPath,string InPath,int dHeight,int dWidth,int flag)
        {
            string errMsg = "";
            LogContext log = new LogContext();
            string path = System.IO.Directory.GetCurrentDirectory();
            DateTime CurrTime = DateTime.Now;
            DealResult res = new DealResult();
            string strPath = path + "\\HandDataLog\\" + CurrTime.Year + "-" + CurrTime.Month + "\\" + CurrTime.Day + ".txt";
            Stopwatch st = new Stopwatch();
            st.Start();
            string diFile = "";
            foreach (string siFile in srcColletion)
            {
               // FileInfo fi = new FileInfo(siFile);
               diFile= siFile.Replace(InPath, outPutPath);
              if(!Directory.Exists(Path.GetDirectoryName(diFile)))
              {
                  Directory.CreateDirectory(Path.GetDirectoryName(diFile));
              }
              
                if (token.IsCancellationRequested)
                {
                    showMsg(this, new EventMessage { msg = "线程"+Task.CurrentId+"任务已经取消！" });//"线程"+id.ToString()+
                    onAllTaskCompleteHandler(this, new EventMessage { msg = "线程" + Thread.CurrentThread.ManagedThreadId + "任务被终止！" });//"线程"+id.ToString()+
                    break;
                }
                bool r = HandlerForImg.GetPicThumbnail(siFile, diFile, ref errMsg,dHeight,dWidth,flag);
                if(!r)
                {
                    res.failCount += 1;
                    showMsg(this, new EventMessage { msg = "压缩不成功,路径名：" + siFile + "错误信息:" + errMsg });
                    log.AddLogInfo(strPath, "压缩不成功,路径名：" + siFile + "错误信息:" + errMsg, true);
                }
                showMsg(this, new EventMessage { msg = "压缩成功,输出路径：" + diFile });
                //log.AddLogInfo(strPath, "压缩成功,输出路径：" + diFile, true);
                res.sucessCount += 1;
            }
            st.Stop();
            res.totalTime += st.ElapsedMilliseconds / 1000;
            //Thread.Sleep(1000);
            return res;
        }

        private void showMsg(object sender,EventMessage eventMsg)
        {
            onProcessingHandler(sender, eventMsg);
        }
    }
}
