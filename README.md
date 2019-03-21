# _HairSalon.Solution_

#### _Independent Project Weeks 8 and 9, March 14, 2019

#### By _**Jasmine Lee**_

## Description

_This website allows a user to input information with regards to a hair stylist and their clients. Hair stylists do not share clients, but can share specialties with other clients._

## Specifications
| Behavior | Input | Output |
|----------|:-----:|:------:|
| User clicks "add stylists" link and submit after entering information. | Click/Type | Page redirects to stylist page to add a stylist name and takes you back to homepage after clicking "submit". |
| User clicks "home" on any page. | Click | stylist info and/or clients, and/or specialties were accessed, created, or edited. |
| User clicks on the  created stylistName on homepage. | Click | Page redirect to Stylist Details/Clients of this stylist page. |
| User selects a specialty to be added to the current stylist and then "Add". | Click | Information is saved to database and appears on the page.  |
| User clicks on the hyperlink of the selected specialty. | Click | Page redirect to specialty name page where a list of the stylists with that specialty are listed. |
| User clicks on the hyperlink of the listed stylist| Click | Page redirects back to previous page. |
|User selects a stylist for the specialty to be added to | Click | Page adds stylist named to page. |
| User clicks on "Add a new client to this stylist" and enters information and then clicks "submit" | Click/Type | Page redirects to Stylist Details/Clients of this stylist page. |
| User clicks "edit" and enters information before clicking "submit" | Click | "Page redirects to Stylist/Details and Clients of this stylist" page |
| User clicks "Delete Stylist" | Click | Page deletes current stylist and redirects user to homepage |
| User clicks "Clear All Stylists" | Click | Database clears all stylists |
User clicks "See All Clients" and then "Delete all clients" | Click | Page takes user to a list of current users before redirecting the user back to the homepage (database clears current clients). |
| User clicks "See All Stylists" and then clicks on a "Add a specialty" and enters information and then click "Submit" | Click | Page redirects to a page that lists specialties and then to a page where user inputs information and then takes user back to "Hair Salon Management Portal" after clicking  "Submit" |
| User clicks on a listed specialty and then selects a stylist to add the specialty to. | Click | Page redirects to specialty name page and the selected stylist name appears on the page once selected. |

## Setup/Installation Requirements
Software Requirements:
Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and install. Download Mono and MAMP and install those as well.

* Open GitHub and go to https://github.com/jasminealee/WordCounter.Solution and click "clone or download"; copy the url provided.
* Go to Terminal and clone the folder by typing "git clone (repository url)" then enter.
* To edit, open the folder in atom or your choice of text editor.
* Open MAMP.
* !Database must be created first to use webpage!
* In the Command Prompt or Terminal use the command "mysql -uroot -proot"
* Use the following SQL commands in MySql to create database:
* > "CREATE DATABASE hair_salon;"
* > "USE hair_salon;"
* > "CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));"
* > "CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;"
* > CREATE TABLE specialities (id serial PRIMARY KEY, name VARCHAR(255));
* > CREATE TABLE specialities_stylists (id serial PRIMARY KEY, speciality_id INT, stylist_id INT;
* > "CREATE DATABASE hair_salon_test;"
* > "USE hair_salon_test;"
* > "CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));"
* > "CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;"
* > CREATE TABLE specialities (id serial PRIMARY KEY, name VARCHAR(255));
* > CREATE TABLE specialities_stylists (id serial PRIMARY KEY, speciality_id INT, stylist_id INT;
* To use the webpage, first navigate to the directory "HairSalon"
* Use the following commands:
* > "dotnet restore"
* > "dotnet build"
* > "dotnet run"
* Then go to "http://localhost:5000" to see webpage
* To run the tests, use these commands from the directory "HairSalon.Solution":
* > "cd HairSalon.Tests"
* > "dotnet test"

## Support and contact details

Contact: jasmine.al1722@gmail.com_

## Technologies Used

* Terminal
* Atom
* C#
* .Net Core 1.1.4 SDK
* .NET Core Runtime 1.1.2
* GitBash
* Mono
* MAMP

### License

*MIT*

*Copyright (c) 2019 Jasmine Lee*
