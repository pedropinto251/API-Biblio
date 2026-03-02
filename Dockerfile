# Use a imagem base do SQL Server
FROM mcr.microsoft.com/mssql/server

# Defina as variáveis de ambiente
ENV SA_PASSWORD=Grupo8Grupo8
ENV ACCEPT_EULA=Y

# Crie um volume para armazenamento persistente
VOLUME /var/opt/mssql

# Abre a porta 1433 para comunicação com o SQL Server
EXPOSE 1433

# Comando para iniciar o SQL Server
CMD ["/opt/mssql/bin/sqlservr"]