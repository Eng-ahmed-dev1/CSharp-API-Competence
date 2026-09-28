using ECommerec.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ProductLessThan2000Attribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult &&
            objectResult.Value is IEnumerable<ProductReadDto> products)
        {
            objectResult.Value = products.Where(p => p.Price < 2000);
        }
    }
}