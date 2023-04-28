using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TextAnalysis
{
    public static class MyFile
    {
        public static string ReadFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // считываем из файла весь текст
                StreamReader sr = new StreamReader(fs);
                return sr.ReadToEnd();
            }
        }
    }
}
