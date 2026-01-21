using CleanFirmeza.Application.DTOs.Import;
using CleanFirmeza.Application.Interfaces.Import;

namespace CleanFirmeza.Application.Services.import;

using ClosedXML.Excel;

public class ProductExcelMapper : IProductExcelMapper
{
    public IReadOnlyDictionary<int, string> ExpectedColumns { get; } =
        new Dictionary<int, string>
        {
            { 1, "Name" },
            { 2, "Price" },
            { 3, "Stock" }
        };

    public ProductExcelRowDto MapRow(IXLRow row, int rowNumber)
    {
        try
        {
            return new ProductExcelRowDto
            {
                Name = row.Cell(1).GetString(),
                Price = row.Cell(2).GetValue<decimal>(),
                Stock = row.Cell(3).GetValue<int>()
            };
        }
        catch
        {
            throw new Exception($"Error de formato en fila {rowNumber}");
        }
    }

    public Task<List<ProductExcelRowDto>> ImportFromExcelAsync(Stream file)
    {
        throw new NotImplementedException();
    }
}

