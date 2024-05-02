using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class CodeContribution : ICodeContribution
    {
        #region Fields
        private long contributor;
        private DateTime contributionDate;
        private int contributionValue;
        #endregion

        #region Properties
        public long Contributor
        {
            get { return contributor; }
            set { contributor = value; }
        }
        public DateTime ContributionDate
        {
            get { return contributionDate; }
            set { contributionDate = value; }
        }
        public int ContributionValue
        {
            get { return contributionValue; }
            set { contributionValue = value; }
        }
        #endregion

        public CodeContribution(long contributor, DateTime date, int contributionValue)
        {
            Contributor = contributor;
            ContributionDate = date;
            ContributionValue = contributionValue;
        }
    }
}
