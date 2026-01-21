namespace CleanFirmeza.Application.DTOs.Import;


public class ProductExcelRowDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}