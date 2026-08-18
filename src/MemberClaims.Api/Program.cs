
using MemberClaims.Api.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        application = "Member Claims API",
        version = "1.0",
        status = "Running"
    });
});

app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        status = "Healthy",
        timestamp = DateTime.UtcNow
    });
});
var claims = new List<Claim>
{
    new Claim
    {
        ClaimId = "CLM-10001",
        MemberId = "MEM-12345",
        ClaimType = "Hospital",
        Amount = 850.00m,
        Status = "Submitted"
    },
    new Claim
    {
        ClaimId = "CLM-10002",
        MemberId = "MEM-67890",
        ClaimType = "Dental",
        Amount = 220.50m,
        Status = "Approved"
    }
};

app.MapGet("/api/claims", () =>
{
    return Results.Ok(claims);
});
app.MapGet("/api/claims/{claimId}", (string claimId) =>
{
    var claim = claims.FirstOrDefault(c =>
        c.ClaimId.Equals(claimId, StringComparison.OrdinalIgnoreCase));

    if (claim is null)
    {
        return Results.NotFound(new
        {
            message = $"Claim {claimId} was not found"
        });
    }

    return Results.Ok(claim);
});
app.MapPost("/api/claims", (Claim newClaim) =>
{
    var existingClaim = claims.FirstOrDefault(c =>
        c.ClaimId.Equals(newClaim.ClaimId, StringComparison.OrdinalIgnoreCase));

    if (existingClaim is not null)
    {
        return Results.Conflict(new
        {
            message = $"Claim {newClaim.ClaimId} already exists"
        });
    }

    newClaim.Status = "Submitted";
    newClaim.SubmittedDate = DateTime.UtcNow;

    claims.Add(newClaim);

    return Results.Created($"/api/claims/{newClaim.ClaimId}", newClaim);
});
app.Run();