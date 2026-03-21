# SchoolVote

## Architecture
- Pattern: VerticalSlice
- API Style: MinimalApis
- Frontend: Angular (standalone components)
- Key packages: MediatR, FluentValidation, Serilog, EF Core (PostgreSQL), Auth: JwtBearer

## Project Structure
- Backend: src/ folder(s)
- Frontend: schoolvote-client/

## Key Commands
```bash
# Backend
dotnet restore
dotnet build
dotnet run --project src/SchoolVote.API

# Frontend
cd schoolvote-client
npm install
ng serve

# Database
dotnet ef migrations add InitialCreate --project src/SchoolVote.API
dotnet ef database update
```

## Conventions
- All new features follow the VerticalSlice pattern
- Services always have a corresponding interface (IFooService / FooService)
- Configuration values always have a strongly-typed options class
- No business logic in controllers/endpoints — only delegation to handlers/services
