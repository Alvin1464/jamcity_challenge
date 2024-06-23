Note: I added an editor tool to populate the employes list in the json file, so you can make changes in the database and reset them.

My aproach to solve this challenge was to think of a scalable model representing the rules defined in the problem, then i started the unit tests to build that model, i wanted to have a abstract class Employee
that had the common behaviour and fields for all employees, and then define the specific employees that had that inherited from the base class employee, that had his specific
properties, like the starting salary by seniority or the ceo is always created as senior lvl.

Once i build the model and solved the rules by the task, i started to define the services that i needed to use that model and save or get the changes in a repository.

First i created the hiring service, that consumed a repository to save the created employee to a jsonfile.

When i had the hiring service created a tool to populate the json file with the amounts of employees asked the tool is in Scripts/Utils/LoadEmployeeList.cs (i already attached the generated json to the project)

After that created the getEmployeesService AndUpdateSalaryService, and later the presenter, views, and scene to show the data.

