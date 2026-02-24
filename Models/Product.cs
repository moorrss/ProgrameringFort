namespace Simpel_api.Models;

public record Product
{
    public int Id { get; set; }
    public string ProdutName { get; set; }
    public decimal Price { get; set; }
}
