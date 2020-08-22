USE DeveloperMeetUpBookings
GO

IF (EXISTS (SELECT * FROM sys.tables WHERE [name] = 'Booking'))
BEGIN
    SELECT 'Table Name already Exist' AS Message
END
ELSE
BEGIN

CREATE TABLE [Booking] (  
 [BookingId] [int] IDENTITY (1, 1) NOT NULL ,  
 [Name] [nvarchar] (50),  
 [Email] [nvarchar] (50),  
 [Address] [nvarchar] (50),
 [SeatId] [nvarchar] (50),
 CONSTRAINT [PK_Booking] PRIMARY KEY  CLUSTERED   
 (  
  [BookingId]  
 )  ON [PRIMARY]   
) ON [PRIMARY] 
SET IDENTITY_INSERT Booking ON
INSERT INTO Booking (BookingId, Name, Email, Address, SeatId)
VALUES (1, 'James Blackburn', 'james.r.b@hotmail.co.uk','108 Cranbourne Park','A1'), (2, 'Joe Bloggs', 'joe@hotmail.co.uk','77 Ashurst', 'C10'), (3, 'James Blackburn', 'james.r.b@hotmail.co.uk','108 Cranbourne Park', 'B1,B2,B3,B4'), (4, 'Joe Bloggs', 'joe@hotmail.co.uk','77 Ashurst', 'D10')
SET IDENTITY_INSERT Booking OFF
END