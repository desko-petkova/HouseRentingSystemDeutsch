using System.ComponentModel.DataAnnotations;
using static HouseRentingSystemDeutsch.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystemDeutsch.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [MaxLength(PhoneNumberMaxLength), MinLength(PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
