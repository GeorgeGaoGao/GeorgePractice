using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp
{
    public class TemperatureBuffer
    {
        private List<double> _data = new List<double>();
        public void Add(double temperature)
        {
            _data.Add(temperature);
        }
        public double GetLatest()
        {
            return _data[_data.Count-1];
        }
    }
}
