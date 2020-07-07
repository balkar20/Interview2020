using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    interface IParser<TOut, TIn>
    {
        TOut Parse(TIn subj);
    }
}
