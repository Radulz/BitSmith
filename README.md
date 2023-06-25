# BitSmith-Online store for computer parts

PCPartsShop represents the folder where the backend code can be found.
pcpartsshop_website represents the folder where the frontend code can be found.

Backend requirements:
SQL Server 17
.NET 5.0
ASP.Net
Visual Studio

Frontend:
Node v14.18.1
React v17.0.2
Redux
VSCode

How to run the project:
Local Machine:
1. Install the required tools
2. Clone the repository on your local machine
3. Install the npm packages using npm -install
4. Get the connection string of the sql server
5. Add this into user secrets under ConnectionString: { PCPartsShopConnection: "" }
6. Open the infrastructure project in Package manager console in Visual Studio
7. Run update-database, this will apply all the migrations
8. Run the backend using IIS
9. Open the frontend folder in visual studio code and open a new terminal window
10. Run npm install
11. Generate a new certificate, open command prompt as administrator and do the following:
    - choco install mkcert
    - mkcert -install
    - mkcert -cert-file cert.pem -key-file key.pem localhost
12. Run the frontend using npm run start

Use the swagger to check if the connection with the database is made successfully.
If the connection is established and you have added products in the database and they are not diplayed on FE, check the configs of .env
