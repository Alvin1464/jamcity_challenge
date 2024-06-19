using System.Collections.Generic;
using System.IO;
using Employees.Repositories.Impl;
using Employees.Services;
using Employees.Services.Implementation;
using UnityEditor;
using static Employees.Model.Seniority;
using static Employees.Services.Role;
using Random = System.Random;

namespace Utils
{
    class LoadEmployeeList : EditorWindow
    {
        static List<string> availableNames = new() {"Jhoseph", "Giorno", "Mateo", "Jack", "Rodolfo", 
            "Arnold", "Patricia", "Marta", "Karen", "Margarita", "Guadalupe"};

        static List<string> availableSurnames = new()
        {
            "Perez", "Lopez", "Joestar", "Lee", "Zion Zee", "Halland",
            "Schwarzenegger", "Giovanna"
        };

        static readonly Random random = new();

        static HireEmployeeService hireService;

        //Generate a list of employees based on the problem description.
        [MenuItem("Employees/GenerateCsv")]
        public static void GenerateCsv()
        {
            ClearOrCreateSaveFile();
            CreateHireService();
            HireGroupOfRole(HR, 5,2,13);
            HireGroupOfRole(ENGINEER, 50,68,32);
            HireGroupOfRole(ARTIST, 5,20,0);
            HireGroupOfRole(DESIGNER, 10,0,15);
            HireGroupOfRole(PM, 10,20,0);
            hireService.Execute("Alvaro Infante", CEO, Senior);


        }

        static void HireGroupOfRole(Role role, int seniors, int semiSeniors, int juniors)
        {
            for (var i = 0; i < seniors; i++)
            {
                var fullName = $"{PickAName()} {PickASurname()}";
                hireService.Execute(fullName, role, Senior);
            }
            for (var i = 0; i < semiSeniors; i++)
            {
                var fullName = $"{PickAName()} {PickASurname()}";
                hireService.Execute(fullName, role, Semi_Senior);
            }
            for (var i = 0; i < juniors; i++)
            {
                var fullName = $"{PickAName()} {PickASurname()}";
                hireService.Execute(fullName, role, Junior);
            }
        }

        static void CreateHireService()
        {
            var csvRepository = new EmployeesRepositoryJson();
            var idGenerator = new IdGeneratorGUID();
            hireService = new HireEmployeeService(idGenerator, csvRepository);
        }

        static void ClearOrCreateSaveFile()
        {
            var writer = new StreamWriter("./employeesFile.json");
            writer.Write(string.Empty);
            writer.Close();
        }

        static string PickAName() => 
            availableNames[random.Next(availableNames.Count)];

        static string PickASurname() =>
            availableSurnames[random.Next(availableSurnames.Count)];
    }
}
