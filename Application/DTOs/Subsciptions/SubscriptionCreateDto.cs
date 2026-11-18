namespace Application.DTOs.Subsciptions;

public class SubscriptionCreateDto
{
    public int CompanyId { get; set; }
    public string Plantype { get; set; } = null!;
    public int Mealsperday { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Isactive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
