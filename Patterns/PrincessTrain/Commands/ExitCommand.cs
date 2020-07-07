using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace DisneyPrincessApp
{

    class ExitCommand: ICommand
    {
        public void Execute()
        {
            Environment.Exit(1);
        }
    }
    
}
