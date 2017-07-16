using System.Collections.Generic;
using System.Xml.Serialization;

namespace Models1
{

    public class UsersModel
    {
        [XmlElement("User")]
        public List<User> Users { get; set; }
    }
}
