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
    public static class Imperative
    {
        public static void Run()
        {
            var file = File.ReadAllText(@"D:\4.txt", Encoding.UTF8);
            var users = new List<User>();
            try
            {
                UsersModel json = JsonConvert.DeserializeObject<UsersModel>(file);
                users = json.Users;
            }
            catch (Exception e)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UsersModel));
                var xml = (UsersModel)serializer.Deserialize(new StringReader(file));
                users = xml.Users;
            }

            var str = @"	|	Name	|	Age	|	Salary	| ";
            for (var i = 0; i < users.Count; i ++)
            {
                var item = users[i];
                str += "\n" + $"{i+1}	|	{item.Name}	|	{item.Age}	|	{item.Salary}	|";
            }

            Console.WriteLine("Imperative:");
            Console.WriteLine(str + "\n");
        }
    }
}
