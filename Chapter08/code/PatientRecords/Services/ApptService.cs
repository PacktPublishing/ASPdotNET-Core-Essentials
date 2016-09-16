using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Services
{
    public class ApptService: IApptService
    {
        public bool ScheduleAppt()
        {
            bool isSuccess = false;
            // scheduling code goes here
            isSuccess = true;
            return isSuccess;
        }
    }
}
