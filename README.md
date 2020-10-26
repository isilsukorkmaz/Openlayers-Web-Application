# Openlayers-Web-Application

The single-page Geographic Information System Web Application, developed with Asp.Net MVC that is working in integration with the database using Openlayers, successfully making CRUD operations, reflecting the changes to the database. 

## Motivation
The aim of the project is to provide more up-to-date map information by adding districts and gates to the map.The added neighborhood / gate information is transferred to the database and displayed on the map at the first entry to the application.

## Technologies Used

* ASP.NET
* HTML 
* JavaScript
* MVC
* MySQL
* SQL
* AJAX

## Launch
Application is a ASP.NET MVC program developed in Visual Studio 2019.  It does not require any input values, when it is run a "localhost:xxxx" website will be load and application will be ready to work on. 

## Details

When the application is loaded, ‘AerialWithLabelsOnDemand’ layer is installed as the
main layer and the map is zoomed in and centred on Turkey. The main layer can be changed into other Bing Maps imagery styles'SimpleMap' and 'RoadOnDemand' layers for desired use. The layer to be used is added by the user by selecting the "Harita Katmanı" section in the interface.
District and door additions can be made with Openlayers-supported drawing studies on the district and door layers added on the main layers. When this drawing made by selecting from the "Add" section in the navbar is finished, the add form of the relevant featurea will be opened, the coordinate information in WKT will be automatically displayed in the opened form. After the other relevant parts of the form are filled, the feature will be processed into the layer and database by clicking the save button.
In addition, deleting features, dragging from corners or moving editing features are also provided to the application.
With the "Address Search" button prepared for searching from the registered information, it is possible to make a search by doing district and / or door filters. With the "Show" button on the right of the results, the relevant door is zoomed and displayed on the map.

## Database

MySQL system was used in database operations. Tables were created for door and neighborhood information. Tables are as follows:
![](https://funkyimg.com/i/38d72.png)
![](https://funkyimg.com/i/38d73.png)

## Preview of Application
![](https://im6.ezgif.com/tmp/ezgif-6-2a13dc3d8831.gif)
