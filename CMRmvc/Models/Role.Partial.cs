using Microsoft.AspNetCore.Identity;

namespace CMRmvc.Models
{
    public partial class Role : IdentityRole<long>
    {
        public bool IsActive { get; set; }
    
    }
}
