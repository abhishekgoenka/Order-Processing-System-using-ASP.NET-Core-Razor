# Order Processing System using ASP.NET Core Razor
Order Processing sample application developed in ASP.NET Core Razor(.NET Framework). This application uses Entity Framework as an object-relational mapper to work with relational data(SQL Server) using domain-specific objects.

[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/abhishekgoenka/Order-Processing-System-using-ASP.NET-Core-Razor/issues)
![](https://opensourcerepo2.visualstudio.com/_apis/public/build/definitions/8a1f66d9-91a2-4271-9dd4-ba35933eb016/1/badge)

# Create localhost certificate
If you're using a version of Google Chrome prior to version 58, or if you're not using Google Chrome at all, you're good to go. However, if you are using Google Chrome 58 or a more recent version, you'll probably run into another certificate issue. From version 58 onwards, Chrome no longer considers the localhost certificate distributed together with VisualStudio 2017 and IIS Express as safe. In that case, you'll see an error stating the certificate's common name is invalid, as you can see on-screen. Luckily, there's a way to fix this. You can execute PowerShell script on this page. It will generate a new certificate that is considered safe.


# Getting Started
Open OrderProcessingSystem.sln solution in Visual Studio 2017CU3. Update the connection string in appsettings.json file. Compile and run the application.

Home page is localized in three languages – English(default), Spanish and German. I will be converting other pages as time permits.

![Screenshot](/.github/screenshot.png)
# License
The website is licensed under the [GPL(v3)](https://www.gnu.org/licenses/gpl-3.0.en.html) license.