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
    }
}
