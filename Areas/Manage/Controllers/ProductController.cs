

namespace ExamWebApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env = null)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Table()
        {
            ViewData["Products"] = await _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Images)
                .ToListAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            if(createProductVM == null) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View();
            }

            Product newProduct = new()
            {
                Title = createProductVM.Title,
                Description = createProductVM.Description,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Images = new List<ProductImage>()
            };

            if(createProductVM.Images != null)
            {
                foreach (var item in createProductVM.Images)
                {
                    if (!item.CheckType("image/"))
                    {
                        ModelState.AddModelError("Images", "This file is not image type!");
                    }
                    if (!item.CheckLength(3000000))
                    {
                        ModelState.AddModelError("Images", "File size must be not over than 2MB");
                    }

                    if(!ModelState.IsValid)
                    {
                        return View();
                    }

                    ProductImage image = new()
                    {
                        Product = newProduct,
                        ImgUrl = item.Upload(_env.WebRootPath, @"\Upload\ProductImages\", newProduct.Id),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    };

                    await _context.ProductImages.AddAsync(image);
                }
            }

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Table));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null && Id < 0) return BadRequest();
            Product oldProduct = await _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (oldProduct == null) return NotFound();

            UpdateProductVM updateProductVM = new UpdateProductVM()
            {
                Title = oldProduct.Title,
                Description = oldProduct.Description,
            };

            return View(updateProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM updateProductVM)
        {
            if (updateProductVM.Id == null && updateProductVM.Id < 0) return BadRequest();
            Product oldProduct = await _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == updateProductVM.Id);
            if (oldProduct == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            oldProduct.UpdatedDate = DateTime.Now;
            oldProduct.CreatedDate = oldProduct.CreatedDate;
            oldProduct.Title = updateProductVM.Title;
            oldProduct.Description = updateProductVM.Description;
            oldProduct.Images = new List<ProductImage>();

            if(updateProductVM.Images != null)
            {
                foreach (var item in updateProductVM.Images)
                {
                    if (!item.CheckType("image/"))
                    {
                        ModelState.AddModelError("File", "This file is not image type!");
                    }
                    if (!item.CheckLength(3000000))
                    {
                        ModelState.AddModelError("File", "File size must be not over than 2MB");
                    }

                    if (!ModelState.IsValid)
                    {
                        return View();
                    }


                    ProductImage image = new()
                    {
                        Product = oldProduct,
                        ImgUrl = item.Upload(_env.WebRootPath, @"\Upload\ProductImages\", oldProduct.Id),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    };

                    oldProduct.Images.Add(image);
                }
            }

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Table));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            if(Id < 0 && Id == null) return BadRequest();
            Product oldProduct = await _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == Id);
            if(oldProduct == null) return NotFound();

            return View(oldProduct);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 0 && Id == null) return BadRequest();
            Product oldProduct = await _context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (oldProduct == null) return NotFound();

            oldProduct.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Table");
        }
    }
}
