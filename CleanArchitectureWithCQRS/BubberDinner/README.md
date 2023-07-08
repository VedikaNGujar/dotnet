.Net 6.0

CQRS Implementation with DDD approach



User-secrets in package console

--------------------
PM> dotnet user-secrets init --project '.\BubberDinner.Api';
Set UserSecretsId to '7ba984ed-db2a-4695-abaf-3e14ab7c8e84' for MSBuild project '.\BubberDinner.Api\BubberDinner.Api.csproj'.
PM> dotnet user-secrets set --project '.\BubberDinner.Api' "JwtSettings:Secret" "super-secret-key-from-user-secrets";
Successfully saved JwtSettings:Secret = super-secret-key-from-user-secrets to the secret store.
PM> dotnet user-secrets list --project '.\BubberDinner.Api';
JwtSettings:Secret = super-secret-key-from-user-secrets



Global Error Handling

------------------------------
1. Create Error handling midddlewear and register that in Program.cs
2. Create Error Handling Filter and either add on top of all Controller or register that in Program.cs
3. Use exisiting ExceptionHandler middlewear and add endpoint.