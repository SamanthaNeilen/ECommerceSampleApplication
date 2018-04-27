<h1>ECommerceSampleApplication</h1>
<p>
    This project was created with Visual Studio 2017 Community Edition.
</p>
<p>
    This project will be used to demonstrate multiple techniques and subjects that I will document in my blog.
    Once I make a blog post detailing a specific subject I will make a create a note of it in this readme.
</p> 
<p>This project contains:</p>
<ol>
    <li>
        The database project for my ECommerceApp test database.<br/>
        Used in blogpost <a href="https://samanthaneilen.github.io/2017/11/24/managing-a-sql-server-database-from-a-visual-studio-database-project.html" target="_blank">Managing a SQL Server database from a Visual Studio Database project</a> to demonstrate usage of a database project.    
    </li>
    <li>A .NET Framework MVC App
        <ul>
            <li>
                Website contains a customer overview page with related CRUD functionality.
            </li>
        </ul>
    </li>
    <li>Test projects
        <ul>
            <li>
                ECommerceApp.NetFramework.BusinessLayer.Tests: Unit tests for the business layer. <br/>
                Used in blogpost <a href="https://samanthaneilen.github.io/2017/12/29/tips-for-making-your-code-more-suitable-for-unit-tests.html" target="_blank">Tips for making your code more suitable for unit testing</a> to demonstrate how to write unit tests in general and how to write unittests for classes containing 3rd party references.
            </li>
        </ul>
        <ul>
            <li>
                ECommerceApp.NetFramework.SeleniumTests: UI tests for customer overview.
                See <a href="https://samanthaneilen.github.io/2018/01/14/writing-tests-for-your-graphical-user-interface.html" target="_blank">Writing tests for your graphical user interface</a> for more information on writing Selenium UI tests.
            </li>
        </ul>
    </li>
</ol>

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
<h1>How to automatically build and deploy the project using VSTS</h1>
<ul>
    <li>
        <a href="https://samanthaneilen.github.io/2018/02/10/setting-up-a-build-using-vsts.html" target="_blank">Setting up a build using VSTS</a>
    </li>
    <li>
        <a href="https://samanthaneilen.github.io/2018/03/17/setting-up-a-release-using-vsts.html" target="_blank">Setting up a release using VSTS</a>
    </li>
</ul>

