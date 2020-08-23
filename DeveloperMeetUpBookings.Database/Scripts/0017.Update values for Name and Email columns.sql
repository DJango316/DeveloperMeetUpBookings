USE DeveloperMeetUpBookings
GO

BEGIN

UPDATE [Booking]
SET Name = 'James Blackburn'
where BookingId = 1

UPDATE [Booking]
SET Email = 'james.r.b@hotmail.co.uk'
where BookingId = 1

UPDATE [Booking]
SET Name = 'James Blackburn,Joe Bloggs,Steve Smith,Stacey Blackburn'
where BookingId = 3

UPDATE [Booking]
SET Email = 'james.r.b@hotmail.co.uk,joe@hotmail.co.uk,Steve@hotmail.com,Stacey@hotmail.com'
where BookingId = 3

END