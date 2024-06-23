using System.Collections.Generic;
using System.IO;
using System.Linq;
using Employees.Model;
using Employees.Repositories.DTOs;
using Unity.Plastic.Newtonsoft.Json;

namespace Employees.Repositories.Impl
{
    public class EmployeesRepositoryJson : EmployeesRepository
    {
        const string filepath = "./employeesFile.json";

        Dictionary<string, Employee> inMemory;

        public void SaveEmployee(Employee employee)
        {
            inMemory[employee.GetId()] = employee;
            var dto = new EmployeeDTO(employee);
            var employeeDictionary = GetEmployeeDictionaryDTOs();
            employeeDictionary[dto.id] = dto;
            WriteFile(employeeDictionary);
        }

        public Dictionary<string, Employee> GetEmployees()
        {
            if (inMemory != null)
                return inMemory;
            inMemory = GetEmployeeDictionaryDTOs()
                .Select(pair => pair.Value.ToEmployee())
                .ToDictionary(x => x.GetId());
            return inMemory;
        }
        
        static Dictionary<string, EmployeeDTO> GetEmployeeDictionaryDTOs()
        {
            var file = ReadFile();
            var employeeDictionary = ParseEmployeesDictionary(file);
            return employeeDictionary;
        }

        static void WriteFile(Dictionary<string, EmployeeDTO> employeeDictionary)
        {
            var updatedJson = JsonConvert.SerializeObject(employeeDictionary);
            var writer = new StreamWriter(filepath);
            writer.Write(updatedJson);
            writer.Close();
        }

        static Dictionary<string, EmployeeDTO> ParseEmployeesDictionary(string file)
        {
            var employeeDictionary =
                JsonConvert.DeserializeObject<Dictionary<string, EmployeeDTO>>(file) ??
                new Dictionary<string, EmployeeDTO>();
            return employeeDictionary;
        }

        static string ReadFile()
        {
            var reader = new StreamReader(filepath);
            var file = reader.ReadToEnd();
            reader.Close();
            return file;
        }
    }
}