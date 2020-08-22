USE DeveloperMeetUpBookings
GO
CREATE PROCEDURE dbo.spCheckIfAvailable @Name nvarchar(50), @Email nvarchar(50), @Address nvarchar(50), @SeatId nvarchar(max)
AS
SELECT * 
FROM Booking
WHERE SeatId IN (SELECT value FROM STRING_SPLIT(@SeatId, ',')) AND Name = @Name AND Address = @Address AND Email = @Email
GO