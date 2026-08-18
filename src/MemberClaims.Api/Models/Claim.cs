namespace MemberClaims.Api.Models;

public class Claim
{
    public string ClaimId { get; set; } = string.Empty;
    public string MemberId { get; set; } = string.Empty;
    public string ClaimType { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Submitted";
    public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;
}