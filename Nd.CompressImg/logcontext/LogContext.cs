using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.CompressImg.logcontext
{
    public class LogContext
    {
        public void AddLogInfo(string strPath, string txt, bool isAppend)
        {
            string strDirecory = strPath.Substring(0, strPath.LastIndexOf('\\'));
            if (!Directory.Exists(strDirecory))
            {
                Directory.CreateDirectory(strDirecory);
            }
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }

            StreamWriter fs;
            if (isAppend) fs = File.AppendText(strPath);
            else fs = File.CreateText(strPath);

            fs.WriteLine(txt);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }


        public string ReadDataLog(string strPath)
        {
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }

            string txt = File.ReadAllText(strPath, Encoding.UTF8);

            return txt;
        }
    }
}
