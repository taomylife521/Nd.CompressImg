using Nd.CompressImg.Controller;
using Nd.CompressImg.handler;
using Nd.CompressImg.logcontext;
using Nd.CompressImg.model;
using Nd.CompressImg.publisher;
using Nd.CompressImg.untility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nd.CompressImg.extention;

namespace Nd.CompressImg
{
       
    public partial class Form1 : Form
    {
        HandleForImgController handlerController = null;//线程控制类
        HandlerForImg _handler = null;//真正用于处理的类

        Action<EventMessage> showMsg = null;  //封装一个用于向LISTBOX控件显示信息的方法

        Action<EventMessage> showResult = null;  //封装一个用于显示最终结果的方法
        Action<EventMessage> showTime = null;
        Stopwatch st = new Stopwatch();
        private List<string> directoryList =null;
        private int allFolderCount = 0;
        private static Dictionary<string, List<string>> allFileList = null;

        //event EventHandler<EventMessage> onListBoxItemAdded;
       
      
        public Form1()
        {
            InitializeComponent();
            _handler = new HandlerForImg();
           // handlerController = new HandleForImgController(_handler, 1);
            handlerController = new HandleForImgController();
            for(int i = 1;i<101;i++)
            {
                cmbQuality.Items.Add(i.ToString());
               
            }
            cmbQuality.SelectedIndex = 59;
        }

      
        #region 打开处理路径

        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog openFolder = new FolderBrowserDialog();
                if (openFolder.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = openFolder.SelectedPath.ToString();

                    allFileList = Task<Dictionary<string, List<string>>>.Factory.StartNew(() =>
                                { return GetAllDirectory(txtPath.Text, this.ChbIsSubFolder.Checked); }).Result;
                    directoryList = allFileList.ContainsKey(".img")==true?allFileList[".img"]:null;//GetDirectory(txtPath.Text, this.ChbIsSubFolder.Checked);
                    int sumFile = 0;
                    this.lstDetail.Items.Clear();
                    string fileExtention = "";
                    foreach (KeyValuePair<string, List<string>> item in allFileList)
                    {
                        fileExtention = item.Key == "" ? "未知类型" : item.Key;
                        lstDetail.Items.Add("文件类型:" + fileExtention + ",数量:" + item.Value.Count);
                        sumFile += item.Value.Count;
                    }
                    lstDetail.Items.Add("文件总数量:" + sumFile.ToString());
                }
                InitData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("异常消息:" + ex.Message + "\r\n堆栈跟踪:" + ex.StackTrace);
            }
        } 
        #endregion

        #region 初始化数据
        public void InitData()
        {
            DisEnabledTask();
         string dealPath = this.txtPath.Text;
            if (dealPath != "")
            {
                int folderCount = Directory.GetDirectories(dealPath).Length;
                int fileCount = Directory.GetFiles(dealPath).Length;
                if (directoryList != null)
                {
                    this.lbFileCount.Text = "图片数量:" + directoryList.Count.ToString();
                }
                else
                {
                    this.lbFileCount.Text = "图片数量:0";
                }
                this.lbFolderCount.Text = "文件夹数量:" + allFolderCount.ToString();
                
            }
           this.lbDealPath.Text ="处理路径:"+ this.txtPath.Text;
           this.lbOutPath.Text ="输出路径:"+ this.txtOutPath.Text;
        }
        #endregion

        #region 开启线程
        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            #region 旧代码
            // EnabledTask();
            // string path = txtPath.Text;
            // string outPutPath = txtOutPath.Text;
            // if (path.Length <= 0)
            // {
            //     MessageBox.Show("处理路径不能为空");
            //     DisEnabledTask();
            //     return;
            // }
            // else if (!Directory.Exists(path))
            // {
            //     MessageBox.Show("处理路径不存在");
            //     DisEnabledTask();
            //     return;
            // }
            // outPutPath = outPutPath.Length <= 0 ? @"c:\pic" : outPutPath;//设置默认输出路径
            // path = path.Length <= 0 ? @"E:\上传图片\pic" : path;//设置默认处理路径
            // int leastCount = txtLeastCount.Text.Length <= 0 ? 2 : Convert.ToInt32(txtLeastCount.Text);//每个线程至少处理数量
            // int taskCount =txtTaskCount.Text.Length <= 0 ? 2:Convert.ToInt32(txtTaskCount.Text);//默认开始线程数量

            // int timespan = System.Configuration.ConfigurationManager.AppSettings["timespan"] == null ? 1 : int.Parse(System.Configuration.ConfigurationManager.AppSettings["timespan"]);
            // string[] diArr = Directory.GetDirectories(path);//获取一共要处理的文件夹

            // #region 自动优化处理数量和开启线程数量
            // int dealCount = 0;
            // int extraCount = 0;
            // if (diArr.Length <= leastCount)//小于等于每个线程要至少处理的数量
            // {
            //     taskCount = 1;
            //     leastCount = diArr.Length;
            //     //重置自定义的选择线程数量
            // }
            // else
            // {
            //      dealCount = diArr.Length / taskCount;//每个线程需要处理的数量
            //      extraCount = diArr.Length % taskCount;//给每个线程分配完后剩余的数量
            //     if (dealCount < leastCount)//控制每个线程至少处理leastCount个以上的文件夹,如果小于leastCount则重新计算要开启的线程数量
            //     {
            //         taskCount = diArr.Length / leastCount + diArr.Length % leastCount == 0 ? 0 : diArr.Length % leastCount;
            //     }
            //     else//如果处理的数量超过至少要处理的数量
            //     {
            //         leastCount = dealCount;
            //     }
            // } 
            // #endregion

            //// handlerController = new HandleForImgController(_handler, taskCount);
            // handlerController = new HandleForImgController(taskCount);

            //     int minIndex = 0;
            //     int maxIndex = 0;
            //     for (int i = 0; i < taskCount; i++)//开启多线程，为每个线程分配处理数量
            //     {
            //         minIndex = i==0 ? 0:i*leastCount;
            //         maxIndex =i == taskCount - 1 ? (i + 1) * leastCount-1 +extraCount : ((i + 1) * leastCount) - 1;//  
            //         //0 n-1
            //         // n 2n-1
            //         //2n 3n-1
            //         handlerController.StartWork(timespan, minIndex, maxIndex, diArr, outPutPath,i);
            //     }

            //     this.txtLeastCount.Text = leastCount.ToString();
            //     this.txtTaskCount.Text = taskCount.ToString();
            //     lbForTaskCount.Text ="开启线程数量:"+ taskCount.ToString();
            //     lbForSleepTime.Text = "线程处理频率:" + this.cmbSleepTime.SelectedItem.ToString(); 
            #endregion

            try
            {
                string inPath = txtPath.Text.ToString();
                if (inPath == "" || !Directory.Exists(inPath))
                {
                    MessageBox.Show("处理路径不能为空或不存在");
                    return;
                }

                string outPath = txtOutPath.Text.ToString();
                if (outPath == "" || !Directory.Exists(outPath))
                {
                    MessageBox.Show("输出路径不能为空或不存在");
                    return;
                }
                int r;
                bool r2 = int.TryParse(this.txtLeastCount.Text, out r);
                if (!r2)
                {
                    MessageBox.Show("线程至少处理数量格式不对");
                    return;
                }
                if (lbFileCount.Text == "图片数量:0")
                {
                    MessageBox.Show("当前处理路径下无任何图片");
                    return;
                }
                if (txtCompressHeight.Text == "")
                {
                    MessageBox.Show("当前处理路径下无任何图片");
                    return;
                }
                int dHeight = Convert.ToInt32(txtCompressHeight.Text);
                int dWidth = Convert.ToInt32(txtCompressWidth.Text);

                if (dHeight > 0)
                {
                    if (dWidth <= 0)
                    {
                        MessageBox.Show("压缩宽高指定错误！");
                        return;
                    }
                }
                if (dWidth > 0)
                {
                    if (dHeight <= 0)
                    {
                        MessageBox.Show("压缩宽高指定错误！");
                        return;
                    }
                }
                allFileList = Task<Dictionary<string, List<string>>>.Factory.StartNew(() =>
                { return GetAllDirectory(txtPath.Text, this.ChbIsSubFolder.Checked); }).Result;
               int quality = Convert.ToInt32(this.cmbQuality.SelectedItem);
                int dealCount = Convert.ToInt32(r) <= 0 ? 50 : Convert.ToInt32(r);
                int maxTaskCount = Convert.ToInt32(this.txtMaxTask.Text) <= 0 ? 10 : Convert.ToInt32(this.txtMaxTask.Text);
                EnabledTask();

                Reset();
                this.timer1.Start();//开启计时器

                handlerController.StartWork(allFileList[".img"], allFileList, txtPath.Text.ToString(), txtOutPath.Text, dealCount,dHeight,dWidth,quality, maxTaskCount, this.chbCopyOtherFile.Checked);//开启多线程
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误消息:" + ex.Message + "\r\n" + "堆栈：" + ex.StackTrace);
            }

        } 
        #endregion


        #region 重置
        public void Reset()
        {
            this.lbTime.Text = "0";
            this.lsbResult.Items.Clear();
            this.lstLog.Items.Clear();
            this.lbDealing.Text = "";
        }
        #endregion
        public void theout(object source,System.Timers.ElapsedEventArgs e)
        {
            this.lbTime.Text = "已用时:" + e.SignalTime;
        }

        #region 开始
       public void EnabledTask()
        {
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
        }

     
       public void DisEnabledTask()
       {
           this.btnStart.Enabled = true;
           this.btnStop.Enabled = false;
       }
        #endregion

        #region 窗体载入
        private void Form1_Load(object sender, EventArgs e)
        {
          
            showMsg = new Action<EventMessage>((txt) =>
            {
                if (this.lstLog.Items.Count >= 34) this.lstLog.Items.Remove(this.lstLog.Items[0]);
                this.lstLog.Items.Add( txt.msg);
                lbDealing.Text =  txt.msg;
            });
            showResult = new Action<EventMessage>((txt) =>
            {
                if (this.lsbResult.Items.Count >= 300) this.lsbResult.Items.Remove(this.lsbResult.Items[0]);
                lsbResult.Items.Add(DateTime.Now.ToString() +":"+ txt.msg); 
            });

            showTime = new Action<EventMessage>((txt) =>
            {
                this.timer1.Stop();
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = true;
                lsbResult.Items.Add(DateTime.Now.ToString() +":"+ txt.msg);
            });
           
           HandleForImgController.onProcessingHandler += (obj, arg) =>
           {
               this.Invoke(showMsg, arg); 
           };
           HandleForImgController.onProcessCompleteHandler += (obj, arg) =>
           {
               this.Invoke(showResult, arg);
           };

           HandleForImgController.onAllTaskCompleteHandler += (obj, arg) =>
           {
               this.Invoke(showTime, arg);
           };
           //LogContext log = new LogContext();
           //this.onListBoxItemAdded += (obj, arg) =>
           //{
           //    try
           //    {
           //        string path = System.IO.Directory.GetCurrentDirectory();
           //        DateTime CurrTime = DateTime.Now;
           //        string strPath = path + "\\HandDataLog\\" + CurrTime.Year + "-" + CurrTime.Month + "\\" + CurrTime.Day + ".txt";
           //        //log.AddLogInfo(strPath,arg.taskId+arg.msg, true);
           //    }
           //    catch { }
           //};
        }
        #endregion

        #region 停止工作
        private void btnStop_Click(object sender, EventArgs e)
        {
            handlerController.StopWork();
            DisEnabledTask();
        } 
        #endregion

        #region 打开输出路径
        private void btnOutPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
               txtOutPath.Text=openFolder.SelectedPath.ToString();
            }
            InitData();
        } 
        #endregion

       

     

      

        /// <summary>
        /// 获取或设置控件的值，根据控件的Id与字典的key匹配值
        /// </summary>
        /// <param name="controlCollection">控件集合</param>
        /// <param name="dic">字典集合</param>
        private static List<string> GetDirectory(string directoryPath,bool isGetSubFolder =true)
        {
           
          List<string> directoryList = new List<string>();
          
            Directory.GetFiles(directoryPath).ToList().ForEach(x =>//先添加当前目录下的所有文件
            {

                directoryList.TryAddImgFile(x);
                 
                
            });
           if(!isGetSubFolder)
           {
               return directoryList;
           }
            var directsName = Directory.GetDirectories(directoryPath);
            foreach (string directName in directsName)
            {
                if(File.Exists(directName))
                {
                    directoryList.TryAddImgFile(directName);     
                }
               else if (Directory.Exists(directName))
                {
                    string[] filesNameChilds = Directory.GetDirectories(directName);
                    if (filesNameChilds != null && filesNameChilds.Count() > 0)
                    {
                        filesNameChilds.ToList().ForEach(x => GetDirectory(x));
                        //GetDirectory(directName);
                    }
                    else
                    {
                        Directory.GetFiles(directName).ToList().ForEach(x=>{

                            directoryList.TryAddImgFile(x);
                            
                        });
                    }
                }
              
               
            }
            return directoryList;
        }


        /// <summary>
        /// 获取或设置控件的值，根据控件的Id与字典的key匹配值
        /// </summary>
        /// <param name="controlCollection">控件集合</param>
        /// <param name="dic">字典集合</param>
        private  Dictionary<string,List<string>>  GetAllDirectory(string directoryPath, bool isGetSubFolder = true)
        {
        
                Dictionary<string, List<string>> directoryList = new Dictionary<string, List<string>>();
                Directory.GetFiles(directoryPath).ToList().ForEach(x =>//先添加当前目录下的所有文件
                {
                    directoryList.AddFile(x);
                });
                if (!isGetSubFolder)
                {
                    return directoryList;
                }
                var directsName = Directory.GetDirectories(directoryPath);
                allFolderCount += directsName.Length;
                foreach (string item in directsName)
                {
                    Dictionary<string, List<string>> dic = GetAllDirectory(item, isGetSubFolder);

                    dic.ToList().ForEach(x =>
                    {
                        directoryList.TryAdd(x.Key, x.Value);
                    });


                }
                return directoryList;
         
     

           
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            int r =Convert.ToInt32(this.lbTime.Text.ToString());
            this.lbTime.Text = (++r).ToString();
        }

        private void ChbIsSubFolder_CheckedChanged(object sender, EventArgs e)
        {
            directoryList = GetDirectory(txtPath.Text, this.ChbIsSubFolder.Checked);
            InitData();
        }

      
    }


}
