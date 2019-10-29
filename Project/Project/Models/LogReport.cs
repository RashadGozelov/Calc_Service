using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogReport
    {
        public LogReport()
        {

        }

        public LogReport(int logmethodId, string value)
        {
            LogMethodId = logmethodId;
            Value = value;
            this.InsertDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime InsertDate { get; set; }

        public string Value { get; set; }

        public int LogMethodId { get; set; }

        public LogMethod LogMethod { get; set; }
    }
}
