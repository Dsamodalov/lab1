﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab3_binding_
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventPlace { get; set; }
        public int RemindTime { get; set; }
        public List<string> TypeOfTime { get; set; }
        public static string SelectedTime { get; set; }
        public bool IsRepeat { get; set; }
        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }
        private static DateTime _EventDate = DateTime.Now;
        public static DateTime EventDate
        {
            get { return _EventDate.Date; }
            set
            {
                _EventDate = value.Date + _EventDate.TimeOfDay;
            }
        }
        public TimeSpan EventTime
        {
            get
            {
                return _EventDate.TimeOfDay;
            }

            set
            {
                
                _EventDate = _EventDate.Date + value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private bool _isNotification = true;
        public bool IsNotification
        {
            get
            {
                return _isNotification;
            }

            set
            {
                _isNotification = value;
                DoPropertyChanged("IsNotification");
                ;
            }
        }



        public MainWindowViewModel()
        {
            TypeOfTime = new List<string>()
            {
                "Секунд",
                "Минут",
                "Часов",
                "Дней"
            };
            Save = new ButtonCommand();
            Cancel = new ButtonCommand();
        }
    }
}
