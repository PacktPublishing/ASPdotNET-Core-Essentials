using Microsoft.AspNetCore.Mvc;
using PatientRecords.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Controllers
{
    public class HospitalController : Controller
    {
        public IApptService ApptService { get; set; }
        public HospitalController(IApptService apptService)
        {
            ApptService = apptService;
        }

        public string ProcessAppointment()
        {
            bool isSuccess = ApptService.ScheduleAppt();
            if (isSuccess)
                return "Success!";
            else
                return "Failed...";
        }

    }
}
