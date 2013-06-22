using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daggers.Client.Data
{
    public class Projectile
    {
        public Kinematics Kinematics;

        public int MutationRadius;
        public List<Mutation> VehicleCollisionMutations;

        public Emitter Emitter;
        public Emitter CollisionEmitter;

        public Mesh Mesh;
    }
}
