# ECommerceSampleApplication
This project was created with Visual Studio 2017 Community Edition
 
This project will be used to demonstrate multiple techniques and subjects that I will document in my blog.
Once I make a blog post detailing a specific subject I will make a create a note of it in this readme.
 
 
# How to run the project
To run the project first create the database. 

All default checked-in connectionstrings assume a database called ECommerceApp in a local\SQLExpress instance. 
--*The latest version of the database schema is stored in the ECommerceApp.Database project of the solution. If you are creating the database for the first time, do a schema compare to create the tables and after that run all scripts in the Post Deployment Scripts of the database. When upgrading from an older version run all scripts in the Pre Deployment Scripts folder of the database project.

The default start-up project should be ECommerceApp.NetFramework.Web and the web.config in that project contains a connectionstring called ECommerceDbContext that should be edited to point to correct the location of the EcommerceApp database.
