# API
 * User API
   * Models
      * User.cs
   * Controller
      * UserController:ControllerBase
   * Web APIs HttpVerb
      * HttPGET
      * HttpPost
      * HttpPut
      * HttpDelete
   * Swagger Documentation Tool to check web API or end point
     * Swashbuckle.AspNetCore add in Nugget Package Manager UI
   * Postman
   * EndPoint:
     * https://localhost:5001/api/User
   * Layered Arch
     * Controller-->Service-->Repository-->ContextLayer-->SQL server
     * Models->User.cs
     * Service-> IUserService
                 UserService
     * Repository->IUserRepository
                   UserReposiotry
     * Context---->UserDbContext
     * Exception-->CustomException

     * AOP(Aspect Oriented Programming)

     * Replace List to Database-Done
     
     * EntityFramworkCore
       * Microsoft.EntityFrameworkCore
       * Microsoft.EntityFrameworkCore.SqlServer
       * u=>u.UseSQlServer(sqlconnectionsring);
       * Create UserDbContext:DbContext
         * Database.EnsureCreate();
       * appsettings.json
         "connectionsrings":
        
        {
         "":""

        }

        * DbSet<T>TableName{get;set;}

        * Code First Approach
     
    # JWT Token Generation
      Microsoft.IdentityModel.Tokens
      "key":"Value"

      "token"

# ProductAPI

* Authorize
```
System.InvalidOperationException: 
No authenticationScheme was specified, 
and there was 
no DefaultChallengeScheme found. 
The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action<AuthenticationOptions> configureOptions).
   at Microsoft.AspNetCore.Authentication.AuthenticationService.ChallengeAsync(HttpContext context, String scheme, AuthenticationProperties properties)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
```

* Validated Producct API
* Continue Product API
* using Logging Concept
