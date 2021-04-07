# Openlayers-Web-Application

A single-page Geographic Information System (GIS) Web Application using Openlayers, developed with Asp.Net MVC, integrated with a MySQL database, based on CRUD operations.

## Preview of Application
![alt text](https://github.com/isilsukorkmaz/Openlayers-Web-Application/blob/master/preview.gif)

## Motivation
The aim of the project is to provide more up-to-date map layer by providing adding / deleting/ updating districts and gates. Changes in the neighborhood / gate informations are submitted to the database and retrieved and displayed in layers for each reload.

## Technologies Used

* Visual Studio 2019
* Openlayers
* MySQL
* ASP.NET MVC
* HTML 
* JavaScript
* AJAX
* JSON

## Launch
Application is a ASP.NET MVC program developed in Visual Studio 2019. It does not require any input values, if given database tables and attributes are created with exact names, when the application run a "localhost:xxxx" website will be load and application will be ready to work on. 

## Database

MySQL database is used in database operations. Two tables created for gate (named "kapı") and neighborhood (named "mahalle") informations. Table informations are as follows:
![](https://funkyimg.com/i/38d72.png)
![](https://funkyimg.com/i/38d73.png)

## Details

When the application is loaded, ‘AerialWithLabelsOnDemand’ layer is installed as the
main layer and the map is zoomed in and centred on Turkey. The main layer can be changed into other Bing Maps imagery styles 'SimpleMap' and 'RoadOnDemand' layers for desired use. The layer to be used is added by the user by selecting the "Harita Katmanı" section in the interface.
District and door additions can be made with Openlayers-supported drawing features on the district and gate layers added on top of the main layers. When this drawings are completed after selecting realted feature from the "Add" section in the navbar, a form of the relevant feature will be opened, the coordinate information in WKT will be automatically displayed in the opened form. After the other relevant parts of the form are filled, the feature will be processed into the layer and database by clicking the save button.
In addition, deleting features, dragging from corners or moving editing features are also provided to the application.
With the "Address Search" button prepared for searching from the registered information, it is possible to make a search by doing district and / or door filters. With the "Show" button on the right of the results, the relevant door is zoomed and displayed on the map.
