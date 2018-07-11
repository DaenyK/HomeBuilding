using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Interfaces;

namespace HomeBuilding.Lib.Models
{
    namespace HomeBuilding.Lib.Models.Home
    {
        class Walls : IPart
        {
            public IWorker WorkerGets { get; set; }

            public int WorkId { get; set; }

            public double SizeX { get; set; }
            public double SizeY { get; set; }
            public string Company { get; set; }
            public int Count { get; set; }

            public TimeSpan WorkOut { get; set; }

            private DateTime DateFinish_;
            public DateTime DateEnd
            {
                get { return DateFinish_; }
                set
                {
                    DateFinish_ = value;
                    if (DateStart == null || DateStart == DateTime.MinValue)
                        DateStart = value;
                    WorkOut = TimeSpan.FromDays((value - DateStart).TotalDays);
                }
            }
            public DateTime DateStart { get; set; }

            public string Material { get; set; }

            public double Price { get; set; }
            public int Sort { get; set; } = 1;
            public ConsoleColor Color { get; set; } = ConsoleColor.White;
            
        }
    }
}
