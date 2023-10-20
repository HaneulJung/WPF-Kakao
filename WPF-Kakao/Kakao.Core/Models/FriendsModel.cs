using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Models
{
    public class FriendsModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public FriendsModel DataGen(string id, string name)
        {
            Id = id;
            Name = name;
            return this;
        }
    }
}
