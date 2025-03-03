using HouseRentingSystemDeutch.Data;
using HouseRentingSystemDeutsch.Core.Contracts;
using HouseRentingSystemDeutsch.Core.Models.House;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystemDeutsch.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly ApplicationDbContext data;
        public HouseService(ApplicationDbContext _data)
        {
            data = _data;
        }
        //Наименованията на категориите, които ще се показват в падащото меню 
        //на фълтъра по категории
        public async Task<IEnumerable<HouseCategoryServiceModel>> AllHouseCategoryAsync()
        {
            return await data.Categories
                .Select(c => new HouseCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(c=>c.Name).ToListAsync();
        } 
        public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var housesToShow = data.Houses.AsNoTracking().AsQueryable();
            if (category != null)
            {
                housesToShow = housesToShow
                    .Where(h => h.Category.Name == category);
            }
            if(searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                housesToShow = housesToShow
                    .Where(h=>h.Title.ToLower().Contains(normalizedSearchTerm)||
                    h.Address.ToLower().Contains(normalizedSearchTerm)||
                    h.Description.ToLower().Contains(normalizedSearchTerm));
            }
            housesToShow = sorting switch
            {
               HouseSorting.Price => housesToShow
               .OrderBy(h=>h.PricePerMonth),
               HouseSorting.NotRentedFirst =>housesToShow
               .OrderBy(h=>h.RenterId !=null)
               .ThenByDescending(h=>h.Id),
               _=>housesToShow.OrderByDescending(h=>h.Id)
            };
            var houses =await housesToShow
                .Skip((currentPage-1)*housesPerPage)
                .Take(housesPerPage)
                .Select(h=> new HouseServiceModel()
                {
                    Id = h.Id,
                    Address=h.Address,
                    ImageUrl =h.ImageUrl,
                    PricePerMonth=h.PricePerMonth,
                    Title = h.Title,
                    IsRented = h.RenterId !=null
                })
                .ToListAsync();
            int totalHouses = await housesToShow.CountAsync();
            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHouseCount = totalHouses
            };
        }


       




        //public async Task<IEnumerable<HouseIndexServiceModel>> AllHousesListAsync()
        //{
        //    return await data.Houses
        //       .OrderByDescending(h => h.Id)
        //       .Select(h => new HouseIndexServiceModel()
        //       {
        //           Id = h.Id,
        //           Title = h.Title,
        //           ImageUrl = h.ImageUrl
        //       })
        //       .ToListAsync();
        //}

        //public async Task<HouseDetailsViewModel> HouseDetails(int id)
        //{
        //    var house = await data.Houses
        //    .Where(h => h.Id == id)
        //    .Select(h => new HouseDetailsViewModel
        //    {
        //        Id = h.Id,
        //        Title = h.Title,
        //        Description = h.Description,
        //        PricePerMonth = h.PricePerMonth,
        //        ImageUrl = h.ImageUrl,
        //        Address = h.Address,

        //    }).FirstOrDefaultAsync();

        //    if (house == null)
        //    {
        //        throw new Exception("House not found");
        //    }
        //    return house;
        //}
    }
}
