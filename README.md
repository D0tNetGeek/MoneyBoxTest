# MoneyBoxTest
Create a simple REST API (README)


1. I have used ASP.NET Core to develop the API to make it cross platform and demonstrated fair level SOLID Principals. Whole project is Re-sharper checked for no errors.

I have used Xunit for the unit testing. You can also, go to command window of Test project and issue "Dotnet test" to run the tests.

2. There are 3 projects in the solution
	2.1 RestApi - implements and exposes the WebApi uses dependency injection
	2.2 RestApi.Core - implements Data and Entity layer
	2.3 RestApi.Tests - implements the Tests for WebApi
	
3. Code Improvements

	3.1. Add of integration tests
	3.2. Logging on WebApi methods
	3.3. Mocking in Tests (to avoid direct data access, I hated myself for not including that because of time bound)
	3.4. Service Layer to access the repository (To make the code more testable and better use of dependency injection)
	3.5. Db Migration
	3.6. Task.Run to call CPU-bound methods (from GUI threads)
	3.7. Pagination
	3.8 Automapper (I have used my custom mapper)

4. Time spent

	6 hours

Notes:

1. This project/test doesn't uses the DB migrations, and I have created the "MoneyBoxDb" manually, which I am supplying with this project, in case, there is any problem accessing the DB, please recreate the DB.

2. There is "ConnectionString" property in RestApi project in the file called "appsettings.json", in case of any connection related issues.
3. To run the tests, "Test->Windows->Test Explorer" and not from the test file.
