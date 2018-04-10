﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopScheduler.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkshopScheduler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        private App _currentApp = Application.Current as App;
        private List<Unit> _pickerUnitsOptions = Enum.GetValues(typeof(Unit)).Cast<Unit>().ToList();

        public ProfilePage()
        {
            InitializeComponent();
            NameCell.Text = _currentApp.UserName;
            SurnameCell.Text = _currentApp.UserSurname;
            UnitPicker.ItemsSource = _pickerUnitsOptions;
            UnitPicker.SelectedItem = _currentApp.UserUnit;
        }
    }
}   