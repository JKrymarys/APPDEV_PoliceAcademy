﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopScheduler.Models
{
    public class WorkshopDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Coach { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }

        private bool _isEnrolled;
        public bool IsEnrolled
        {
            get => _isEnrolled;
            set
            {
                _isEnrolled = value;
                OnPropertyChanged("IsEnrolled");
            }
        }

        private bool _isEvaluated;

        public bool IsEvaluated
        {
            get => _isEvaluated;
            set
            {
                _isEvaluated = value;
                OnPropertyChanged("IsEvaluated");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
