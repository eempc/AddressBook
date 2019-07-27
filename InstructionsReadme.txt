Step 1 is to create new webforms project (non-MVC) with identity authorisation

Step 2 is to Add-Migration Initial then Update-Database

Technically you are done now with identity

Step 3 is to add the main Model that you will be working with

Step 4 is to scaffold that model

Step 5 is services.AddScoped<IModelName, ModelName>(); (maybe not necessary)

Step 6 is to Add-Migration AddModel then Update-Database

See code in Create and Index on how to load up database entries according to user.
