using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Interfaces;
using HomeBuilding.Lib.Models.HomeBuilding.Lib.Models.Home;
using HomeBuilding.Lib.Models.HomeBuilding.Lib.Models.Team;

namespace HomeBuilding.Lib.Models
{
    public class Project
    {
        public List<IPart> ListWork = new List<IPart>();
        public List<IWorker> Workers = new List<IWorker>();

        Random rnd = new Random();
        public void CreateWorks()
        {
            int id = 0;
            int c = rnd.Next(1, 3);
            for (int i = 0; i < c; i++)
            {
                
                Basement basement = new Basement();
                basement.WorkId = id++;
                basement.Company = "Bazis";
                basement.Count = 1;
                basement.Material = "beton";
                basement.Price = rnd.Next();
                ListWork.Add(basement);
            }

            for (int i = 0; i < c * 4; i++)
            {
                Walls walls = new Walls();
                walls.WorkId = id++;

                walls.Company = "-";
                walls.Count = 1;
                walls.Material = "kirpich";
                walls.SizeX = 10;
                walls.SizeY = 3;
                walls.Price = walls.SizeX * walls.SizeY * 15;
                walls.Color = ConsoleColor.Gray;
                ListWork.Add(walls);
            }


            for (int i = 0; i < c * rnd.Next(2, 6); i++)
            {
                Window windows = new Window();
                windows.WorkId = id++;

                windows.Company = "-";
                windows.Count = 1;
                windows.Material = "plastic";
                windows.SizeX = 3;
                windows.SizeY = 1.5;
                windows.Price = rnd.Next(10000, 80000);
                ListWork.Add(windows);
            }

            for (int i = 0; i < c * 4; i++)
            {
                Door doors = new Door();
                doors.Company = "-";
                doors.WorkId = id++;

                doors.Count = 1;
                doors.Material = "wood";
                doors.SizeX = 2.3;
                doors.SizeY = 1.5;
                doors.Price = rnd.Next(10000, 50000);
                ListWork.Add(doors);
            }

            ListWork.Add(new Roof() { Count = 1, Price = rnd.Next() ,WorkId = id});

        }
        public void CreateTeam()
        {
            int count = rnd.Next(5, 10);
            for (int i = 0; i < count; i++)
            {
                Worker worker = new Worker();

                worker.FIO = "people " + rnd.Next(1, 10).ToString();
                worker.age = rnd.Next(20, 50);
                worker.Spec = (Spec)rnd.Next(0, 3);
                worker.SalaryInHour = rnd.Next(800, 3500);
                Workers.Add(worker);
            }
            TeamLeader brigadir = new TeamLeader();
            brigadir.FIO = "Leader";
            brigadir.age = rnd.Next(20, 50);
            brigadir.SalaryInHour = rnd.Next(800, 3500);
            brigadir.Brigada = Workers;
            Workers.Add(brigadir);
        }
        public void StartWork()
        {
            TeamLeader leader =(TeamLeader) Workers.FirstOrDefault(f => f.IsTeam==true);

            DateTime stw = DateTime.Now;
            DateTime fw = stw;
            ListWork = ListWork.OrderBy(o => o.Sort).ToList();
            for (int i = 0; i < ListWork.Count; i++)
            {
                Worker w = leader[leader.GetWorkerId()];
              //  leader.GetReport(ListWork);
                if ((fw-stw).TotalDays>0)
                {
                    leader.GetReport(ListWork);
                }
                else
                {
                    IPart p = GetWork();
                    if (p != null)
                    {
                        int workOut = rnd.Next(1, 15);
                        ListWork[p.WorkId].DateStart =fw;
                        ListWork[p.WorkId].DateEnd = ListWork[p.WorkId].DateStart.AddDays(rnd.Next(1, 30));
                        ListWork[p.WorkId].WorkerGets = w;
                        fw = fw.AddDays(workOut);
                    }
                }
            }
        }
        public IPart GetWork()
        {
            //ListWork = ListWork.OrderBy(o => o.Sort).ToList();

            IPart p = (IPart)ListWork.Where(w => w.DateStart == DateTime.MinValue).FirstOrDefault();
            return p;
        }
    }
}
