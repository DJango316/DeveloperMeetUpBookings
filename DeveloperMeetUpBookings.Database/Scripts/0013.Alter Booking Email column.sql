USE DeveloperMeetUpBookings
GO

BEGIN

ALTER TABLE Booking
ALTER COLUMN Email varchar(max)

END