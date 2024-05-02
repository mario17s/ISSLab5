using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.Views;
using CodeBuddies.Views.Windows;
using SessionsModalWindow = CodeBuddies.Views.Windows.SessionsModalWindow;

namespace CodeBuddies.ViewModels
{
    public class BuddiesListViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<IBuddy> buddies;
        private IBuddyService service;
        private Buddy selectedBuddy;
        private string searchText;

        #endregion

        #region Properties
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
        public ICommand OpenPopupCommand { get; }
        public IBuddyService Service
        {
            get { return service; }
            set { service = value; }
        }
        public Buddy SelectedBuddy
        {
            get => selectedBuddy;
            set
            {
                selectedBuddy = value;
                OnPropertyChanged();
            }
        }
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
        #endregion

        #region Lambda Commands
        public RelayCommand<IBuddy> OpenModalCommand => new RelayCommand<IBuddy>(_ => OpenModal());
        #endregion

        public BuddiesListViewModel()
        {
            IBuddyRepository repo = new BuddyRepository();
            service = new BuddyService(repo);
            GlobalEvents.BuddyPinned += HandleBuddyPinned;
            LoadBuddies();
        }

        #region Methods
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
        #endregion
    }
}