using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Interfaces;


namespace HomeBuilding.Lib.Models
{
    namespace HomeBuilding.Lib.Models.Team
    {
        public class TeamLeader : IWorker
        {
            public bool IsTeam { get; set; } = true;

            public int age { get; set; }

            public string FIO { get; set; }

            public double SalaryInHour { get; set; }

            public Spec Spec { get; set; }
            public List<IWorker> Brigada = new List<IWorker>();
            Random rnd = new Random();
            public Worker GetWorker()
            {
                return (Worker)Brigada.ElementAt(rnd.Next(0, Brigada.Count - 1));
            }
            public int GetWorkerId()
            {
                return rnd.Next(0, Brigada.Count - 1);
            }
            public Worker this[int workerId]
            {
                get
                {
                    return (Worker)Brigada.ElementAt(rnd.Next(0, Brigada.Count - 1));
                }

            }
            public void GetReport(List<IPart> works)
            {
                foreach (IPart item in works)
                {
                    if (item.DateStart != DateTime.MinValue && item.DateEnd != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("ID {5}: {0} - {1} ({2}дней/{3}часов)\nЗП: {4}\nФИО: {6}",
                         item.DateStart, item.DateEnd, item.WorkOut.TotalDays, item.WorkOut.TotalHours,
                         item.WorkOut.TotalHours * item.WorkerGets.SalaryInHour, item.WorkId, item.WorkerGets.FIO);
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                    else if (item.DateStart != DateTime.MinValue && item.DateEnd == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("ID {5}: {0} - {1} ({2}дней/{3}часов)\nЗП: {4}\nФИО: {6}",
                         item.DateStart, item.DateEnd, item.WorkOut.TotalDays, item.WorkOut.TotalHours, 
                         item.WorkOut.TotalHours * item.WorkerGets.SalaryInHour, item.WorkId, item.WorkerGets.FIO);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("ID {0}", item.WorkId);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }
    }
}