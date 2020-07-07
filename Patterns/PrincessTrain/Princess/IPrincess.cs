using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    interface IPrincess
    {
        int Number { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        HairColor HairColor { get; set; }
        EyeColor EyeColor { get; set; }
    }
}
