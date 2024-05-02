using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Services;
using CodeBuddies.Views;
using CodeBuddies.Views.Windows;
using SessionsModalWindow = CodeBuddies.Views.Windows.SessionsModalWindow;

namespace CodeBuddies.ViewModels
{
    public class BuddiesListViewModel : ViewModelBase
    {
        private ObservableCollection<IBuddy> buddies;
        public ICommand OpenPopupCommand { get; }
        private IBuddyService service;

        public IBuddyService Service
        {
            get { return service; }
            set { service = value; }
        }

        public RelayCommand<IBuddy> OpenModalCommand => new RelayCommand<IBuddy>(_ => OpenModal());

        public ObservableCollection<IBuddy> Buddies
        {
            get
            {
                return buddies;
            }
            set
            {
                buddies = value;
                OnPropertyChanged();
            }
        }

        private string searchText;

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                FilterBuddies();
                OnPropertyChanged();
            }
        }

        public BuddiesListViewModel()
        {
            IBuddyRepository repo = new BuddyRepository();
            service = new BuddyService(repo);
            GlobalEvents.BuddyPinned += HandleBuddyPinned;
            LoadBuddies();
        }

        private void FilterBuddies()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadBuddies();
            }
            else
            {
                Buddies = new ObservableCollection<IBuddy>(service.FilterBuddies(SearchText));
            }
        }

        private void LoadBuddies()
        {
            List<IBuddy> buddies = service.GetAllBuddies();
            Buddies = new ObservableCollection<IBuddy>(buddies);
        }

        private Buddy selectedBuddy;
        public Buddy SelectedBuddy
        {
            get => selectedBuddy;
            set
            {
                selectedBuddy = value;
                OnPropertyChanged();
            }
        }

        private void OpenModal()
        {
            Console.WriteLine("test");
            if (SelectedBuddy != null)
            {
                var modalWindow = new BuddyModalWindow(SelectedBuddy);
                modalWindow.Owner = Application.Current.MainWindow; // Ensure it's modal to the main window

                bool? dialogResult = modalWindow.ShowDialog();

                if (dialogResult == true)
                {
                    Debug.WriteLine("Action pressed! \n");
                }
                else
                {
                    Debug.WriteLine("Close pressed!");
                    // Handle actions if Cancelled or closed
                }
            }
        }

        public void HandleBuddyPinned()
        {
            buddies.Remove(selectedBuddy);
            buddies.Insert(0, selectedBuddy);
        }
    }
}