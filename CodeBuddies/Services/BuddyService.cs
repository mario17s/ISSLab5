using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services
{
    public class BuddyService : IBuddyService
    {
        private IBuddyRepository budyRepository;

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

        public void RefreshData()
        {
            ActiveBuddies = BuddyRepository.GetActiveBuddies();
            InactiveBuddies = BuddyRepository.GetInactiveBuddies();
        }

        public IBuddy ChangeBuddyStatus(IBuddy buddy)
        {
            IBuddy changedBuddy = BuddyRepository.UpdateBuddyStatus(buddy);
            return changedBuddy;
        }
    }
}
