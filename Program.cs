using System.Threading.Channels;

namespace Assessment_1__Salary_Tracker
{
    internal class Program
    {
        public static string EmailAddress
        {
            get;
            private set;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the job agency");
            Console.WriteLine("");
            Console.WriteLine("**********************************************************");


            while (true)
            {
                // Ask the user to enter their email address
                Console.WriteLine("Please enter your email address >>");
                EmailAddress = Console.ReadLine(); // Store the users email address for later use

                // See if the email entered contains @ and .ac.uk
                if (IsValidEmail(EmailAddress))
                {
                    Console.WriteLine("");
                    secureAccess(); // moves on to secureAccess method
                    break; // exit loop because correct email entered
                }
                else
                {
                    // Inform user wrong email address has been entered
                    Console.WriteLine("Error needs to be a valid email address");
                }
            }
            

        }
        // Method to check the email contains the correct things
        static bool IsValidEmail(string email)
        {
            // Makes sure the email is not empty and has a @ and .ac.uk
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".ac.uk");
        }

        private static void secureAccess()
        {
            // Prompts the user for their Pin
            Console.WriteLine("Please enter your pin number to continue >>");
            string pinInput = Console.ReadLine(); // Read the user input for the Pin
            int pinNo; // Variable to store the parsed Pin number

 
            // Allow up to 3 attempts to enter the correct Pin
            for (int count = 0; count < 3; count++)
            {
                // Try to parse the input as an integer
                if (Int32.TryParse(pinInput, out pinNo))
                {
                    // Check if the pin entered is correct
                    if (pinNo == 5644)
                    {
                        enterSalaries(); // Call the method to enter salaries if the Pin is correct
                        return; // Exit the method after successful access
                    }
                    else if (count == 2)
                    {
                        // Inform the user after 3 failed attempts
                        Console.WriteLine("Invalid pin number entered 3 times, no access allowed");
                    }
                    else if (pinNo.ToString().Length != 4)
                    {
                        // Inform the user the pin is not 4 digits long
                        Console.WriteLine("Error please enter a pin number as 4 digits");
                        pinInput = Console.ReadLine(); // Ask for Pin again
                    }

                    else
                    {
                        // Inform the user the Pin is incorrect and get to try again
                        Console.WriteLine($"Try again");
                        pinInput = Console.ReadLine(); // Ask for Pin again
                    }
                }
                else 
                {
                    // Inform the user if the inpput is not a valid integer
                    Console.WriteLine("Error please enter a pin number as 4 digits");
                    pinInput = Console.ReadLine(); // Ask for Pin again
                }
            }
        }

        private static void enterSalaries()
        {
            // Inform the user that the monthly salaries are needed
            Console.WriteLine("");
            Console.WriteLine("To start with we require entry of monthly salaries");
            Console.WriteLine("");

            double totalSalary = 0; // Initialise total salary to collect monthly salaries

            // Loop to collect salary input for each month for 1 through 12
            for (int count = 1; count < 13; count++)
            {
                // Ask the user to enter salary for the current month
                Console.WriteLine($"Please enter salary for month {count}");
                
                // Read user input and convert to a double
                double monthSalary = Convert.ToDouble(Console.ReadLine());

                // Add up total salary
                totalSalary = totalSalary + monthSalary;
            }

            // Calculate the average salary over 12 months
            double avgSalary = totalSalary / 12;

            Console.WriteLine("**********************************************************");

            // Call a method to display the total and average salary details
            displayDetails(totalSalary, avgSalary);
        }

        private static void displayDetails(double totalSalary, double avgSalary)
        {
            
            Console.WriteLine("");
            Console.WriteLine(EmailAddress.ToUpper()); // Display the email address in uppercase
            Console.WriteLine($"Total Salary: £{Math.Round(totalSalary, 2)}"); // Display the total salary rounded to 2 decimal places
            Console.WriteLine($"Average Salary: £{Math.Round(avgSalary, 2)}"); // Display the average salary rounded to 2 decimal places
            Console.WriteLine("");
            Console.WriteLine("**********************************************************");
        }

    }
}