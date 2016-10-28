using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.CompressImg.untility
{
   public class MyCompare: IComparer<DirectoryInfo>
    {

      

        public int Compare(DirectoryInfo x, DirectoryInfo y)
        {
            int xi = int.Parse(x.Name);
            int yi = int.Parse(y.Name);
            return xi == yi ? 0 : (xi > yi ? 1 : -1);
        }
    }
}
