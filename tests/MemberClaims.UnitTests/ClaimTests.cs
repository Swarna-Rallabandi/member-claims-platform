using MemberClaims.Api.Models;

namespace MemberClaims.UnitTests;

public class ClaimTests
{
    [Fact]
    public void Claim_WithValidAmount_ShouldHavePositiveAmount()
    {
        var claim = new Claim
        {
            ClaimId = "CLM-20001",
            MemberId = "MEM-10001",
            ClaimType = "Dental",
            Amount = -500.00m
        };

        Assert.True(claim.Amount > 0);
    }
}