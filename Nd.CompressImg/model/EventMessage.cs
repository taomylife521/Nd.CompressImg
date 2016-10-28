using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.CompressImg.model
{
    public class EventMessage:EventArgs
    {
        public string msg { get; set; }

      
    }

    public class DealResult
    {
        //public string taskId { get; set; }

        public int sucessCount { get; set; }

        public int failCount { get; set; }

        public double totalTime { get; set; }

      
    }
}
