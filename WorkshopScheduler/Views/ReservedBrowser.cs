﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using WorkshopScheduler.Models;
using WorkshopScheduler.Logic;


namespace WorkshopScheduler.Views
{
    public partial class ReservedBrowser : ContentPage
    {
        ObservableCollection<Workshop> reservedList;
        ObservableCollection<Workshop> displayList;
        FiltersModalView filtersView;


        public ReservedBrowser()
        {
            InitializeComponent();
            //lorem ipsum is to test longer strings, but I dont want to deal with them normally ;) 

            reservedList = TestData.LoremIpsumData; // provide the test
            WorkshopsListView.ItemsSource = reservedList;
            Sorting sortings = new Sorting();
            Filters filters = new Filters();

            filtersView = new FiltersModalView();

            filtersView.SortingChanged += (o, sortingChosen) =>
            {
                displayList = null;

                switch (sortingChosen)
                {
                    case SortingsEnum.ByDateAscending:
                        displayList = sortings.ByDateAscending(reservedList);
                        break;
                    case SortingsEnum.ByDateDescending:
                        displayList = sortings.ByDateDescending(reservedList);
                        break;
                    case SortingsEnum.ByTitleAscending:
                        displayList = sortings.ByTitleAscending(reservedList);
                        break;
                    case SortingsEnum.ByTitleDescending:
                        displayList = sortings.ByTitleDescending(reservedList);
                        break;
                    case SortingsEnum.None:
                        displayList = reservedList;
                        break;
                    default:
                        DisplayAlert("couldn't match any", "shit", "ok");
                        break;
                };


                WorkshopsListView.ItemsSource = displayList;

            };

            filtersView.DatesFilterChanged += (o, dates) =>
            {
                displayList = filters.FilterByDate(reservedList, dates);
                WorkshopsListView.ItemsSource = displayList;
            };

            filtersView.WeeksFilterChanged += (o, flag) =>
            {
                displayList = filters.FilterBy12weeks(reservedList, flag);
                WorkshopsListView.ItemsSource = displayList;
            };

            filtersView.PlaceFilterChanged += (o, place) =>
            {
                displayList = filters.FilterByPlace(reservedList, place.ToString());
                WorkshopsListView.ItemsSource = displayList;
            };

            filtersView.ResetSettings += (o, s) => {
                WorkshopsListView.ItemsSource = reservedList;
            };
        }


         void SearchWorkshop_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (SearchWorkshop.Text != null)
            {
                WorkshopsListView.ItemsSource = displayList.Where(x =>
                                                x.Title.IndexOf(SearchWorkshop.Text.Trim(' '), 0, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

            }
            else
            {
                WorkshopsListView.ItemsSource = reservedList;
            }
        }

        async void SortingsButton_OnClicked(object sender, System.EventArgs e)
        {
            // DisplayAlert("refreshed",sortingChosen.ToString(),"ok");

            await Navigation.PushModalAsync(filtersView);

        }
    }

}