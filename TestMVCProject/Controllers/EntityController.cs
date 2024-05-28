using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestMVCProject.Data;
using TestMVCProject.Models;
using TestMVCProject.Models.Domain;

namespace TestMVCProject.Controllers
{
    public class EntityController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EntityController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _context.EntityModels.ToListAsync();
                return View(data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEntityDataVM data)
        {
            try
            {
                var model = new EntityModel()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    Age = data.Age
                };
                await _context.EntityModels.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var userInfo = await _context.EntityModels.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (userInfo is null)
                    return RedirectToAction("Index");
                var data = new ViewEntityDataVM()
                {
                    Name = userInfo.Name,
                    Surname = userInfo.Surname,
                    Age = userInfo.Age
                };
                return View(data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EntityModel data)
        {
            try
            {
                var userInfo = await _context.EntityModels.FirstOrDefaultAsync(x => x.Id.Equals(data.Id));
                if (userInfo is null)
                    throw new Exception($"Data not found.");
                 _context.EntityModels.Remove(userInfo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        } 
        [HttpPost]
        public async Task<IActionResult> Search(string Name)
        {
            try
            {
                Name = "Hamza";
                var userInfo = await _context.EntityModels.Where(x => x.Name.Contains(Name)).ToListAsync();
                if (userInfo is null)
                    throw new Exception($"Data not found.");
                return View(userInfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        
        public IActionResult Services()
        {
            return View();
        }

    }
}
