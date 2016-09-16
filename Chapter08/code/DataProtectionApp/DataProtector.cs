using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProtectionApp
{
    public class DataProtector
    {
        IDataProtector _protector;
        public DataProtector(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Company.Project.v1");
        }

        public void ProtectAndRelease()
        {
            Console.Write("Enter input: ");
            string userToken = Console.ReadLine();

            string protectedToken = _protector.Protect(userToken);
            Console.WriteLine($"Protected token: {protectedToken}");

            string unprotectedToken = _protector.Unprotect(protectedToken);
            Console.WriteLine($"Unprotected result: {unprotectedToken}");

            Console.ReadKey();
        }

    }
}
