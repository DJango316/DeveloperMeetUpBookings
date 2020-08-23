USE DeveloperMeetUpBookings
GO
ALTER PROCEDURE dbo.spCheckIfAvailable @Name nvarchar(50), @Email nvarchar(50), @Address nvarchar(50), @SeatId nvarchar(max), @MeetingWeek nvarchar(10)
AS
SELECT * 
FROM Booking
WHERE SeatId IN (SELECT value FROM STRING_SPLIT(@SeatId, ',')) AND Name = @Name AND Address = @Address AND Email = @Email AND MeetingWeek = @MeetingWeek
GO