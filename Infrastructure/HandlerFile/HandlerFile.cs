using System;
using System.Collections.Generic;
using System.IO;

namespace dotapp.Infrastructure.HandlerFile
{
    public sealed class HandlerFile
    {
        public static void WriteLine<T>(T line, String fileName)
        {
            if(File.Exists(fileName))
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine(line);
                }
            }
            else
            {
                using (FileStream fs = File.Create(fileName)){}
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine(line);
                }
            }
        }

        public static List<String> RaedLine(String fileName)
        {
            List<String> lines = new List<string>();
            String line;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);

                    }
                    
                }
            }

        return lines;    
        }


    }
}