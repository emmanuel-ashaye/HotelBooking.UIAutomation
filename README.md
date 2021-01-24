# HotelBooking.UIAutomation
**Introduction**

Test Automation framework built to aid in end to end testing of functionality of http://hotel-test.equalexperts.io
This project was built using .Net Core 3.1 and Visual Studio for Mac IDE.
In order to run the test without an IDE, docker and docker-compose will be required.

**Steps**
1. Clone the repository.

2. In the root directory run this command to setup the test environment.
`docker-compose build --force-rm`

`docker-compose up -d --force-recreate`

3. Once all containrs are running, run this command to kick of the tesst run.

`docker-compose exec test-runner dotnet test --logger:"nunit;LogFilePath=TestResults/HotelBookingTests.xml"`

4. On completion, this command will generate a friendly report.

`docker-compose exec test-runner sh CreateExtentReport.sh`

5. Finally run this command to tear down the environment.

`docker-compose down`

<<<<<<< Updated upstream
6. To load the report in a browser, navegate to TestResults folder in the repository and click on the dashboard.html file.

`open TestResults/dashboard.html`
=======
6. To load the report in a browser, navegate to DockerResults folder in the repository and click on the dashboard.html file.
>>>>>>> Stashed changes
