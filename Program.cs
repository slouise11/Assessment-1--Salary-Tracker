using System.Threading.Channels;

namespace Assessment_1__Salary_Tracker
{
    internal class Program
    {
        public static string EmailAddress { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the job agency");
            Console.WriteLine("");
            Console.WriteLine("**********************************************************");

            Console.WriteLine("Please enter your email address >>");
            EmailAddress = Console.ReadLine();

            secureAccess();

            Console.ReadLine();




        }

        private static void secureAccess()
        {
            Console.WriteLine("Please enter your pin number to continue >>");
            int pinNo = Convert.ToInt32(Console.ReadLine());



            for (int count = 0; count < 3; count++)
            {
                if (pinNo == 5644)
                {
                    enterSalaries();
                    return;
                }
                else if (count == 2)
                {
                    Console.WriteLine("Invalid pin number entered 3 times, no access allowed");
                }

                else
                {
                    Console.WriteLine($"Try again");
                    pinNo = Convert.ToInt32(Console.ReadLine());
                }


            }
        }

        private static void enterSalaries()
        {
            Console.WriteLine("");
            Console.WriteLine("To start with we require entry of monthly salaries");
            Console.WriteLine("");
            double totalSalary = 0;
            for (int count = 1; count < 13; count++)
            {
                Console.WriteLine($"Please enter salary for month {count}");

                double monthSalary = Convert.ToDouble(Console.ReadLine());
          
                totalSalary = totalSalary + monthSalary;
            }


            double avgSalary = totalSalary / 12;

            Console.WriteLine("**********************************************************");

            displayDetails(totalSalary, avgSalary);
        }

        private static void displayDetails(double totalSalary, double avgSalary)
        {
            Console.WriteLine("");
            Console.WriteLine(EmailAddress.ToUpper());
            Console.WriteLine($"Total Salary: £{Math.Round(totalSalary, 2)}");
            Console.WriteLine($"Average Salary: £{Math.Round(avgSalary, 2)}");
            Console.WriteLine("");
            Console.WriteLine("**********************************************************");
        }

    }
}
