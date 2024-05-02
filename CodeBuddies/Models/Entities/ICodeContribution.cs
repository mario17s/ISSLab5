namespace CodeBuddies.Models.Entities
{
    public interface ICodeContribution
    {
        DateTime ContributionDate { get; set; }
        int ContributionValue { get; set; }
        long Contributor { get; set; }
    }
}