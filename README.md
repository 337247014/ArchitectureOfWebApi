# ArchitectureOfWebApi

--Day 1-------------------
  1.set up Data Access Layer with <b>Entity Framework , GenericRepository pattern and Unit Of Work</b><br/>
  2.set up BLL with service, Using <b>AutoMapper</b> which is third-part library (Oriented-Object-Mapping) and used to transfer DB Model to DTO automatically
  3.set up web api to do simple CRUD

--Day 2--------------------
  IOC and DI -- Unity IOC Container
  1. install package with Nuget
     <b>Install-Package Unity.Webapi</b> this is for api
     in addition, there is another package for mvc <b>Install-Package Unity.mvc</b><br/>
  when we running above command, it will generate an file named <b>UnityConfig.cs</b> where we can register services
  then we just need call the method <b>UnityConfig.RegisterComponents()</b> to initialise in Application_Start() method in Global.asax.cs
  2. using Constractor Injection to inject services