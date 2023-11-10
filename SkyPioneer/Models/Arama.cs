using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class Arama
    {
        public int From { get; set; }
        public int To { get; set; }
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

    }
}
