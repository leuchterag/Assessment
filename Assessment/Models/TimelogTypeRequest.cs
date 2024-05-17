using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class TimelogTypeRequest
    {
        public int timelogTypeId { get; set; }

        // Timelog Type muss vorhanden sein
        [Required(ErrorMessage = "Timelog Type muss vorhanden sein")]
        [StringLength(100, ErrorMessage = "Timelog Type darf nicht länger als 100 Zeichen sein")]
        public string timelogType { get; set; }

        // Budget muss grösser oder gleich 0 sein
        [Range(0, double.MaxValue, ErrorMessage = "Das Zeitbudget darf nicht negativ ")]
        public double budget { get; set; }
    }
}