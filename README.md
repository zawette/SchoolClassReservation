# SchoolClassReservation
## notes
+ the API project depends on the "Application" and "Persistance" layers
+ the Application layer contains interfaces, Dtos , command/queries , exceptions and all application logic , it only depends on the domain layer
    + it defines interfaces that are implemented by outside layers
+ cqrs: seperates reads(queries) from writes(commands)
    + can maximize the performance , scalability, and simplicity
    + easy to mantain (changes only affect one command or query)
+ the project is not complex enough to justify using the cqrs pattern, i only implemented it for learning purposes 
+ Domain layer contains entities and value types and logic specific to the domain 
+ the presentation layer can be changed with minimal effort
## technologies
+ ASP.NET Core 3
+ Entity Framework Core 
+ mediatR
+ Identity

## screens

<img src="imgs\register.png"/>

<img src="imgs\List.png"/>

<img src="imgs\ReservationDelete.gif"/>

<img src="imgs\ReservationUpdate.gif"/>

<img src="imgs\AddReservationSuccess.gif"/>

<img src="imgs\AddReservationError.gif"/>

<img src="imgs\logout.gif"/>

