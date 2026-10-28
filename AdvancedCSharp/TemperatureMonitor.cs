using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp
{
    public class TemperatureMonitor
    {
        //public event Action<double> TemperatureExceed;
        public event EventHandler<TemperatureExceedEventArgs> TemperatureExceed; 
        private double _alarmLimit = 80;

        public void CheckTemperature(double temperature)
        {
            if (temperature>_alarmLimit)
            {
                TemperatureExceed?.Invoke(this,new TemperatureExceedEventArgs(temperature,_alarmLimit));
            }
        }
    }

    public class TemperatureExceedEventArgs : EventArgs
    {
        [DisplayInfo(name:"即时温度",unit:"℃")]
        public double Temperature { get; set; }
        [DisplayInfo(name:"报警上限",unit:"℃")]
        public double AlarmLimit { get; set; }
        public TemperatureExceedEventArgs(double temperature,double alarmLimit)
        {
            Temperature = temperature;
            AlarmLimit = alarmLimit;
        }
    }
    [Info("这是一个用来练习的类")]
    public class Animal
    {

        public string Name { get; set; }
        public int Age { get; set; }

        [Obsolete("speak 方法已过时")]
        public void Speak()
        {
            Console.WriteLine( "动物在叫");
        }
    }

    public class InfoAttribute : Attribute
    {
        public string Description { get; set; }
        public InfoAttribute(string description)
        {
            Description = description;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayInfoAttribute : Attribute
    {
        public string Name { get;  }
        public string Unit { get; }
        public DisplayInfoAttribute(string name,string unit)
        {
            Name = name;
            Unit = unit;
        }
    }
}
