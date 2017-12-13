1. Create a database with the name 'Tote'.
2. Execute the script ~/Database/ToteWithoutDB.sql.
3. Ñhange the connection string in the Web.config 'Data Source' projects 'Tote.Web' and 'Tote.Service'

<add name ="DefaultDb" connectionString="Data Source=[computer_name]\[SQL_SERVER_name];Initial Catalog=Tote;User ID=vladDB; Password=adm711_1" providerName="System.Data.SQLClient"/>
  
4. Rebuild Solution.
5. Open iis Manager.
6. Add web-site. Path:'~/Tote/Service', host name:'localhost', Port:7712