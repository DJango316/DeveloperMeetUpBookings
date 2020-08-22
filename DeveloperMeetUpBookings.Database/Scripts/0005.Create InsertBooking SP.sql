USE DeveloperMeetUpBookings
GO
CREATE PROCEDURE dbo.spInsertBooking @Name nvarchar(50), @Email nvarchar(50), @Address nvarchar(50), @SeatId nvarchar(max)
AS
BEGIN
INSERT INTO Booking (Name, Email, Address, SeatId)
VALUES (@Name, @Email, @Address, @SeatId)
END