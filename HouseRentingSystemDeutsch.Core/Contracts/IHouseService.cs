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
        Task<IEnumerable<HouseIndexServiceModel>> AllHousesListAsync();
        Task<HouseDetailsViewModel> HouseDetails(int id);
    }
}
