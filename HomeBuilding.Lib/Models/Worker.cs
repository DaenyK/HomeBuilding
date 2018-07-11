using HomeBuilding.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilding.Lib.Models
{
    namespace HomeBuilding.Lib.Models.Team
    {
        public class Worker : IWorker
        {
            public bool IsTeam { get; set; } = false;

            public int age { get; set; }

            public string FIO { get; set; }

            public double SalaryInHour { get; set; }

            public Spec Spec { get; set; }
        }
    }
}
