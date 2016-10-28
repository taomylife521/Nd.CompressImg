using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nd.CompressImg.extention
{
    public static class MyListExtension
    {
        public static void TryAddImgFile(this List<string> lst, string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp" || extension == ".png")
            {
                lst.Add(filePath);
            }
           

        }
       
    }


    public static class MyDictionaryExtension
    {
        public static void AddFile(this Dictionary<string,List<string>> dic, string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp" || extension == ".png")
            {
              
                dic.TryAdd(".img",filePath);
            }
            else 
            {
                dic.TryAdd(extension, filePath);
            }

        }

         public static void TryAdd(this Dictionary<string,List<string>> dic, string key,object filePath)
        {
           
                if(dic.ContainsKey(key))
                {
                   string str = filePath as string;
                   if (str != null)
                   {
                       dic[key].Add(str);
                   }
                   List<string> lstStr = filePath as List<string>;
                    if(lstStr != null && lstStr.Count > 0)
                    {
                        dic[key].AddRange(lstStr);
                    }
                     
                }
                else
                {
                   
                        List<string> lst = new List<string>();
                        string str = filePath as string;
                        if (str != null)
                        {
                            lst.Add(str);
                        }
                        List<string> lstStr = filePath as List<string>;
                        if (lstStr != null && lstStr.Count > 0)
                        {
                            lst.AddRange(lstStr);
                        }
                        dic.Add(key, lst);
                    
                }
                
           

        }

    }
}
