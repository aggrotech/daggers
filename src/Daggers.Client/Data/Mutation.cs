using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daggers.Client.Data
{
    public enum MutationArithmeticTypes
    {
        Set,
        Add,
        Subtract,
        Multiply,
        Divide,
        Percent
    }

    public class Mutation
    {
        public string PropertyId;
        public string ItemId;

        public MutationArithmeticTypes ArithmeticType;
        public int Value;
        public int TweenTimeMs;
    }
}
