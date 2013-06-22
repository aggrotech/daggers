using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daggers.Client.Data
{
    public class Vehicle
    {
        public string Id;

        public int Health;
        public int Shield;

        public Mesh Mesh;

        public Kinematics Kinematics;
        public List<Item> Items;
    }
}
