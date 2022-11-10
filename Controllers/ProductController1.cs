using INCREDIBLE_TECH__LTD_.Data.Services;
using INCREDIBLE_TECH__LTD_.Data.Static;
using INCREDIBLE_TECH__LTD_.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncredibleTech10_LTD.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    
    public class ProductController1 : Controller
    {
        private readonly IProductService _service;
        public ProductController1(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Item, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Specification, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("NotFound", allMovies);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Logo,Item,Category,Specification,Price")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Products/Details/id
        public async Task<IActionResult> Details(int ProductId)
        {
            var ProductDetails = await _service.GetByIdAsync(ProductId);

            if (ProductDetails == null) return View("Details");
            return View(ProductDetails);

        }

        public async Task<IActionResult> Edit(int ProductId)
        {
            var ProductDetails = await _service.GetByIdAsync(ProductId);

            if (ProductDetails == null) return View("Not Found");
            return View(ProductDetails);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int ProductId, [Bind("ProductId,Logo,Item,Category,Specification,Price")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(ProductId, product);
            return RedirectToAction(nameof(Index));
        }

    }

}