using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    //Esta clase por defecto viene privada, no hay un access modifier = termino usado en entrevistas
    public  class Group
    {
        public int GroupId { get; set; }

        public string? GroupName { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Focus> Foci { get; set; } = new List<Focus>();

        public virtual ICollection<GroupInvitation> GroupInvitations { get; set; } = new List<GroupInvitation>();

        public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>();
    }
}
