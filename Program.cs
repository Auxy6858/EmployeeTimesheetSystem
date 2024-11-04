using System.Net;

namespace EmployeeTimesheetSys;

public static class Program
{
 public struct Employee
 {
  public string Name { get; set; }
  public int Id { get; set; }
  public int[] HoursWorked { get; set; }
  public int TotalHoursWorked { get; set; }
 }

 public static int UserOptionsPrompt()
 {
  bool selectedOption = false;
  do
  {
   Console.WriteLine("A: Add Employee Details");
   Console.WriteLine("B: Display All Employee Details");
   Console.WriteLine("C: View Overtime Details");
   Console.WriteLine("D: Exit");
   Console.Write("\nEnter Choice> ");

   switch (Console.ReadLine().ToLower())
   {
    default:
     Console.WriteLine("Please enter a valid option");
     break;
    case "a":
     return 0;
    
    case "b":
     return 1;
    
    case "c":
     return 2;
    
    case "d":
     return 3;
   }
  } while (!selectedOption);

  return -1;
  Console.WriteLine("An error occurred. Please try again.");
 }

 public static Employee AddEmployeeDetails()
 {
  Employee tempEmployee = new Employee();
  tempEmployee.Name = "";
  tempEmployee.Id = 0;
  tempEmployee.HoursWorked = new int[5];
  tempEmployee.TotalHoursWorked = 0;
  
  
  Console.Write("Enter Employee Name: ");
  tempEmployee.Name = Console.ReadLine();
  
  Console.Write("Enter Employee ID: ");
  tempEmployee.Id = int.Parse(Console.ReadLine());
  
  for (int i = 0; i < 5; i++)
  {
   Console.Write($"Enter Hours Worked on day {i+1} (Monday = 1, Friday = 5): ");
   int hoursWorked = int.Parse(Console.ReadLine());
   tempEmployee.HoursWorked[i] = hoursWorked;
   tempEmployee.TotalHoursWorked += hoursWorked;
  }
  return tempEmployee;
 }

 public static void DisplayEmployeeDetails(Employee employee)
 {
  Console.WriteLine($"Name: {employee.Name}, Id: {employee.Id}, Total Hours: {employee.TotalHoursWorked}");
 }

 public static void Main(string[] args)
 {
  List<Employee> employees = new List<Employee>();
  
  while (true)
  {
   int userOption = UserOptionsPrompt();
   switch (userOption)
   {
    case -1:
     Console.WriteLine("Catastrophic Error.");
     goto EndPoint;
    
     case 0:
     employees.Add(AddEmployeeDetails());
     break;
     
     case 1:
      Console.WriteLine("Weekly Summary:");
     for (int i = 0; i < employees.Count; i++)
     {
      Console.WriteLine($"Name: {employees[i].Name}, ID {employees[i].Id}, Total Hours: {employees[i].TotalHoursWorked}");
     }
      Console.WriteLine();
      break;
     
     case 2:
      Console.WriteLine("Employees With Overtime:");
      for (int i = 0; i < employees.Count; i++)
      {
       if (employees[i].TotalHoursWorked > 40)
       {
        Console.WriteLine($"Name: {employees[i].Name}, ID {employees[i].Id}, Total Hours: {employees[i].TotalHoursWorked} - Overtime");
       }
      }

      break;
     
     case 3:
      goto EndPoint;
   }
  }
  EndPoint:
  Console.WriteLine("Press any key to continue...");
  Console.ReadKey();
  
 }
}