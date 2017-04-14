using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //creating static fields to get rid of magic numbers in the Min18YearsIfAMember class ex: MembershipTypeId ==0 or 1
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}