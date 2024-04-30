using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Models.Entities;
using System.Collections.ObjectModel;
using CodeBuddies.Services;
using CodeBuddies.Views.UserControls;

namespace CodeBuddies.ViewModels
{
    public class ActiveInactiveBuddiesListViewModel : ViewModelBase
    {
        IBuddyService buddyService;

        public IBuddyService BuddyService
        {
            get { return buddyService; }
            set { buddyService = value; }
        }

        private ObservableCollection<IBuddy> active = new ObservableCollection<IBuddy>();

        public ObservableCollection<IBuddy> Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged(); }
        }

        private ObservableCollection<IBuddy> inactive = new ObservableCollection<IBuddy>();

        public ObservableCollection<IBuddy> Inactive
        {
            get { return inactive; }
            set { inactive = value; OnPropertyChanged(); }
        }

        private ObservableCollection<IBuddy> allBuddies = new ObservableCollection<IBuddy>();

        public ObservableCollection<IBuddy> AllBuddies
        {
            get { return allBuddies; }
            set { allBuddies = value; OnPropertyChanged(); }
        }
        
        public ActiveInactiveBuddiesListViewModel()
        {
            IBuddyRepository repo = new BuddyRepository();
            BuddyService = new BuddyService(repo);
            Active = new ObservableCollection<IBuddy>(BuddyService.ActiveBuddies);
            Inactive = new ObservableCollection<IBuddy>(BuddyService.InactiveBuddies);
        }

        public void Refresh()
        {
            BuddyService.refreshData();
            OnPropertyChanged("ActiveBuddies");
            OnPropertyChanged("InactiveBuddies");
            OnPropertyChanged("Active");
            OnPropertyChanged("Inactive");
        }

        public void UpdateBuddyStatus(Buddy buddy)
        {
            BuddyService.changeBuddyStatus(buddy);
            Refresh();
        }
    }
}
