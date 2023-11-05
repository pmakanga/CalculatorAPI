# CalculatorApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.9.

## Development server

Clone the angular project, run npm install to restore the npm packages.
Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

The image for the calculator app is on the img folder of the application ~\Calculator\CalculatorApp\calculator-app\img

## API base url
The API base url is in the environment folder in the angular application the url is accessed via the environment variables. The url is https://localhost:7079/api/calculator note that when the API port number is updated the same should be adjusted in the environment variable folder


## Running unit tests

I am using Jest for unit test run npx jest to run unit test

## API

The api is developed with ASP.NetCore version 7.0 clone the the source and run the same not the local host ports number the same should match what is in the angular application's environment variable file.

## Create Database
In order to create the database run the script from a folder ScriptFile contained inside the API project. This will create the CalculatorDb and a table Calculations
Once done adjust the connection string in the appsettings.json to suit your sql environment i.e. server name and sql database password

## Run the API
Launch the API on your localhost by running the cloned project, you can also test the API from swagger.
Once the API is runnging and the angular app is fired via ng serve or ng serve --o the app will be able to make calls to the API
