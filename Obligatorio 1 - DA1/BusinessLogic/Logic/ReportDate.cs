using System;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Logic
{
    [ExcludeFromCodeCoverage]
    public class ReportDate
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime FinishingHour { get; set; }
    }
}
