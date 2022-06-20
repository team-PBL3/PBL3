using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public enum ActionType
    {
        Create,
        Update,
        Delete,
        Block
    }
    public enum ImpactedObjectType
    { 
        Category,
        Trademark,
        Product,
        Member
    }    
    public class Admin_Action_History
    {
        public Admin_Action_History()
        {

        }
        [Key]
        public int id { get; set; }
        [Required]
        public int CreateBy { get; set; }
        public int EditBy { get; set; }
        [Required]
        public ActionType actionType { get; set; }
        [Required]
        public ImpactedObjectType impactedObjectType { get; set; }
        [Required]
        public int impactedObjectTypeId { get; set; }
        public DateTime ActionTime { get; set; }
        public virtual User user { get; set; }
    }

}