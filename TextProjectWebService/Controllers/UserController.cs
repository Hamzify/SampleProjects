using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TextProjectWebService.Context;
using TextProjectWebService.Model;

namespace TextProjectWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "Get")]
        public async Task<IActionResult> GerData()
        {
            try
            {
                var users = await _context.UserModels.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        [HttpPost(Name = "Add")]
        public async Task<IActionResult> AddData(AddUserVM data)
        {
            try
            {
                var model = new UserModel()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    Age = data.Age,
                };
                await _context.UserModels.AddAsync(model);
                await _context.SaveChangesAsync();
                return Ok("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var user = await _context.UserModels.Where(x=>x.Name.Contains(name)).ToListAsync();

                return Ok(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        [HttpDelete(Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var users = await _context.UserModels.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
