using Microsoft.AspNetCore.Mvc;
using RunForCover.DataAcess.Repository.IRepository;
using RunForCover.Models;

namespace RunForCoverWeb.Controllers;
[Area("Admin")]
public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        IEnumerable<CoverType> obj = _unitOfWork.CoverType.GetAll();
        return View(obj);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var coverType = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);

        if (coverType == null)
        {
            return NotFound();
        }

        return View(coverType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover updated successfully!";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover created successfully!";
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
        var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);

        if (coverTypeFromDb == null)
        {
            return NotFound();
        }
        return View(coverTypeFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(CoverType obj)
    {
        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Cover Type deleted successfully!";
        return RedirectToAction("Index");
    }
}

