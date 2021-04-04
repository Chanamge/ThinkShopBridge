# ShopBridge

This repo contains a Product creation API project.
There are several different projects are organized in sub-folders.
These sub-folders are organized for the separation of code as per there usages.
Sub-folders contains-
1. ShopBridge.Data project is responsible for database interaction.
2. ShopBridge.BL project is responsible for the Business logic and to make a connection between API project and the database layer. This project gets inputs from ShopBridge.API project controllers, perform business logic on them and the give data to ShopBridge.Data layer. After database operation completion, it return data from ShopBridge.Data layer and provide to the ShopBridge.API.
3. ShopBridge.API project is an API project. This project is responsible for getting inputs from user or request, pass to the ShopBridge.BL project and get required info from ShopBridge.BL layer and send as response to the user.
4. ShopBridge.API.Tests is a Test project, which contains all the uni test cases for the project.

All projects are specific to Visual Studio and require Visual Studio 2019.

To build and run the project:

1. Go to the project folder and build to check for errors:

2. Run the project


This project has provided five APIs-
1. GET /api/Product => This API displays the list of all the Products available in the datbase.
2. POST /api/Product => This is a POST API which creates new Product. This API required the input data in the form of JSON.
3. GET /api/Product/1 => This API displays a Product details based-on the passed Id parameter in the url.
4. PUT /api/Product/1 => This is a PUT API which updates an existing Product. This API required the input data in the form of JSON and Id as an url parameter.
5. DELETE /api/Product/1 => This is a DELETE API wchich deletes an existing Product. This API required the Id as an url parameter.