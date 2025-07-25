# 🧠 Gymmetry Backend API

¡Bienvenido a **Gymmetry**!  
Este proyecto es una API robusta para la **gestión de gimnasios**, desarrollada con **.NET 9**, **Azure Functions** y **SQL Server**. Implementa una arquitectura en capas, seguridad moderna y buenas prácticas de desarrollo para ofrecer una solución escalable y mantenible.

---

## 🚀 Tecnologías

- **.NET 9**
- **Azure Functions** (HttpTrigger, TimerTrigger)
- **SQL Server**
- **Entity Framework Core**
- **Inyección de dependencias** (`Microsoft.Extensions.DependencyInjection`)
- **JWT Authentication**
- **AutoMapper**
- **Application Insights**
- **Twilio** (para notificaciones)
- **Azure Blob Storage** (para archivos)

---

## 🏗️ Arquitectura del sistema

El backend sigue una **arquitectura en capas**:

- **Functions**: Entrypoints HTTP y Timer (controladores tipo serverless)
- **Services**: Lógica de negocio desacoplada
- **Repositories**: Acceso a datos y persistencia
- **DTOs**: Objetos de transferencia de datos para requests/responses
- **Models**: Entidades de dominio
- **Utils**: Utilidades y helpers (validaciones, JWT, etc.)

✅ Inyección de dependencias y AutoMapper están configurados globalmente en `Program.cs`.

🛡️ Control de errores global con manejo de excepciones y respuestas estandarizadas.

🔐 Autenticación implementada con JWT, validada en cada endpoint protegido.

---

## 📁 Estructura de carpetas

```
FitGymApp/
├── Functions/                # Azure Functions (HttpTrigger, TimerTrigger)
│   ├── UserFunctions/
│   ├── MachineFunction/
│   └── ... (más módulos)
├── Utils/                   # Utilidades (JwtValidator, ModelValidator, etc)
├── local.settings.json      # Variables de entorno locales
├── Program.cs               # Configuración principal, DI, EF, seeds
├── Gymmetry.Domain/         # Modelos, DTOs, Enums
├── Gymmetry.Application/    # Servicios de aplicación, interfaces, mapeos
├── Gymmetry.Repository/     # Repositorios, seeds, persistencia
└── DataBaseModel/           # Modelos de base de datos (legacy/compatibilidad)
```

---

## ⚙️ Configuración y variables de entorno

La configuración local se gestiona en `local.settings.json`. Variables comunes:

- `ConnectionStrings:DefaultConnection`: Conexión a SQL Server
- `Jwt:SecretKey`, `Issuer`, `Audience`: Configuración para JWT
- `AzureWebJobsStorage`: Requerido por Azure Functions
- `Twilio`: Claves para notificaciones SMS/WhatsApp
- `BlobStorage:ConnectionString`: Conexión a Azure Blob Storage
- `BasicConfig:MinPasswordLength`, `MaxPasswordLength`: Parámetros de validación

📦 Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=Gymmetry;Integrated Security=True;"
  },
  "Values": {
    "Jwt:SecretKey": "your-secret",
    "Jwt:Issuer": "http://localhost",
    "Jwt:Audience": "Gymmetry"
  }
}
```

---

## 💻 Ejecución local y scripts

```bash
# Restaurar dependencias
dotnet restore

# Compilar la solución
dotnet build

# Ejecutar pruebas unitarias
dotnet test

# Ejecutar localmente (Azure Functions)
func start

# Otras utilidades
dotnet run
```

---

## 🧩 Funcionalidades principales

- Registro y login de usuarios (con validaciones y JWT)
- Gestión de entidades: usuarios, gimnasios, rutinas, máquinas, empleados, planes, etc.
- Validaciones y lógica compartida centralizada
- Notificaciones vía Twilio (SMS/WhatsApp)
- Procesos automáticos con TimerTrigger (ej. actualización de precios)
- Seeds y migraciones automáticas en desarrollo

---

## 🔐 Seguridad y manejo de errores

- **Autenticación JWT**: Todos los endpoints protegidos requieren un token válido
- **Control de errores global**: Respuestas estándar y manejo robusto de excepciones
- **CORS**: Configurable desde `local.settings.json`
- **Manejo de claves sensible**: No subir `local.settings.json` al repositorio (está en `.gitignore`)

---

## ✅ Buenas prácticas

- Respetar la arquitectura en capas y el principio de responsabilidad única
- Exponer solo los datos necesarios con DTOs
- Validar siempre la entrada del usuario
- Mantener dependencias actualizadas
- Usar migraciones y seeds para base de datos
- Proteger claves (idealmente con Azure Key Vault en producción)
- Mantener cobertura de pruebas unitarias

---

## 📄 Licencia

Este proyecto está licenciado bajo la licencia [MIT](LICENSE).

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas!  
Por favor, abre un issue o pull request siguiendo las buenas prácticas de GitHub.  
Asegúrate de mantener la arquitectura y estándares del proyecto.

---

¿Dudas o sugerencias? No dudes en abrir un issue 🚀
