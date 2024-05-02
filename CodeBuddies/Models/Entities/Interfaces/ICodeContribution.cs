namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ICodeContribution
    {
        DateTime ContributionDate { get; set; }
        int ContributionValue { get; set; }
        long Contributor { get; set; }
    }
}