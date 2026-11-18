namespace Application.DTOs.Orders;

public class OrderResponseDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
