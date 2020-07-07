using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    class FileParser:IParser<Princess[], string[]>
    {
        public Princess[] Parse(string[] str)
        {
            string[] partsOfStr;
            List<Princess> lp = new List<Princess>();
            for (int i = 0; i < str.Length; i++)
            {
                partsOfStr = DocSplitter(str[i]);
                Princess princess;
                int number = Int32.Parse(partsOfStr[0]);
                string name = partsOfStr[1];
                byte age = (byte)Int32.Parse(partsOfStr[2]);
                HairColor hair;
                EyeColor eye;

                string[] enumHairStrings = Enum.GetNames(typeof(HairColor));

                if (enumHairStrings.Contains(partsOfStr[3]))
                {
                    hair = (HairColor)Enum.Parse(typeof(HairColor), partsOfStr[3]);
                }
                else
                {
                    hair = HairColor.Black;
                }

                string[] enumEyeStrings = Enum.GetNames(typeof(EyeColor));
                if (enumEyeStrings.Contains(partsOfStr[4]))
                {
                    eye = (EyeColor)Enum.Parse(typeof(EyeColor), partsOfStr[4]);
                }
                else
                {
                    eye = EyeColor.Black;
                }
                princess = new Princess(number, name, age, hair, eye);
                lp.Add(princess);
            }
            return lp.ToArray();
        }

        public string[] DocSplitter(string str)
        {
            string[] result = str.Split('|').Select(p => p.Trim()).ToArray();
            return result;
        }
    }
}
