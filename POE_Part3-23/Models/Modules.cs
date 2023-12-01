using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace POE_Part3_23.Models
{
    public class Modules
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int ClassHours { get; set; }

        public int SelfStudyHoursPerWeek { get; set; }

        public int SemWeeks { get; set; }

        public DateTime StartDate { get; set; }

        //Reminder 
        [Display(Name = "Planned Day")]
        public DayOfWeek PlannedDay { get; set; }

        public Modules()
        {

            
        }

        public class MyData
        {
            // Other properties

            public string Id { get; set; }

            [ForeignKey("UserId")]
            public UserLogin User { get; set; }
        }

    }

    public static class ModulesExtensions
    {
        public static void CalculateSelfStudyHoursPerWeek(this Modules module)
        {
            module.SelfStudyHoursPerWeek = (module.Credits * 10) / module.SemWeeks - module.ClassHours;
        }
    }

}
