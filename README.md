# Solteq-assignment

Assignment for Solteq, Web application with React .NET and SQL db

## Requirements

Able to sign in to the application through frontend and comparing user input  
against database login data.

When logged in, user is able to fetch from product details from a catalog using  
a product code. This code needs to match a product from database.

    6420256012512

After fetching specifc product UI displays image of the product image is stored in a database.

Create a product display in a grid fashion where user is able to view products.

Clicking on a single products will give further details on the product and send code request to database for information.

Deploy product to the web.

## How to launch the applicaiton

Clone the repository locally to your machine

### Option one (preferable option)

Using docker you can launch the whole setup
Launch following command in the root directory where all the files are located
May require SDK 8.0 and Node 23. but from testing this should not be required
`docker compose -f docker-compose.dev.yml up --build`

Use URL `http://localhost:8080/` for connection

### Option two (tedious)

setup node 23 and run following sequence in frontend directory
`npm run install` `npm run dev`

After this run locally a pgsql database and adjust appsettings.Development.json Connectionstring for it to be able to connect to database.

Finally run in backend./Solter-server directory `dotnet build` && `dotnet run`

After this the application should be running as intended.
