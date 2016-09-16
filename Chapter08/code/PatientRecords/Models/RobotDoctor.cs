using System.ComponentModel.DataAnnotations;

namespace PatientRecords.Models
{
    public class RobotDoctor
    {
        [Display(Name = "Robot Doctor ID")]
        public int RobotDoctorId { get; set; }

        [Display(Name = "Model Number")]
        public int ModelNumber { get; set; }

        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }
    }

}
