using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daggers.Client.Data
{
    public class Item
    {
        public string Id;   // "AR 606"

        public List<Emitter> Emitters;
        public List<Mutation> Mutations;
    }
}
