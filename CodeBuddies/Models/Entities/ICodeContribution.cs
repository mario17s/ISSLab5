
namespace CodeBuddies.Models.Entities
{
    internal interface ICodeContribution
    {
        DateTime ContributionDate { get; set; }
        int ContributionValue { get; set; }
        long Contributor { get; set; }
    }
}