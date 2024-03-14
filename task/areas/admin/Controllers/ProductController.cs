using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.areas.admin.ViewModel;
using WebApplication4.contexts;
using WebApplication4.Models;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly ProniaDbContext _context;

    public ProductController(ProniaDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]


    public ActionResult Create(product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public ActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public ActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
