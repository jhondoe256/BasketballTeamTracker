using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTeamTracker.UI
{
    class Program
    {
        //this is the controll center.... we don't want ANY LOGIC IN HERE..
        // Only METHOD CALLS!!!
        static void Main(string[] args)
        {
            Program_UI UI = new Program_UI();
            UI.Run();
        }
    }
}
