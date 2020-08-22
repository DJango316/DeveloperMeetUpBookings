USE DeveloperMeetUpBookings
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'DeveloperMeetUpBookingsAdmin')
BEGIN
CREATE LOGIN DeveloperMeetUpBookingsAdmin WITH PASSWORD = 'P@ssw0rd'
    CREATE USER [DeveloperMeetUpBookingsAdmin] FOR LOGIN [DeveloperMeetUpBookingsAdmin]
    EXEC sp_addrolemember N'db_owner', N'DeveloperMeetUpBookingsAdmin'
END;
GO