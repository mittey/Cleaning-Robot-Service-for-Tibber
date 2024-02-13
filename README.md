# Cleaning Robot Service for Tibber

Hi! Thanks for tasking a look at my test assignment.

The solution is build using .Net 8 + EF + PostgreSQL.

I've used JetBrains Rider on mac for development, so I cannot really promise that the project will be properly runnable in a Visual Studio or on a windows machine.

The service runs on port 5001 instead of 5000 as mentioned in the task, because on my machine port 5000 has taken by another service running. Hope that's not a big issue.

The solution consists of four projects:

- Api. This project implements the "api" layer of the application: mapping routes, starting the server, configuring di, etc. This is the main runnable project of the solution.
- CleaningRobot. This project implements the "engine" of the cleaning robot and exposes some high-level apis for external consumers.
- Data. This project is the "data access layer" of the solution. It implements an EF DbContext and a repository class that wraps the DbContext into a simpler api for external consumption.
- Tests. All the unit tests are here.

### How to run the service:

I've created a `docker-compose.yml` that is capable of starting the service and the database as a single deployable unit.

It should be enough to run this command from the root folder of the solution (you need docker to be started on your machine):

```
docker-compose up
```

After that you can go to http://localhost:5001/swagger/index.html to try out the api.

At the same time you can run the service from the ide if you want, it will run on port 5001.

### Unit tests:

You can run the unit tests by this command from the root of the solution:

```
dotnet test
```

I tried to create unit tests for all of the critical services and classes.