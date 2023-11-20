using StateProject.entities.EU.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU
{
    public class EUCitizen :  EUCitizenPublicService
    {
        EUID eUID;
        EUComune comune;
        int _salary;
        bool _asDirictForSanity;
        bool _asDirictForInsturction;
        bool _asDirictForWelfare;

        public EUCitizen(EUID eUID, int salary, bool asDirictForSanity, bool asDirictForInsturction, bool asDirictForWelfare)
        {
            this.eUID = eUID;
            _salary = salary;
            _asDirictForSanity = asDirictForSanity;
            _asDirictForInsturction = asDirictForInsturction;
            _asDirictForWelfare = asDirictForWelfare;
        }

        public EUID EUID { get => eUID; set => eUID = value; }
        public EUComune Comune { get => comune; set => comune = value; }
        public bool AsDirictForSanity { get => _asDirictForSanity; set => _asDirictForSanity = value; }
        public bool AsDirictForInsturction { get => _asDirictForInsturction; set => _asDirictForInsturction = value; }
        public int Salary { get => _salary; set => _salary = value; }
        public bool AsDirictForWelfare { get => _asDirictForWelfare; set => _asDirictForWelfare = value; }

        public override void EducationalSystem(EUID eUID)
        {
            Console.WriteLine("");
        }

        public override void HSN(EUID eUID)
        {
            Console.WriteLine("");
        }

        public override void WellfareServices()
        {
            Console.WriteLine($"EUCitizen {EUID.Name} {EUID.Surname}  Request for RdC");
            if(Salary <= 10000 || AsDirictForWelfare)
            {
                Console.WriteLine($" {EUID.Name} {EUID.Surname} has dirict at RdC");
            }
            else
            {
                Console.WriteLine($" {EUID.Name} {EUID.Surname} not has dirict at RdC");
            }
        }

      

    }
}
