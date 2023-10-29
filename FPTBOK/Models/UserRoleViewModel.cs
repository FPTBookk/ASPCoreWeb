using Microsoft.AspNetCore.Identity;
namespace FPTBOK.Models
{
    public class UserRoleViewModel
    {
        public IdentityUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}