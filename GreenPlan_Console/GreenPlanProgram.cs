using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Console
{
    internal class GreenPlanProgram
    {
        static void Main(string[] args)
        {
            GreenPlanProgramUI ui = new GreenPlanProgramUI();
            ui.Run();
        }
    }
}
