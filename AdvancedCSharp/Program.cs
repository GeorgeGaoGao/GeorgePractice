using System.Reflection;

namespace AdvancedCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Buffer<double> temperatureBuffer = new Buffer<double>();
            temperatureBuffer.Add(42.5);
            temperatureBuffer.Add(46.8);
            temperatureBuffer.Add(85.2);

            Buffer<string> alarmBuffer = new Buffer<string>();
            alarmBuffer.Add("压力超限");
            alarmBuffer.Add("温度超限");

            //Console.WriteLine("==========缓存结果==========");
            //Console.WriteLine($"最新温度：{temperatureBuffer.GetLatest()} ℃");
            //Console.WriteLine($"最新报警：{alarmBuffer.GetLatest()}");

            //Console.WriteLine("\n=============================\n");
            double latestTemperature = temperatureBuffer.GetLatest();

            //TemperatureHandler temperatureHandler = ShowTemperature;
            //temperatureHandler += CheckAlarm;
            //temperatureHandler += WriteLog;
            //temperatureHandler?.Invoke(latestTemperature);

            //Console.WriteLine("\n============Monitor=================\n");
            TemperatureMonitor temperatureMonitor = new TemperatureMonitor();
            temperatureMonitor.TemperatureExceed += ShowAlarmInfo;
            //temperatureMonitor.TemperatureExceed += ShowTemperature;
            //temperatureMonitor.TemperatureExceed += CheckAlarm;
            //temperatureMonitor.TemperatureExceed += WriteLog;
            temperatureMonitor.CheckTemperature(latestTemperature);

            //Animal animal = new Animal();
            //animal.Name = "tom";
            //animal.Age = 16;
            //animal.Speak();
            //InfoAttribute infoAttribute = animal.GetType().GetCustomAttribute<InfoAttribute>();
            //Console.WriteLine(infoAttribute.Description);


            //ShowObjectInfo(animal);
            //Console.WriteLine( "\n==========\n");

            //Type type2 = animal.GetType();
            //string valueOfName;
            //int ValueOfAge;
            //PropertyInfo[] propertyInfos = type2.GetProperties();
            //foreach (var property in propertyInfos)
            //{
            //    object propertyValue = property.GetValue(animal);
            //    Console.WriteLine($"属性名称：{property.Name} 值：{propertyValue}");


            //}

            //MethodInfo[] methodInfos = type2.GetMethods();
            //foreach (var methodInfo in methodInfos)
            //{
            //    Console.WriteLine($"方法名称：{methodInfo.Name}");
            //}
            //MethodInfo methodInfo2 = type2.GetMethod("Speak");
            //methodInfo2.Invoke(animal, null);

            //Console.WriteLine(type2.Name);
            //Console.WriteLine(type2.Name);

        }

        private static void  ShowAlarmInfo(object? sender, TemperatureExceedEventArgs e)
        {
            Type type = e.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                DisplayInfoAttribute info = propertyInfo.GetCustomAttribute<DisplayInfoAttribute>();
                if (info != null)
                {
                    object value = propertyInfo.GetValue(e);
                    Console.WriteLine($"{info.Name}:{value} {info.Unit}");
                }

            }
        }

        private static void WriteLog(object? sender, TemperatureExceedEventArgs e)
        {
            bool temp = e.Temperature > e.AlarmLimit;
            Console.WriteLine($"是否报警：{temp} ");
        }

        private static void CheckAlarm(object? sender, TemperatureExceedEventArgs e)
        {
            double temperature = e.Temperature;
            if (temperature > 80)
            {
                Console.WriteLine("报警状态：温度超限");
            }
            else
            {
                Console.WriteLine("报警状态：温度正常");
            }
        }

        private static void ShowTemperature(object? sender, TemperatureExceedEventArgs e)
        {
            Console.WriteLine($"当前温度：{e.Temperature} ℃");
        }

        public delegate void TemperatureHandler(double temperature);
        //static void ShowTemperature(object obj, double temperature)
        //{
        //    Console.WriteLine($"当前温度：{temperature} ℃");
        //}
        //static void CheckAlarm(double temperature)
        //{
        //    if (temperature>80)
        //    {
        //        Console.WriteLine("报警状态：温度超限");
        //    }
        //    else
        //    {
        //        Console.WriteLine("报警状态：温度正常");
        //    }
        //}
        //static void WriteLog(double temperature)
        //{
        //    Console.WriteLine($"运行日志：已记录温度 {temperature} ℃");
        //}
        static bool IsAlarming(double temperature, double alarmLimit)
        {
            return temperature > alarmLimit;
        }


        static void ShowObjectInfo(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var property in propertyInfos)
            {
                object propertyValue = property.GetValue(obj);
                Console.WriteLine($"属性名称： {property.Name}\t属性值：{propertyValue}");
            }
        }
    }

}
