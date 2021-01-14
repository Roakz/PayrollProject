﻿using System;
using System.Collections.Generic;
using System.IO;
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

    /*The admin class also inherits from the Staff class and has  the additional fields of overtimeRate and adminHourlyRate.
      The Calculate pay method overrides the base again using these fields to calculate an admins pay.*/
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

    /* The file reader class reads the staff.txt file in the debug directory. If it exists we read each line and split it.
       If the staff is a Manager create a manager object and add it to the myStaff list otherwise add an admin object.
       If the file doesnt exist then output a message to the console. Return the list either way.*/

    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] seperator = { "," };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while(sr.EndOfStream != true)
                    {
                       result = sr.ReadLine().Split(seperator, StringSplitOptions.None);
                       if(result[1] == "Manager")
                        {
                            myStaff.Add(new Manager(result[0]));
                        }
                        else
                        {
                            myStaff.Add(new Admin(result[0]));
                        }
                    }
                    sr.Close();
                }
                
            }
            else
            {
                Console.WriteLine("File does not exist please rectify!.");
            }

            return myStaff;
        }
    }

    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear { JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";

                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("PAYSLIP FOR {0}{1}", (MonthsOfYear)month, year);
                sw.WriteLine("==================================");
                sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);

                if (f.GetType() == typeof(Manager))
                {
                    sw.WriteLine("Allowance: {0}", ((Manager)f).Allowance);
                }
                else if (f.GetType() == typeof(Admin))
                {
                    sw.WriteLine("Overtime:{0}", ((Admin)f).Overtime);
                }

                sw.WriteLine("");
                sw.WriteLine("==================================");
                sw.WriteLine("Total Pay: {0}:", f.TotalPay);
                sw.WriteLine("==================================");

                sw.Close();
            }
        }

        // LINQ Query
        public void GenerateSummary(List<Staff> myStaff)
        {
            var result = from staff in myStaff where staff.HoursWorked < 10 orderby staff.NameOfStaff ascending
                         select new { staff.NameOfStaff,staff.HoursWorked};

            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                foreach(var res in result)
                {
                    sw.WriteLine("Name of staff: {0}, Hours Worked: {1}", res.NameOfStaff, res.HoursWorked);

                    sw.Close();
                }
            }
        }

        public override string ToString()
        {
            return "month = " + month + ", year = " + year;
        }
    }
}
