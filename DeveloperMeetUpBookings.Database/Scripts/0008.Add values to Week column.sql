USE DeveloperMeetUpBookings
GO

BEGIN

UPDATE [Booking]
SET Week = 1

SET IDENTITY_INSERT Booking ON
INSERT INTO Booking (BookingId, Name, Email, Address, SeatId, Week)
VALUES (5, 'James Blackburn', 'james.r.b@hotmail.co.uk','108 Cranbourne Park','A1', 2), (6, 'Joe Bloggs', 'joe@hotmail.co.uk','77 Ashurst', 'C10', 2), (7, 'James Blackburn', 'james.r.b@hotmail.co.uk','108 Cranbourne Park', 'B1,B2,B3,B4', 3), (8, 'Joe Bloggs', 'joe@hotmail.co.uk','77 Ashurst', 'D10', 2)

END