# Hair Salon

https://github.com/Rafeekey/hair-salon-csharp-review3

A website for a hair salon to show who their stylists are and who their clients are, 2/24/2017

## By Chad Durkin

# Description

This website will allow users see which stylists are available for a hair salon, allow the user to sign up to be a stylist, also allow the user to sign up as a client for a specific client, allow the user to edit their client name and delete their name.

# Setup/Installation Requirements

* _Open PowerShell_
* In SQLCMD:
* __> CREATE DATABASE hair_salon;__
* __> GO__
* __> USE hair_salon;__
* __> GO__
* __> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));__
* __> CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);__
* __> GO__
* Clone this directory and navigate to this directory folder on your local machine's Windows PowerShell Run the command "dnu restore"
* Run the command "dnx kestrel"
* Copy and paste the link "localhost:5004" into your browser

# Specifications

* Create a hair_salon database
* Create a stylists and clients table inside the hair_salon DATABASE
* Create a DeleteAll() method for each class
* Create a GetAll() method for clients and stylists
* Create an override bool Equals method for both classes
* Create a Save functionality for both classes, that saves to the DATABASE
* Create Find functionalities, by id and name, for both classes, taht searches through the DATABASE
* Create a GetClients() method to be able to search and retrieve all the clients for a specific stylist
* Create an Update functionality to be able to change a clients name in the DATABASE
* Create a Delete Functionality to be able to delete a specific client from the DATABASE

# Bugs

None so far

# Support and Contact Details

For any questions and comments please contact Chad Durkin at Chaddurkin@gmail.com

# Technologies Used

* HTML
* CSS
* MATERIALIZE
* C#
* SQL
* NANCY
* RAZOR

# License

This software is licensed under the GPL license.

Copyright (c) 2017 Chad Durkin
