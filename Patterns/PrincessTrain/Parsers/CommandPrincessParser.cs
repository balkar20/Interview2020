using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    class CommandPrincessParser: IParser<Princess, string>
    {
        PrincessProperties princessProps;
        CommandPropsParser parser;

        public CommandPrincessParser()
        {
            parser = new CommandPropsParser();
        }

        public Princess Parse(string cmd)
        {
            princessProps = parser.Parse(cmd);

            return new Princess(princessProps.Number, princessProps.Name, Convert.ToByte(princessProps.Age), princessProps.HairColor, princessProps.EyeColor);
        }
    }
}
