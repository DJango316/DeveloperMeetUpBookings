IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
    WHERE name = N'DeveloperMeetUpBookings'
    )
BEGIN
    SELECT 'Database Name already Exist' AS Message
END
ELSE
BEGIN

CREATE DATABASE [DeveloperMeetUpBookings] 
    ON (NAME = N'DeveloperMeetUpBookings', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeveloperMeetUpBookings.mdf', SIZE = 1024MB, FILEGROWTH = 256MB)
LOG ON (NAME = N'DeveloperMeetUpBookings_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DeveloperMeetUpBookings_log.ldf', SIZE = 512MB, FILEGROWTH = 125MB)

END