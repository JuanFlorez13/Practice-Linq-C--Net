using System.ComponentModel.DataAnnotations;

namespace Managers.Models.Entities
{
    public class ManagersDB
    {
        [Key]
        public int id { set; get; }
        public string name { set; get; }
        public int launch { set; get; }
        public string developer { set; get; }
    }
}
