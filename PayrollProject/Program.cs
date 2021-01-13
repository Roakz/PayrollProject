using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //This is a class
    class Staff
    {
        // Fields
        private float hourlyRate;
        private int hWorked;

        // Manual property
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if(hWorked > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }

        // Auto implemeted properties
        public float TotalPay { get; protected set; }
        public float BasicPay {get; private set; }
        public string NameOfStaff { get; private set; }

        //Constructor
        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        //Public virtual method with void return value
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        //ToString method override.
        public override string ToString()
        {
            return $"NameOfStaff: {NameOfStaff}, BasicPay: {BasicPay}, TotalPay: {TotalPay}, hWorked: {hWorked}, hourlyRate: {hourlyRate}";
        }

    }

    // This class inherits from the staff class above. 
    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }

        /* The constructor accepts its own parameter name but passes the 
        managerHourlyRate in as the expected rate parameter.This will satisfy the Staff classes constructor parameter requirements.*
        and ensure that the managers hourly rate is used for the calculate pay function.*/
        public Manager(string name) : base(name, managerHourlyRate) { }
    }
}
