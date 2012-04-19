using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularAddition
{
    /// <summary>
    /// a trivial regular type, representing the computation: set a bit in memory, which is otherwise zeroed, to 1
    /// </summary>
    class Bit : IRegularObject<Bit>
    {
        protected int value;

        public Bit() { value = 0; /* not yet constructed */ }

        public void Construct()
        {
            this.value = 1;
        }

        public void Copy(Bit other)
        {
            this.value = other.value;
        }

        public void Destroy()
        {
            this.value = 0;
        }

        public void Assign(Bit src)
        {
            this.value = src.value;
        }

        public bool Equal(Bit other)
        {
            return this.value == other.value;
        }

        public bool Inequal(Bit other)
        {
            return !Equal(other);
        }

        public bool LessThan(Bit other)
        {
            return (this.value == 0 && other.value == 1);
        }



        public override string ToString()
        {
            return value.ToString();
        }
    }
}
