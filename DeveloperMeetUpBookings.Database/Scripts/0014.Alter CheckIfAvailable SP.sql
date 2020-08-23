USE DeveloperMeetUpBookings
GO
ALTER PROCEDURE dbo.spCheckIfAvailable @Name nvarchar(max), @Email nvarchar(max), @Address nvarchar(50), @SeatId nvarchar(max)
AS
SELECT * 
FROM Booking
WHERE SeatId IN (SELECT value FROM STRING_SPLIT(@SeatId, ',')) AND Name IN (SELECT value FROM STRING_SPLIT(@Name, ',')) AND Address = @Address AND Email IN (SELECT value FROM STRING_SPLIT(@Email, ','))
GO