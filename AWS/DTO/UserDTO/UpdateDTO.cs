using System.ComponentModel.DataAnnotations;

namespace backend_not_clear.DTO.UserDTO
{
    public class UpdateDTO
    {
        //public string UserID { get; set; } = string.Empty;
        public string? imgURL { get; set; }
        public string? fullName { get; set; } = string.Empty;

        public string? gender { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public decimal? Money { get; set; }
        public DateTime? dateOfBird { get; set; }
        //public string? RoleID { get; set; }
     
    }
}
