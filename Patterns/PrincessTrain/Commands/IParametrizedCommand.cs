using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    interface IParametrizedCommand: ICommand
    {
        void SetParams(params string[] parametres);
    }
}
