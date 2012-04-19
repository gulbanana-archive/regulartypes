using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularAddition
{
    /// <summary>
    /// an unsigned number, represented as a string of "bits", each bit being any object of a regular type
    /// </summary>
    class Number<T> : IRegularObject<Number<T>> where T : IRegularObject<T>, new()
    {
        protected T[] sequence;

        #region regular type operations
        public Number()
        {
            sequence = new T[1];
            sequence[0] = new T();
        }

        public void Construct()
        {
            sequence = new T[1];
            sequence[0] = new T();
            sequence[0].Construct();
        }

        public void Copy(Number<T> other)
        {
            sequence = new T[other.sequence.Length];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = new T();
                sequence[i].Assign(other.sequence[i]);
            }
        }

        public void Destroy()
        {
            sequence = new T[1];
            sequence[0] = new T();
        }

        public void Assign(Number<T> source)
        {
            if (sequence.Length != source.sequence.Length)
                sequence = new T[source.sequence.Length];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = new T();
                sequence[i].Assign(source.sequence[i]);
            }
        }

        public bool Equal(Number<T> other)
        {
            return sequence
                .Zip(other.sequence, (a, b) => a.Equal(b))
                .All(p => p == true);
        }

        public bool Inequal(Number<T> other)
        {
            return !Equal(other);
        }

        public bool LessThan(Number<T> other)
        {
            return sequence.Length < other.sequence.Length;
        }
        #endregion

        //algorithm implementations
        //unsigned numbers are defined as a sequence of objects of regular types.
        //evaluate and increment are defined for numbers, and then add is defined in 
        //terms of evaluate and increment
        public int Evaluate()
        {
            int result = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                int bit = (sequence[i].Equal(new T())) ? 0 : 1;
                result += bit << i;
            }

            return result;
        }

        public void Increment(int position)
        {
            //overflow
            if (position == sequence.Length)
            {
                var newSeq = new T[sequence.Length + 1];
                sequence.CopyTo(newSeq, 0);
                newSeq[sequence.Length] = new T();
                sequence = newSeq;
            }

            // bit = 0
            if (sequence[position].Equal(new T()))
            {
                sequence[position].Construct();
            }
            // bit = 1
            else
            {
                Increment(position + 1);
                sequence[position].Destroy();
            }
        }

        public Number<T> Add(Number<T> other)
        {
            var result = new Number<T>();
            result.Copy(this);

            for (int i = 0; i < other.Evaluate(); i++)
                result.Increment(0);

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var elem in sequence.Reverse())
            {
                result.Append(elem.ToString());
            }

            return result.ToString();
        }
    }
}
