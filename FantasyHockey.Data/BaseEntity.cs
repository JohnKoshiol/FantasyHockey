using System;

namespace FantasyHockey.Data
{
    public class BaseEntity
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
