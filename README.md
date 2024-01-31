# ChatGptBookingMeetingRoom
This is a project for chatgpt app actions. In order to query meeting room status and add booking record.

## Table Design Schema
``` SQl
CREATE TABLE [dbo].[MeetingRoomBookingRecord](
	[Id] [uniqueidentifier] NOT NULL,
	[RoomId] [varchar](10) NOT NULL,
	[BookUserName] [nvarchar](50) NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[CreateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_MeetingRoomBookingRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MeetingRoomBookingRecord] ADD  CONSTRAINT [DF_MeetingRoomBooking_CreateDatetime]  DEFAULT (getdate()) FOR [CreateDatetime]
```
