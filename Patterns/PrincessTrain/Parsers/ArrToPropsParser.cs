using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DisneyPrincessApp
{
    class ArrToPropsParser: IParser<PrincessProperties, string[]>
    {
        PrincessProperties princessProps;
        public PrincessProperties Parse(string[] arr)
        {
            princessProps = new PrincessProperties();
            princessProps.Number = Convert.ToInt32(arr[0]);
            if (arr.Length >= 5)
            {
                int i;
                string spase = "";
                for (i = 1; i <= arr.Length - 4; i++)
                {
                    princessProps.Name += spase + arr[i];
                    spase = " ";
                }
                princessProps.Age = Convert.ToInt32(arr[i]);
                princessProps.HairColor = (HairColor)Enum.Parse(typeof(HairColor), arr[i + 1]);
                princessProps.EyeColor = (EyeColor)Enum.Parse(typeof(EyeColor), arr[i + 2]);
            }

            return princessProps;
        }
         
    }
}
