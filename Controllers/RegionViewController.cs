using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class RegionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var regions = await _context.Regions.ToListAsync();
            return View(regions);
        }
    }
}
