using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models1;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public static class Procedural
    {
        public static void Run()
        {
            var file = "";
            ReadFile(@"D:\5.txt", Encoding.UTF8, ref file);

            var users = new List<User>();
            bool canParse = false;
            ParseJSON(file, users, ref canParse);
            if (!canParse)
            {
                ParseXML(file, users, ref canParse);
            }

            var view = GenerateView(users);
            Console.WriteLine("Procedural:");
            Console.WriteLine(view + "\n");
        }

        private static string GenerateView(List<User> users)
        {
            var str = @"	|	Name	|	Age	|	Salary	| ";
            var index = 0;
            foreach (var item in users)
            {
                
                str += "\n" + $"{++index}	|	{item.Name}	|	{item.Age}	|	{item.Salary}	|";
            }
            return str;
        }
        private static void ParseXML(string file, List<User> users, ref bool canParse)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UsersModel));
                var xml = (UsersModel)serializer.Deserialize(new StringReader(file));
                foreach (var item in xml.Users)
                {
                    users.Add(item);
                }
                canParse = true;
            }
            catch (Exception e)
            {
                canParse = false;
            }
        }
        private static void  ParseJSON(string file, List<User> users, ref bool canParse)
        {
            try
            {

                UsersModel json = JsonConvert.DeserializeObject<UsersModel>(file);
                foreach (var item in json.Users)
                {
                    users.Add(item);
                }
                canParse = true;
            }
            catch (Exception e)
            {
                canParse = false;
            }
        }
        private static void ReadFile(string path, Encoding encoding, ref string resultFile)
        {
            resultFile = File.ReadAllText(path, encoding);
        }
    }
}
