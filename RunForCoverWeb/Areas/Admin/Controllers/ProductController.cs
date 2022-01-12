using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RunForCover.DataAcess.Repository.IRepository;
using RunForCover.Models;
using RunForCover.Models.ViewModels;

namespace RunForCoverWeb.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        IEnumerable<Product> obj = _unitOfWork.Product.GetAll();
        return View(obj);
    }

    public IActionResult Upsert(int? id)
    {
        ProductViewModel productViewModel = new()
        {
            Product = new(),
            CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }),
            CoverTypeList = _unitOfWork.CoverType.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
        };

        if (id == null || id == 0)
        {
            return View(productViewModel);
        }
        else
        {

        }
        
        return View(productViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Product obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover updated successfully!";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var coverTypeFromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);

        if (coverTypeFromDb == null)
        {
            return NotFound();
        }
        return View(coverTypeFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Product obj)
    {
        _unitOfWork.Product.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Cover Type deleted successfully!";
        return RedirectToAction("Index");
    }
}

