using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            //constant
            var one = new Number<Bit>();
            one.Construct();

            //a few additions
            var two = one.Add(one);
            var three = one.Add(two);
            var six = three.Add(three);
            var ten = one.Add(three.Add(six));

            //proof that any regular object can be used, not just one which represents a bit
            var anotherOne = new Number<Number<Bit>>();
            anotherOne.Construct();
            var four = anotherOne.Add(anotherOne.Add(anotherOne.Add(anotherOne)));

            //display results
            Console.WriteLine("one: {0}: '{1}'", one.Evaluate(), one);
            Console.WriteLine("two: {0}: '{1}'", two.Evaluate(), two);
            Console.WriteLine("three: {0}: '{1}'", three.Evaluate(), three);
            Console.WriteLine("four: {0}: '{1}'", four.Evaluate(), four);
            Console.WriteLine("six: {0}: '{1}'", six.Evaluate(), six);
            Console.WriteLine("ten: {0}: '{1}'", ten.Evaluate(), ten);

            Console.ReadKey();
        }
    }
}
