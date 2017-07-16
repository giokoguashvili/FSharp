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
    public static class ObjectOriented
    {
        public static void Run()
        {
            var file = new File(@"D:\4.txt", Encoding.UTF8).Read();
            var parserService = new ParserService();

            var jsonResult = parserService.ParseJSON<UsersModel>(file);
            var xmlResult = parserService.ParseXML<UsersModel>(file);

            var users = jsonResult != null ? jsonResult.Users : xmlResult.Users;
            new View(users).Render();
        }

        public class View
        {
            private readonly List<User> _users;

            public View(List<User> users)
            {
                _users = users;
            }

            public void Render()
            {
                var str = @"	|	Name	|	Age	|	Salary	| ";
                var index = 0;
                foreach (var item in _users)
                {
                    str += "\n" + $"{++index}	|	{item.Name}	|	{item.Age}	|	{item.Salary}	|";
                }

                Console.WriteLine("Object Oriented:");
                Console.WriteLine(str + "\n");
            }
        }

        public class File
        {
            private readonly string _path;
            private readonly Encoding _encoding;

            public File(string path, Encoding encoding)
            {
                _path = path;
                _encoding = encoding;
            }

            public string Read()
            {
                return System.IO.File.ReadAllText(@"D:\4.txt", _encoding);
            }
        }

        public class ParserService
        {

            public T ParseJSON<T>(string str)
                where T : class
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(str);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public T ParseXML<T>(string str)
                where T : class
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(new StringReader(str));
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
