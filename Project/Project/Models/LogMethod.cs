using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogMethod
    {
        public LogMethod()
        {
            this.InsertDate = DateTime.Now;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime InsertDate { get; set; }

        public virtual ICollection<LogReport> LogReports { get; set; }
    }
}
