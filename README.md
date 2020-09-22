# Commander API
> Commander API is a simple ASP.NET Core 3.1 MVC REST API that executes CRUD (Create, Retrieve, Update and Delete) commands on an MS SQL Server Database using Entity Framework Core.


## Description
The Commander API stores command line snippets (e.g. dotnet new mvc - to create a new ASP.NET Core Web Application). 
It is a simple but useful tool when you need to find a specific command line to use it. So, you'll have it within your reach, quickly and without having to perform any search on Google ;).

Each command line will have the following attributes:

- How to<br/>
Description of what the command will do, e.g. Build a .NET the project

- Command line<br/>
The actual command line snippet, e.g. dotnet build

- Platform<br/>
Application or platform domain, e.g. .Net Core


### Features

- [X] Retrieve all commands
- [X] Retrieve a spectic command
- [X] Create a new command
- [X] Update a command information
- [X] Delete an existent command

As the most REST APIs, the Commander API will follow the standard set of methods to Create, Retrieve, Update, and Delete command lines in the database. So, each functionality could be access as listed in the table below:

<table>
  <tbody>
    <tr>
      <th>Verb</th>
      <th>URI</th>
      <th>Method</th>
      <th>Description</th>
    </tr>
    <tr>
      <td>GET</td>
      <td>/api/commands</td>
      <td>Retrieve</td>
      <td>Retrieve all command line</td>
    </tr>
    <tr>
      <td>GET</td>
      <td>/api/commands/{id}</td>
      <td>Retrieve</td>
      <td>Retrieve a single resource, (by Id)</td>
    </tr>    
    <tr>
      <td>POST</td>
      <td>/api/commands</td>
      <td>Create</td>
      <td>Create a new command line</td>
    </tr>
    <tr>
      <td>PUT</td>
      <td>/api/commands/{id}</td>
      <td>Update</td>
      <td>Update a single command line by Id</td>
    </tr>
    <tr>
      <td>DELETE</td>
      <td>/api/commands/{id}</td>
      <td>Delete</td>
      <td>Delete a single command line by Id</td>
    </tr>
  </tbody>
</table>


## Installation

### Pre-requisites

1. .Net Core SDK installed;
2. Visual Studio Code installed.

### Cloning the Repository

comming soon.


<br/><br/><br/>


## Contributing

1. Fork it (<https://github.com/savaladaojr/CommanderAPI/fork>);
2. Create your feature branch (e.g. `git checkout -b feature/fooBar`);
3. Commit your changes (e.g. `git commit -am 'Add some fooBar'`);
4. Push to the branch (e.g. `git push origin feature/fooBar`);
5. Create a new Pull Request.



<br/><br/><br/><br/><br/>
This API was built for learning purposes. I did follow the instructions from the <a href='https://dotnetplaybook.com/develop-a-rest-api-with-net-core/'>Dotnetplaybook</a> website.
