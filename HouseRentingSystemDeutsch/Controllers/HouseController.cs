using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HouseRentingSystemDeutsch.Core.Contracts;
namespace HouseRentingSystemDeutch.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService house;
        public HouseController(IHouseService _house)
        {
            house = _house;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await house.AllHousesListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await house.HouseDetails(id);
            return View(model);

        }
    }
}
