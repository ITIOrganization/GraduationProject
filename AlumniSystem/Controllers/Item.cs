using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniSystem.Controllers
{
    [NotMapped]
    public class Item
    {
        public string City { get; set; }
    }
}