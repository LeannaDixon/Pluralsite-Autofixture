using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCode
{
    public interface ICalculator<T>
    {
        public T Value { get; set; }
        public void Subtract(T number);
        public void Add(T number);
    }
}
