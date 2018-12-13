# Booking System (Web API)
A system used to book spaces for a given period of time

## Getting Started
The application is split into 2 parts
 - BookingSystem is the web api and core program structure
 - booking-system-ui is the web front end for the application

 To get, develop and test the web api (and core structure) please follow these steps

 [Steps]

 To get, develop and test the application front end, please follow these steps

 [Steps]

### Prerequisites
 - Microsoft Visual Studio 2017
 - Visual Studio Code
 - Node.js (>=10.14.2)
 - Angular CLI (7.1.2)
 - Postman
 - newman
 - Docker

 To install newman use npm command: npm install -g newman

## Running the tests
 - Unit Tests:
 These are written with standard MS Test. To run these, open the solution in Visual Studio and choose Test -> Run -> All Tests

 - Api Endpoint Tests:
 These are written in Postman. To run, start the web api and execute the endpoint-tests.bat file. This will run newman.
 Some tests may fail on first execution, subsequent executions will be fine.

## Deployment
At present there are only manual deployments for this but multiple options.

1. Running within IDE
 - Open the web api in Visual Studio 2017 and run / debug as normal (ensuring the BookingSystem.WebApi is the default project)
 - Open the ui in Visual Studio Code and run with npm start

2. Running within docker
 - Open the web api in Visual Studio 2017 and run / debug as normal (ensuring the BookingSystem.WebApi is the default project)
 - Open the command line and navigate to the root folder of the Angular project
 - Execute the LocalContainer.bat file (this will build and run the front end as a docker image)

## Built With
 - .NET Core
 - Angular

## TODO's
1. Abstract Space inherited from "Bookable". This is to enable the booking system to be flexible so as to be able to book anything, not just meeting rooms
2. Split the Booking controller. To start with ideally to separate Command and Query controllers.
3. Tests against the web api controllers and presenters
4. Prettier angular booking form
5. Calendar controls
6. Styling on time controls
7. Date/time formats

## Author(s)
* **Nathan Hardes**

## Acknowledgments
* My Wife... for putting up with me, how she does it I'll never know
