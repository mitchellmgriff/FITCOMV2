using Microsoft.AspNetCore.Components;
using WebStore.Models;

namespace WebStore.Pages.App
{
    public partial class ProductCard
    {
        [Parameter]
        public Product? Product { get; set; }
    }
}
