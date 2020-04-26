# Dev Quote

Web api created in .net core with entityframework, swagger, jwt

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Visual Studio 2019
SDK net core
```

### Installing

A step by step series of examples that tell you how to get a development env running

From appsettings.json edit:

```
"DevConnection": "Server=**{server}**;Database=**{database}**;User Id=**{user}**;Password=**{password}**;MultipleActiveResultSets=True;"
```

Execute from console administrator nugets:

```
Add-Migration InitialCreate
Update-Database
```

End with an example of getting some data out of the system or using it for a little demo


## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Entity Framework Core (EF6)](https://docs.microsoft.com/en-us/ef/core/) - Dependency Management
* [Swagger](https://swagger.io/) - API development
* [JWT](https://jwt.io/) - Used to generate Tokens

## Authors

* **Ernesto Vargas** - *Initial work* - [AkiraGothick](https://github.com/akiragothick)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
