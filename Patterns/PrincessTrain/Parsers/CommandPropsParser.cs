using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DisneyPrincessApp
{
    
    class CommandPropsParser:IParser<PrincessProperties, string>
    {
        PrincessProperties princessProps;
        ArrToPropsParser arrParser;

        public CommandPropsParser()
        {
            arrParser = new ArrToPropsParser();
        }

        public  PrincessProperties Parse(string comandStr)
        {
            string[] arr = comandStr.Split(' ');
            princessProps = arrParser.Parse(arr);
            return princessProps;
        }
    }
}
