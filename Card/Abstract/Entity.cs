using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    abstract class Entity
    {
        public int BaseHealth { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }

        // TODO Effects List
    }
}
