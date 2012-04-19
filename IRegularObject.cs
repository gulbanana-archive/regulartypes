using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularAddition
{
    interface IRegularObject<T>
    {
        /// <summary>operation 1: default constructor</summary>
        void Construct();

        /// <summary>operation 2: copy-constructor</summary>
        void Copy(T other);

        /// <summary>operation 3: destructor</summary>
        void Destroy();

        /// <summary>operation 4: assignment</summary>
        void Assign(T source);

        /// <summary>operation 5: equality</summary>
        bool Equal(T other);

        /// <summary>operation 6: inequality</summary>
        bool Inequal(T other);

        /// <summary>operation 7: ordering</summary>
        bool LessThan(T other);
    }
}
