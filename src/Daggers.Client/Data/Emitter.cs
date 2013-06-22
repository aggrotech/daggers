using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daggers.Client.Data
{
    public class Emitter
    {
        public string AttachingMeshTagName;

        public Vector PositionOffset;
        public Quaternion OrientationOffset;

        public int LifetimeMs;
        public int CooldownMs;

        public List<Projectile> Projectiles;
    }
}
