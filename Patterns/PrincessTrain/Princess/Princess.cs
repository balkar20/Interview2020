using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyPrincessApp
{
    enum HairColor
    {
        Black,
        Blonde,
        PlatinumBlonde,
        Red,
        Brown
    }

    enum EyeColor
    {
        Brown,
        Blue,
        Violet,
        Black,
        Hazel
    }

    class Princess:IPrincess
    {
        int age;
        public int Number { get; set; }
        public string Name { get; set; }
        public HairColor HairColor { get; set; }
        public EyeColor EyeColor { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                if(value > 0 && value <= 99)
                {
                    age = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Princess(int number, string name, byte age, HairColor hairColor, EyeColor eyeColor)
        {
            this.Number = number;
            this.Name = name;
            this.Age = age;
            this.HairColor = hairColor;
            this.EyeColor = eyeColor;
        }

        public override string ToString()
        {
            return this.Number + ". " + this.Name +
                    String.Format("\nAge: {0}\nHair: {1}\nEyes:{2}\n", this.Age, this.HairColor, this.EyeColor.ToString());
        }

        public override bool Equals(object obj)
        {
            Princess princess = (Princess)obj;
            if(princess != null)
            {
                if (princess.Number == this.Number && princess.Name == this.Name
                && princess.Age == this.Age
                && princess.HairColor == this.HairColor
                && princess.EyeColor == this.EyeColor)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
