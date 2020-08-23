USE DeveloperMeetUpBookings
GO

BEGIN

EXEC sp_RENAME 'Booking.Week' , 'MeetingWeek', 'COLUMN'

END