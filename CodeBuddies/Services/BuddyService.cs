using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Services
{
    public class BuddyService : IBuddyService
    {
        #region Fields
        private IBuddyRepository budyRepository;
        private List<IBuddy> activeBuddies;
        private List<IBuddy> inactiveBuddies;
        #endregion

        #region Properties
        public IBuddyRepository BuddyRepository
        {
            get { return budyRepository; }
            set { budyRepository = value; }
        }
        public List<IBuddy> ActiveBuddies
        {
            get { return activeBuddies; }
            set { activeBuddies = value; }
        }
        public List<IBuddy> InactiveBuddies
        {
            get { return inactiveBuddies; }
            set { inactiveBuddies = value; }
        }
        #endregion

        public BuddyService(IBuddyRepository repo)
        {
            budyRepository = repo;
            ActiveBuddies = budyRepository.GetActiveBuddies();
            InactiveBuddies = budyRepository.GetInactiveBuddies();
        }

        #region Getters
        public List<IBuddy> GetAllBuddies()
        {
            return BuddyRepository.GetAllBuddies();
        }

        public List<IBuddy> FilterBuddies(string searchText)
        {
            List<IBuddy> filteredBuddies = new List<IBuddy>();
            foreach (var buddy in BuddyRepository.GetAllBuddies())
            {
                if (buddy.BuddyName.ToLower().Contains(searchText.ToLower()))
                {
                    filteredBuddies.Add(buddy);
                }
            }
            return filteredBuddies;
        }
        #endregion

        #region Methods
        public void RefreshData()
        {
            ActiveBuddies = BuddyRepository.GetActiveBuddies();
            InactiveBuddies = BuddyRepository.GetInactiveBuddies();
        }
        #endregion

        public IBuddy ChangeBuddyStatus(IBuddy buddy)
        {
            IBuddy changedBuddy = BuddyRepository.UpdateBuddyStatus(buddy);
            return changedBuddy;
        }
    }
}