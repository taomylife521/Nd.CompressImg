using Nd.CompressImg.handler;
using Nd.CompressImg.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nd.CompressImg.publisher
{
   
     public class HandleForImgController2
     {
       
        
         //private  HandlerForImg handler = null;
         private  CancellationTokenSource importCts =new CancellationTokenSource();
         private Task[] tasks = null;
         public event EventHandler<EventMessage> onProcessCompleteHandler;

        // public event EventHandler<EventMessage> onWorklingMsg;
         
        
        public HandleForImgController2(int taskCount)
        {
           // handler = _handler;
            tasks = new Task[taskCount];
          
            
        }

        
        /// <summary>
        /// 开启线程
        /// </summary>
        /// <param name="_timeSpan">线程休息时间</param>
        /// <param name="path">文件夹路径</param>
        /// <param name="minCount">要处理最小的文件夹名称</param>
        /// <param name="maxCount">要处理最大的文件夹名称</param>
        public  void StartWork(int _timeSpan,int minIndex,int maxIndex,string[] fileName,string outPutPath,int taskIndex)
        {
            //tasks[taskIndex] = Task.Factory.StartNew((x) =>
            //{
            //    EventMessage eventmsg = null;
            //    HandlerForImg handler = new HandlerForImg();
            //    if (!importCts.IsCancellationRequested)
            //    {
            //       eventmsg= handler.DoWork(this, minIndex, maxIndex, fileName,outPutPath, this.tasks[taskIndex].Id.ToString());
            //       //handler.onWorklingMsg += (obj, arg) =>
            //       //{
            //       //    onWorklingMsg(this, arg);
            //       //};
            //       onProcessCompleteHandler(this, eventmsg);
            //       Thread.Sleep(_timeSpan);
            //    }
            //    else
            //    {
            //        eventmsg = new EventMessage { taskId = this.tasks[taskIndex].Id.ToString(), msg = "线程被终止", failCount = eventmsg == null ? "0" : eventmsg.failCount, sucessCount = eventmsg.sucessCount == null ? "0" : eventmsg.sucessCount, totalTime = eventmsg.totalTime == null ? "0" : eventmsg.totalTime };
            //        onProcessCompleteHandler(this, eventmsg);
            //    }
            //}, importCts.Token);//,importCts

            
        }

        public void StopWork()
        {
            importCts.Cancel();
        }

     }
}
