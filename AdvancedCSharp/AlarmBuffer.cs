using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp
{
    public class AlarmBuffer
    {
        private List<string> _data = new List<string>();
        public void Add(string temperature)
        {
            _data.Add(temperature);
        }
        public string GetLatest()
        {
            return _data[_data.Count - 1];
        }
    }
}
