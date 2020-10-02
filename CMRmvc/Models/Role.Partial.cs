using Microsoft.AspNetCore.Identity;

namespace CMRmvc.Models
{
    public partial class Role : IdentityRole<long>
    {

        public override string Name { get; set; }
        public bool IsActive { get; set; }
    
    }
}
