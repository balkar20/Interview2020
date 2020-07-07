using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    class ConsoleMessager:IMessager
    {
        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
