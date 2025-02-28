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
        public async Task<IEnumerable<HouseIndexServiceModel>> AllHousesListAsync()
        {
            return await data.Houses
               .OrderByDescending(h => h.Id)
               .Select(h => new HouseIndexServiceModel()
               {
                   Id = h.Id,
                   Title = h.Title,
                   ImageUrl = h.ImageUrl
               })
               .ToListAsync();
        }

        public async Task<HouseDetailsViewModel> HouseDetails(int id)
        {
            var house = await data.Houses
            .Where(h => h.Id == id)
            .Select(h => new HouseDetailsViewModel
            {
                Id = h.Id,
                Title = h.Title,
                Description = h.Description,
                PricePerMonth = h.PricePerMonth,
                ImageUrl = h.ImageUrl,
                Address = h.Address,

            }).FirstOrDefaultAsync();

            if (house == null)
            {
                throw new Exception("House not found");
            }
            return house;
        }
    }
}
