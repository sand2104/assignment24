using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Employee_assignment24;

namespace asignment24_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 2 - Binary Serialization and Deserialization
            Employee employee = new Employee
            {
                Id = 21,
                FirstName = "Sandeep",
                LastName = "Prasad",
                Salary = 38000.0
            };

            // Binary Serialization
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, employee);
            }

            // Binary Deserialization
            Employee deserializedEmployee;
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Open))
            {
                deserializedEmployee = (Employee)binaryFormatter.Deserialize(fileStream);
            }

            // Display properties of deserialized Employee
            Console.WriteLine("Binary Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");



            // Step 3 - XML Serialization and Deserialization
            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (FileStream fileStream = new FileStream("C:\\data\\Employee_assignment24\\Employee_assignment24\\Employee.cs", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, employee);
            }
            using (FileStream fileStream = new FileStream("C:\\data\\Employee_assignment24\\Employee_assignment24\\Employee.cs", FileMode.Open))
            {
                deserializedEmployee = (Employee)xmlSerializer.Deserialize(fileStream);
            }

            // Display properties of deserialized Employee
            Console.WriteLine("\nXML Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");

            Console.ReadKey();
        }
    }


}