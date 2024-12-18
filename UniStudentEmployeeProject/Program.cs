using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class Program
{
    public static List<University> universities = new List<University>();
    public static List<Student> students = new List<Student>();
    public static List<Employee> employees = new List<Employee>();

    private const string UniversityFilePath = "../../universities.json";
    private const string StudentFilePath = "../../students.json";
    private const string EmployeeFilePath = "../../employees.json";

    public static void Main(string[] args)
    {
        if (File.Exists(UniversityFilePath))
        {
            universities = JsonConvert.DeserializeObject<List<University>>(File.ReadAllText(UniversityFilePath)) ?? new List<University>();
        }

        if (File.Exists(StudentFilePath))
        {
            students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(StudentFilePath)) ?? new List<Student>();
        }

        if (File.Exists(EmployeeFilePath))
        {
            employees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(EmployeeFilePath)) ?? new List<Employee>();
        }
    

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add University");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Add Employee");
            Console.WriteLine("4. Find Student by Name");
            Console.WriteLine("5. Find Employee by Name");
            Console.WriteLine("6. Save Data");
            Console.WriteLine("7. Exit");

            Console.Write("\nChoose an option: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddUniversity();
                    break;
                case "2":
                    AddStudent();
                    break;
                case "3":
                    AddEmployee();
                    break;
                case "4":
                    FindStudentByName();
                    break;
                case "5":
                    FindEmployeeByName();
                    break;
                case "6":
                    SaveData();
                    break;
                case "7":
                    SaveData();
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private static void AddUniversity()
    {
        Console.Write("Enter University Name: ");
        var name = Console.ReadLine();

        Console.Write("Enter Street: ");
        var street = Console.ReadLine();

        Console.Write("Enter City: ");
        var city = Console.ReadLine();

        var university = new University
        {
            Name = name,
            Address = new Address { Street = street, City = city}
        };

        universities.Add(university);
        Console.WriteLine("University added successfully.");
    }

    private static void AddStudent()
    {
        Console.Write("Enter Student First Name: ");
        var firstName = Console.ReadLine();

        Console.Write("Enter Student Last Name: ");
        var lastName = Console.ReadLine();

        Console.Write("Enter University Name: ");
        var universityName = Console.ReadLine();

        if (!universities.Any(u => u.Name == universityName))
        {
            Console.WriteLine("University does not exist. Please add it first.");
            return;
        }

        var student = new Student
        {
            FirstName = firstName,
            LastName = lastName,
            UniversityName = universityName
        };

        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    private static void AddEmployee()
    {
        Console.Write("Enter Employee First Name: ");
        var firstName = Console.ReadLine();

        Console.Write("Enter Employee Last Name: ");
        var lastName = Console.ReadLine();

        Console.Write("Enter Job Title: ");
        var jobTitle = Console.ReadLine();

        Console.Write("Enter University Name (Where Employee works): ");
        var universityName = Console.ReadLine();

        if (!universities.Any(u => u.Name == universityName))
        {
            Console.WriteLine("University does not exist. Please add it first.");
            return;
        }

        var employee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            JobTitle = jobTitle,
            UniversityName = universityName
        };

        employees.Add(employee);
        Console.WriteLine("Employee added successfully.");
    }

    private static void FindStudentByName()
    {
        Console.Write("Enter Student Name: ");
        var name = Console.ReadLine();
        var foundStudents = students.Where(s =>
            s.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
            s.LastName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundStudents.Count == 0)
        {
            Console.WriteLine("No students found with the given name.");
        }
        else
        {
            foreach (var student in foundStudents)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}, University: {student.UniversityName}");
            }
        }
    }

    private static void FindEmployeeByName()
    {
        Console.Write("Enter Employee Name: ");
        var name = Console.ReadLine();
        var foundEmployees = employees.Where(e =>
            e.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
            e.LastName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundEmployees.Count == 0)
        {
            Console.WriteLine("No employees found with the given name.");
        }
        else
        {
            foreach (var employee in foundEmployees)
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Job Title: {employee.JobTitle}, University: {employee.UniversityName}");
            }
        }
    }

    private static void SaveData()
    {
        File.WriteAllText(UniversityFilePath, JsonConvert.SerializeObject(universities, Formatting.Indented));
        File.WriteAllText(StudentFilePath, JsonConvert.SerializeObject(students, Formatting.Indented));
        File.WriteAllText(EmployeeFilePath, JsonConvert.SerializeObject(employees, Formatting.Indented));
        Console.WriteLine("Data saved successfully.");
    }
}
