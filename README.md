# Library_ManyToMany
This aproach with .NET Framework 4.7/ManyToMany relations, EntityFramework, Autofac, 3tier pattern

3 tier application that shows how to work with many to many relations using ENtityFramework,
that gives 2 entities with navigation property. Also i'm using pattern UnitOfWork to work 
with database in safety in transactionScope. DB entites, data transfer entities, viewModels should mapped to each other with automapper.
Noticed important thing that in DI configurations we should use one instance of DbContext.
On top i have RESTful API on ASP.NET

DB-first approach was used.
Used fluent validation.

SQL scripts for creation and filling DB included.



Status of last deployment:<br>
<img src="https://github.com/adv4000/Library_ManyToMany/workflows/GH-Actions-CI/badge.svg?branch=master"><br>
