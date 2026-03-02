@echo off
dotnet sonarscanner begin /k:ctesp2324-Final-G4F /d:sonar.login=squ_7184b9dd9ee134ab31670a33c54225ccfda46b2a /d:sonar.host.url=http://localhost:9000 /d:sonar.sources=biblioteca,Controllers,Models /d:sonar.exclusions=**/bin/**,**/obj/**
dotnet build
dotnet sonarscanner end /d:sonar.login=squ_7184b9dd9ee134ab31670a33c54225ccfda46b2a
pause
