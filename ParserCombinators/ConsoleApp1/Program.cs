using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        // read file from directory, with name, whic format is utf-8, 
        // read content , JSON or XML
        // format to table as user report
        // show in console
        static void Main(string[] args)
        {
            Imperative.Run();
            Procedural.Run();
            ObjectOriented.Run();

            Console
                .WriteLine(
                    new ResultView(
                          new HalfPyramid(4, '#')
                    )
                );

            Console.ReadLine();
        }
    }
}
