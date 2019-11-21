using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class ReportDate
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime FinishingHour { get; set; }
    }
}
