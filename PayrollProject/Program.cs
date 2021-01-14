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

        //Overriding the Bases Calculate pay method to include a potential manager allowance.
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if(HoursWorked > 160)
            {
                TotalPay += Allowance;
            }
        }

        // Overriding the ToString method to include the allowance amount.
        public override string ToString()
        {
            return base.ToString() + $", Allowance: {Allowance}";
        }
    }

    //The admin class also inherits from the Staff class and has  the additional fields of overtimeRate and adminHourlyRate.
    //The Calculate pay method overrides the base again using these fields to calculate an admins pay.
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Overtime: {Overtime}";
        }

    }
}
