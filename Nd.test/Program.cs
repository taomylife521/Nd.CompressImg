using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;

namespace Nd.test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 多线程
            //List<string> demoData = new List<string>();
            //Parallel.For(0, 96, num =>
            //{
            //    demoData.Add(num.ToString());
            //});
            //// 以上是生成一个测试用的数组，我就不考虑线程安全的问题了
            //var tasks = new ConcurrentBag<Task>();
            //ConcurrentBag<int> sum = new ConcurrentBag<int>();
            //sum.Add(0);
            //CancellationTokenSource importCts = new CancellationTokenSource();

            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("输入e或者q可以取消任务。");
            //        string input = (Console.ReadLine() ?? "").ToLower();
            //        if (input == "e" || input == "q")
            //        {
            //            importCts.Cancel();
            //            Console.WriteLine("已发出取消请求。");
            //            break;
            //        }
            //    }
            //});

            //// 开启管理Task
            //Task t = Task.Factory.StartNew(() =>
            //{
            //    int maxCount = 10, currentCount = 0;
            //    int tempCount = 0;
            //    while (demoData.Count > 0 && !importCts.Token.IsCancellationRequested)
            //    {
            //        Console.WriteLine("当前共{0}个子任务。", currentCount);
            //        while (currentCount >= maxCount)
            //        {
            //            int index = Task.WaitAny(tasks.ToArray());
            //            Console.WriteLine("子任务ID={0}已完成。", tasks.ToArray()[index].Id);
            //            currentCount--;
            //        }
            //        Thread.Sleep(1000);
            //        // 10可以做成可配置的值
            //        List<string> childData = demoData.Take(50).ToList();
            //        tempCount += childData.Count;
            //        if (childData.Count > 0)
            //        {
            //            demoData.RemoveRange(0, childData.Count);
            //            Console.WriteLine("分配50个到子任务……");
            //            Task subTask = Task.Factory.StartNew(() =>
            //            {
            //                DoSomeWork(childData, importCts.Token);
            //            }, importCts.Token);
            //            // Thread.Sleep(3000);
            //            currentCount++;
            //            tasks.Add(subTask);
            //        }
            //        else if (tempCount == 96)
            //        {
            //            if (currentCount < maxCount)
            //            {
            //                maxCount = currentCount;
            //            }
            //            Console.WriteLine("全部分配完毕。");
            //        }
            //        else
            //        {
            //            Console.WriteLine("全部分配完毕。");
            //        }
            //    }
            //}, importCts.Token).ContinueWith(task =>
            //{
            //    Console.WriteLine("管理Task已退出。");
            //}); 
            #endregion

            GetPicThumbnail("c:\\1.jpg", "C:\\2.jpg", 200, 100, 60);
            Console.WriteLine("压缩成功");
            Console.ReadKey();
            //Test();
        }

        private static void DoSomeWork(List<string> data, CancellationToken token)
        {
            foreach (string d in data)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("任务已被取消。");
                    break;
                }
              
                Console.WriteLine(d);
                Thread.Sleep(200);
            }
        }

        private static void Test()
        {
            bool flag = GetPicThumbnail("D:\\1.jpg", "D:\\2.jpg", 746 / 2, 1366 / 2, 70);
            if (flag)
            {
                Console.WriteLine("压缩成功");
            }
            Console.ReadKey();
        }

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

        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);

            ImageFormat tFormat = iSource.RawFormat;

            int sW = 0, sH = 0;

            //按比例缩放

            Size tem_size = new Size(iSource.Width, iSource.Height);
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
            catch
            {
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
