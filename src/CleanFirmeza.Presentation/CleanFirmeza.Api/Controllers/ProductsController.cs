namespace CleanFirmeza.Api.Controllers;


using CleanFirmeza.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("UploadExcel")]
    public async Task<IActionResult> UploadExcel(Stream file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Archivo no válido");

        var result = await _productService.ImportFromExcelAsync(file);

        return Ok(result);
    }
}