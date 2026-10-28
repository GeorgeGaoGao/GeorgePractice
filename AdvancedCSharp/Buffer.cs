using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp
{
    public class Buffer<T>
    {
        private List<T> _data = new List<T>();
        public void Add(T temperature)
        {
            _data.Add(temperature);
        }
        public T GetLatest()
        {
            return _data[_data.Count - 1];
        }
    }
}
