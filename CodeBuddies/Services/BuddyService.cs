using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Services
{
    public class BuddyService : IBuddyService
    {
        IBuddyRepository budyRepository;

        public IBuddyRepository BuddyRepository
        {
            get { return budyRepository; }
            set { budyRepository = value; }
        }

        private List<IBuddy> activeBuddies;

        public List<IBuddy> ActiveBuddies
        {
            get { return activeBuddies; }
            set { activeBuddies = value; }
        }

        private List<IBuddy> inactiveBuddies;

        public List<IBuddy> InactiveBuddies
        {
            get { return inactiveBuddies; }
            set { inactiveBuddies = value; }
        }

        public BuddyService(IBuddyRepository repo)
        {
            budyRepository = repo;
            ActiveBuddies = budyRepository.GetActiveBuddies();
            InactiveBuddies = budyRepository.GetInactiveBuddies();
        }

        public List<IBuddy> getAllBuddies()
        {
            return BuddyRepository.GetAllBuddies();
        }

        public List<IBuddy> filterBuddies(string searchText)
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

        public void refreshData()
        {
            ActiveBuddies = BuddyRepository.GetActiveBuddies();
            InactiveBuddies = BuddyRepository.GetInactiveBuddies();
        }

        public IBuddy changeBuddyStatus(IBuddy buddy)
        {
            IBuddy changedBuddy = BuddyRepository.UpdateBuddyStatus(buddy);
            return changedBuddy;
        }
    }
}
