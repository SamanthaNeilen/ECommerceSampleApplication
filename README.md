<h1>ECommerceSampleApplication</h1>
<p>
    This project was created with Visual Studio 2017 Community Edition.
</p>
<p>
    This project will be used to demonstrate multiple techniques and subjects that I will document in my blog.
    Once I make a blog post detailing a specific subject I will make a create a note of it in this readme.
</p> 
<h1>How to run the project</h1>
<ol>
    <li>To run the project first create the database.
        <ul>
            <li>
                All default checked-in connectionstrings assume a database called ECommerceApp in a local\SQLExpress instance. The latest version of the database schema is stored in the ECommerceApp.Database project of the solution. If you are creating the database for the first time, do a schema compare to create the tables and after that run all scripts in the Post Deployment Scripts of the database. When upgrading from an older version run all scripts in the Pre Deployment Scripts folder of the database project.
            </li>
            <li>
                The Target platform for running the DACPAC is set to "Microsoft Azure SQL Database V12" for use with a deployment pipeline using VSTS to an Azure database.
            </li>
        </ul>
    </li>
    <li>
        The default start-up project should be ECommerceApp.NetFramework.Web and the web.config in that project contains a connectionstring called ECommerceDbContext that should be edited to point to correct the location of the EcommerceApp database.
       <ul>
            <li>
                The release.config of the web project is configured to transform the config to hide all paths and connectionstrings for the purpose of deploying to Azure and using the settings configured via the portal "Application Settings" blade,
            </li>
        </ul>
    </li>
</ol>
