# RedRiver
Praktikplats - uppgift
## Snabbstart lokalt

```bash
# API
cd backend
dotnet restore
dotnet run           # https://localhost:5001

# Frontend
cd ../frontend
npm install          # laddar ned Angular 18 och beroenden
npm start            # http://localhost:4200
```

* Logga in med **demo / demo** (skapad av DataSeeder).
* Testa: lägga till/redigera/radera böcker, växla tema, lägg till citat.

## Deploy

1. **Frontend**  
   ```bash
   npm run build
   ```  
   Ladda upp `frontend/dist/book-quotes-client/` till Netlify, Vercel eller Azure Static Web Apps.

2. **Backend**  
   Publicera `backend/` till Render.com eller Azure App Service.  
   Sätt miljövariabler (`Jwt__Key`, `Jwt__Issuer`, `Jwt__Audience`) samt tillåt front‑end‑origin i CORS (se `Program.
