using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace DisneyPrincessApp
{
    class FileReader: IReader
    {
        string path;
        public FileReader(string path)
        {
            this.path = path;
        }

        public string[] Read()
        {
            string[] readLines = File.ReadAllLines(path);
            return readLines;    
        }
    }
}
