using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystemDeutsch.Infrastructure.Constants.DataConstants;
using static HouseRentingSystemDeutsch.Core.Constants.MessageConstants;

namespace HouseRentingSystemDeutsch.Core.Models.House
{
    public class HouseFormViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLength,
             MinimumLength = AddressMinLength,
             ErrorMessage = LengthMessage)]
        public string Address { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
           MinimumLength = DescriptionMinLength,
           ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PricePerMonthMinimum,
             PricePerMonthMaximum,
             ErrorMessage = PriceMessage)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } =
            new List<HouseCategoryServiceModel>();
    }
}
