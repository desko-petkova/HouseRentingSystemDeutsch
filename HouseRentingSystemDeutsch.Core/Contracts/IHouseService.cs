using HouseRentingSystemDeutsch.Core.Models.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystemDeutsch.Core.Contracts
{
    public interface IHouseService
    {
        // Task<IEnumerable<HouseIndexServiceModel>> AllHousesListAsync();
        //  Task<HouseDetailsViewModel> HouseDetails(int id);
        Task<IEnumerable<HouseCategoryServiceModel>> AllHouseCategoryAsync();
        Task<IEnumerable<string>> AllCategoriesNames();
        Task<HouseQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

    }
}
