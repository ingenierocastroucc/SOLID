
namespace OpenClose
{
    public abstract class Employee
    {
        public string Fullname {get; set;}

        public int HoursWorked {get; set;}

        public abstract decimal CalculateSalaryMonthly();

        // public EmployeeFulltime(string fullname, int hoursworked)
        // {
        //     Fullname = fullname;
        //     HoursWorked = hoursworked; 
        // }
    }
}