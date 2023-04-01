using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace AnalogClock.Model
{
    class ClockModel
    {
        
        public double Hour; 
        public double Minute;
        public double Second;

        public ClockModel() //Конструктор Model
        {
            Update(); //Вызываем функцию Update
        }

        public void Update() //Присваиваем переменным значения согласно текущему времени
        {
            DateTime time = DateTime.Now;
            Hour = (time.Hour);
            Minute = (time.Minute);
            Second = (time.Second);
        }

    }
}
