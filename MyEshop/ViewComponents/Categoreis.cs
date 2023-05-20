using Microsoft.AspNetCore.Mvc;

namespace MyEshop
{
    public class Categoreis :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Ctegories"));
        }
    }
}
