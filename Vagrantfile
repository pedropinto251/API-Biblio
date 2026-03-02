# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure("2") do |config|
  config.vm.define "sql-server" do |sql|
    # Configure the box
    sql.vm.box = "mcr.microsoft.com/mssql/server"

    # Configure the VirtualBox provider
    sql.vm.provider "virtualbox" do |vb|
      vb.memory = "2048"  # Configure RAM to 2GB
    end

    # Forward VM port 1433 to host port 11433
    sql.vm.network "forwarded_port", guest: 1433, host: 11433

    # Define the SQL Server specific settings
    sql.vm.provision "shell", inline: <<-SHELL
      # Set SQL Server environment variables
      export SA_PASSWORD=Grupo8Grupo8
      export ACCEPT_EULA=Y

      # Create a volume for persistent storage
      docker volume create --name=sql-data

      # Run the SQL Server container
      docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=$Grupo8Grupo8' -p 1433:1433 --name sql-server-container -v sql-data:/var/opt/mssql -d mcr.microsoft.com/mssql/server
    SHELL
  end
end