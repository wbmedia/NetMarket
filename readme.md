
## For add Identity Migrations run the following command

`dotnet ef migrations add SeguridadInicio -p BussinesLogic -s WebApi -o Indentity/Migrations -c SeguridadDbContext`

### run seguridad context

`dotnet ef database update SeguridadInicio -p BussinesLogic -s WebApi -c SeguridadDbContext`
