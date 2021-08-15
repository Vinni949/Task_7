using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    class DateInterval
    {/// <summary>
    /// класс для выгрузки интервала дат
    /// </summary>
        public DateTime StartDate { get; set; }
        public DateTime EndDate   { get; set; }
        public DateInterval(DateTime starDate, DateTime endDate)
        {
            this.StartDate = starDate;
            this.EndDate = endDate;
        }
      
    }
}
