# Vet Awesome
This is a sample veterinarian web app written in Angular with a .Net 7 based REST API and a SQL Server database. I wrote this app only because I wanted something to write in my off time but also wanted to make it realistic and useable.

## Table of Contents

[1. Database creation and seeding](#1-database-creation-and-seeding)

[2. Authentication/Authorization](#2-authentication/authoriation)



## 1. Database creation and seeding
I wrote this with a SQL Server database but it can be changed to another by modifying the DBContextOptionsBuilder in the BllModule of the VetAwesome.Bll library.

Execute the SQL script .\SQL\Schema.sql which will create the tables and other schema objects. After these are created, POST to the `/api/Seed` endpoint to seed working data.

## 2. Authentication/Authorization
This app performs authentication in a very simple manner, basically by POSTing to an API endpoint. However it does fully use role based authorization.

1. App users are stored in the Users table and have one of the following roles:
   - Secretary 
        * Can create/edit/delete/move all appointments.
   - Veterinarian
        * Can create/edit/delete/move their own appointments. 
   - Owner
        * Can perform any operation.
2. Authentication is performed by POSTing to the`/api/Users` endpoint with a user ID, causing the user ID to be added to the session state. When the VetAwesomeClaimsTransformation class sees this id in the session state, it creates and returns a VetAwesomePrincipal with the correct claims in it to represent the database user.

