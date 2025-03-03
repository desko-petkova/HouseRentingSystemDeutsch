using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HouseRentingSystemDeutsch.Core.Contracts;
using HouseRentingSystemDeutsch.Core.Models.House;
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

        [AllowAnonymous, HttpGet]
        public async Task<IActionResult> All([FromQuery]HouseQueryServiceModel query)
        {
            var queryResult = await house.AllAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.HousesPerPage);
            query.TotalHouseCount = queryResult.TotalHouseCount;
            query.Houses = queryResult.Houses;
            query.Categories = await house.AllCategoriesNames();
            return View(query);
        }



        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IActionResult> All()
        //{
        //    var model = await house.AllHousesListAsync();
        //    return View(model);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var model = await house.HouseDetails(id);
        //    return View(model);

        //}
    }
}
