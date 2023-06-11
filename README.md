# ApiNet7Base
API .NET 7 base con Entity Framework y autenticación JWT

Si se requiere generación automatizada del modelo, ejecutar lo siguiente:

Install-Package Microsoft.EntityFrameworkCore.Tools

Scaffold-DbContext "Server=.\SQLEXPRESS;Database=BD;user id=User;password=****;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

JWT
Modificar la configuración en el archivo appsettings.json y en el JWT/JwtManager.cs
