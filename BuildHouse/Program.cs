using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Models;


namespace BuildHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Project p = new Project();
            p.CreateWorks();
            p.CreateTeam();
            p.StartWork();

        }
    }
}
