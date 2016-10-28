using Nd.CompressImg.logcontext;
using Nd.CompressImg.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.CompressImg.handler
{
   public class HandlerForImg
    {
       // public event EventHandler<EventMessage> onWorklingMsg;

       //// public event EventHandler onProgressChange;

       // /// <summary>
       // /// 发送消息
       // /// </summary>
       // /// <param name="_msg">消息内容</param>
       // private void ShowMsgToForm(EventMessage eventMsg)
       // {
       //     onWorklingMsg(this, eventMsg);
       // }

       ///// <summary>
       ///// 处理文件夹下的图片
       ///// </summary>
       ///// <param name="sender"></param>
       ///// <param name="path"></param>
       ///// <param name="minCount"></param>
       ///// <param name="maxCount"></param>
       // public EventMessage DoWork(object sender, int minIndex, int maxIndex, string[] fileName, string outPutPath, string taskId)
       //{
          
       //    string siPath = "";//要处理的源文件夹路径
       //    string siFile = "";//要处理的源文件
       //    string diPath = "";//要放置的目录
       //    string diFile = "";//要放置的目的文件
       //    string errMsg = "";//记录压缩错误信息
       //    int sucessCount = 0;//成功数量
       //    int failCount = 0;//失败数量
       //    Stopwatch st = new Stopwatch();
       //    LogContext log = new LogContext();
       //    string path = System.IO.Directory.GetCurrentDirectory();

       //    DateTime CurrTime = DateTime.Now;
       //    string strPath = path + "\\HandDataLog\\" + CurrTime.Year + "-" + CurrTime.Month + "\\" + CurrTime.Day + ".txt";
       //    st.Start();
       //    for (int i = minIndex; i < maxIndex; i++)
       //    {
       //        siPath = fileName[i];//要处理的最小文件夹路径
       //        DirectoryInfo si = new DirectoryInfo(siPath);
       //        if (Directory.Exists(siPath))//判断原路径是否存在，如果存在则处理
       //         {
       //             diPath = TryCreateOutPutPath(Path.Combine(outPutPath, si.Name));
       //           DirectoryInfo di = new DirectoryInfo(siPath);//获取原路径下的所有文件
       //            FileInfo[] fiArr = di.GetFiles();
       //            #region 循环遍历进行处理
       //            for (int j = 0; j < fiArr.Length; j++)
       //            {
       //                siFile = fiArr[j].FullName; //Path.Combine(siPath, fiArr[j].ToString());
       //                diFile = Path.Combine(diPath, fiArr[j].Name);
       //                if (diFile != "")
       //                {
       //                    bool r = GetPicThumbnail(siFile, diFile, ref errMsg);//压缩
       //                    if (!r)
       //                    {
       //                        failCount++;
       //                        //压缩不成功,要进行记录日志，并输出控制台
       //                        ShowMsgToForm(
       //                            new EventMessage
       //                            {
       //                                msg = "压缩不成功,路径名：" + siFile + "线程id:" + taskId + "错误信息:" + errMsg,
       //                                taskId = taskId,
       //                                failCount = failCount.ToString(),
       //                                sucessCount = sucessCount.ToString(),
       //                                totalTime = st.ElapsedMilliseconds.ToString()
       //                            }
       //                            );

       //                        log.AddLogInfo(strPath, "压缩不成功,路径名：" + siFile + "线程id:" + taskId + "错误信息:" + errMsg, true);
       //                    }
       //                    sucessCount++;
       //                    ShowMsgToForm(new EventMessage
       //                    {
       //                        msg = "压缩成功,输出路径：" + diFile,
       //                        taskId = taskId,
       //                        failCount = failCount.ToString(),
       //                        sucessCount = sucessCount.ToString(),
       //                        totalTime = st.ElapsedMilliseconds.ToString()
       //                    });

       //                }
       //            } 
       //            #endregion
       //         }
       //    }
       //    st.Stop();
       //    EventMessage eventMsg = new EventMessage
       //        {
       //            msg = "压缩完毕",
       //            taskId = taskId,
       //            failCount = failCount.ToString(),
       //            sucessCount = sucessCount.ToString(),
       //            totalTime = st.ElapsedMilliseconds.ToString()
       //        };
       //    ShowMsgToForm(eventMsg);
       //    return eventMsg;


       //}

       #region 尝试创建输出路径
       /// <summary>
       /// 尝试创建输出路径
       /// </summary>
       /// <param name="outPutPath"></param>
       /// <returns></returns>
       public string TryCreateOutPutPath(string outPutPath)
       {
           try
           {
               if (!Directory.Exists(outPutPath))
               {
                   outPutPath = Directory.CreateDirectory(outPutPath).FullName;
               }

               return outPutPath;
           }
           catch (Exception ex)
           {
               return "";
           }
       } 
       #endregion

       #region GetPicThumbnail
       /// <summary>
       /// 无损压缩图片
       /// </summary>
       /// <param name="sFile">原图片</param>
       /// <param name="dFile">压缩后保存位置</param>
       /// <param name="dHeight">高度</param>
       /// <param name="dWidth"></param>
       /// <param name="flag">压缩质量 1-100</param>
       /// <returns></returns>

       public static bool GetPicThumbnail(string sFile, string dFile, ref string errMsg,int dHeight=0, int dWidth=0, int flag=60)
       {
           System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);

           ImageFormat tFormat = iSource.RawFormat;

           int sW = 0, sH = 0;

           //按比例缩放
           
           Size tem_size = new Size(iSource.Width, iSource.Height);
           dHeight = dHeight == 0 ? tem_size.Height : dHeight;
           dWidth = dWidth == 0 ? tem_size.Width : dWidth;
           if (tem_size.Width > dHeight || tem_size.Width > dWidth) //将**改成c#中的或者操作符号
           {

               if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
               {
                   sW = dWidth;
                   sH = (dWidth * tem_size.Height) / tem_size.Width;
               }

               else
               {
                   sH = dHeight;
                   sW = (tem_size.Width * dHeight) / tem_size.Height;
               }

           }

           else
           {
               sW = tem_size.Width;
               sH = tem_size.Height;

           }
           
           Bitmap ob = new Bitmap(dWidth, dHeight);
           Graphics g = Graphics.FromImage(ob);
           g.Clear(Color.WhiteSmoke);
           g.CompositingQuality = CompositingQuality.HighQuality;
           g.SmoothingMode = SmoothingMode.HighQuality;
           g.InterpolationMode = InterpolationMode.HighQualityBicubic;
           g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
           g.Dispose();
           //以下代码为保存图片时，设置压缩质量
           EncoderParameters ep = new EncoderParameters();
           long[] qy = new long[1];
           qy[0] = flag;//设置压缩的比例1-100
           EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
           ep.Param[0] = eParam;
           try
           {
               ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
               ImageCodecInfo jpegICIinfo = null;
               for (int x = 0; x < arrayICI.Length; x++)
               {
                   if (arrayICI[x].FormatDescription.Equals("JPEG"))
                   {
                       jpegICIinfo = arrayICI[x];
                       break;
                   }
               }
              
              
               if (jpegICIinfo != null)
               {
                   ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
               }
               else
               {
                   ob.Save(dFile, tFormat);
               }
               return true;
           }
           catch(Exception ex)
           {
               errMsg = ex.Message+",堆栈:"+ex.StackTrace+"InnerException:"+ex.InnerException;
               return false;
           }
           finally
           {
               iSource.Dispose();
               ob.Dispose();
           }



       }
       #endregion
    }
}
