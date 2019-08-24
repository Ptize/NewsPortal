using System.ComponentModel.DataAnnotations;

namespace NewsPortal.Models.VeiwModels
{
    public class EditUserVM
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
