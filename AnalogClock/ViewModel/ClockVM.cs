using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using AnalogClock.Model;

namespace AnalogClock.ViewModel
{
    class ClockVM : INotifyPropertyChanged
    {


        ClockModel _cm = new ClockModel(); //создаем экземпляр класса ClockModel()
        private DispatcherTimer Timer { get; set; } = new DispatcherTimer(); // Создаём экземпляр таймера

        public event PropertyChangedEventHandler PropertyChanged; //Инициализируем PropertyChanged

        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //Описываем необходимые переменные

        private double _Seconds; 
        private double _AngleSeconds;

        private double _Minute;
        private double _AngleMinute;

        private double _Hour;
        private double _AngleHour;


        public double Seconds
        {
            get
            {
                return _Seconds;
            }
            set
            {
                _Seconds = value;
                OnPropertyChanged();
            }
        }
        public double AngleSeconds
        {
            get
            {
                return _AngleSeconds;
            }
            set
            {
                _AngleSeconds = value;
                OnPropertyChanged();
            }
        }
        public double Hour
        {
            get
            {
                return _Hour;
            }
            set
            {
                _Hour = value;
                OnPropertyChanged();
            }
        }
        public double AngleHour
        {
            get
            {
                return _AngleHour;
            }
            set
            {
                _AngleHour = value;
                OnPropertyChanged();
            }
        }

        public double Minute
        {
            get
            {
                return _Minute;
            }
            set
            {
                _Minute = value;
                OnPropertyChanged();
            }
        }
        public double AngleMinute
        {
            get
            {
                return _AngleMinute;
            }
            set
            {
                _AngleMinute = value;
                OnPropertyChanged();
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            _cm.Update(); //обращаемся к функции класса ClockModel для обновления данных и присваиваем переменным обновленные значения
            Seconds = _cm.Second;
            Hour = _cm.Hour;
            Minute = _cm.Minute;
            HourHand(); //переходим к функции отвечающей за часовые стрелки
        }

        private void HourHand()
        {
            if (Hour > 12) //приводим часы к 12-ти часовому формату
            {
                Hour = Hour - 12;
            }

            //Считаем угол поворота часовых стрелок
            AngleHour = (_Hour * 30) + (_Minute * 0.5);
            AngleMinute = _Minute * 6;
            AngleSeconds = _Seconds * 6;

        }

        public ClockVM() //Конструктор ViewModel
        {
            Timer.Interval = TimeSpan.FromSeconds(1); //Задаём интервал таймера
            Timer.Tick += Timer_Tick; // Добавляем таймеру функционал
            Timer.Start(); // Запускаем таймер
        }







    }

}

