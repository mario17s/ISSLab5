using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.Views.UserControls;

namespace CodeBuddies.ViewModels
{
    public class ActiveInactiveBuddiesListViewModel : ViewModelBase
    {
        #region Fields
        private IBuddyService buddyService;
        private ObservableCollection<IBuddy> active = new ObservableCollection<IBuddy>();
        private ObservableCollection<IBuddy> inactive = new ObservableCollection<IBuddy>();
        private ObservableCollection<IBuddy> allBuddies = new ObservableCollection<IBuddy>();
        #endregion

        #region Properties
        public IBuddyService BuddyService
        {
            get { return buddyService; }
            set { buddyService = value; }
        }
        public ObservableCollection<IBuddy> Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IBuddy> Inactive
        {
            get
            {
                return inactive;
            }
            set
            {
                inactive = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IBuddy> AllBuddies
        {
            get
            {
                return allBuddies;
            }
            set
            {
                allBuddies = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ActiveInactiveBuddiesListViewModel()
        {
            IBuddyRepository repo = new BuddyRepository();
            BuddyService = new BuddyService(repo);
            Active = new ObservableCollection<IBuddy>(BuddyService.ActiveBuddies);
            Inactive = new ObservableCollection<IBuddy>(BuddyService.InactiveBuddies);
        }

        public void Refresh()
        {
            BuddyService.RefreshData();
            OnPropertyChanged("ActiveBuddies");
            OnPropertyChanged("InactiveBuddies");
            OnPropertyChanged("Active");
            OnPropertyChanged("Inactive");
        }

        public void UpdateBuddyStatus(Buddy buddy)
        {
            BuddyService.ChangeBuddyStatus(buddy);
            Refresh();
        }
    }
}
