#BloggingPlatForm
Simple blogging platform WebAPI realized in ASP .NET Core 2.1 

#Getting Started
In the BloggingPlatformBackend folder you find the SQLDump file with the inital data which you can execute on MS SQL Server/SQL Express/SQL Lite.
The connection string is configured for SQL Express so if you are running a different version of the SQL Server you will need to recofigure the connection
which you can find in the appsetting.json file.

You can also generate the database without inital data by running "Update-Database" from the powershell which will use migrations to create the db.

#Prerequisites
Visual Studio 2017 or Visual Code with the newst .NET Core SDK installed.
Some version Microsofts SQL Server
IIS(optional)

#Installing
1. Generate database as described under "Getting started", you can find the database dump with the data in the SQLDump folder
2. Open the .sln file found in the folder
3. Host the WebAPI on IIS or run directly from VS using IIS or Kestrel web server
4. Depending on how you hosted/started the WebAPI you can find the application on https://localhost:5000 and https://localhost:5001 for Kestrel,
or http://localhost:4939 for IIS Express.
5. The application should direct you to the SwaggerUI where you can find all endpoints of the api.

#Additional Comments
- I really want to explain myself about the multiple views I used, I personally do not think they are necessary but I wanted to adjust the swaggerUI input parameters
so they match the specification you gave me. I am aware the same could be realized without the additional views given some parameters are optional.
I know it makes it a bit messy bit I was thinking it would be better if the parameters match the specification.

- I used an ID column with the slug column insted using the slug column as the primary key, that is just personal preference as I prefer to work with an ID.

- Cascading delete is used with comments so all the comments of the relevant post are deleted if the post is deleted.

#Built With
Visual Studio 2017
ASP .NET Core 2.1
Database realized with : SqlExpress

#Versioning
I used git for versioning with VSTS an than moved the project to GitHub

#Authors
Smail Galijasevic | smailgalijasevic@gmail.com

#License
This project is licensed under the MIT License - see the LICENSE.md file for details

