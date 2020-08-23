USE DeveloperMeetUpBookings
GO

BEGIN

ALTER TABLE Booking
ALTER COLUMN Name varchar(max)

END