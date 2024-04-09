# ChatGptBookingMeetingRoom
This is a project for chatgpt app actions. In order to query meeting room status and add booking record.

## Table Design Schema
``` SQL

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
GO

ALTER TABLE [dbo].[MeetingRoomBookingRecord]  WITH CHECK ADD  CONSTRAINT [FK_MeetingRoomBookingRecord_MeetingRoom] FOREIGN KEY([RoomId])
REFERENCES [dbo].[MeetingRoom] ([Id])
GO

ALTER TABLE [dbo].[MeetingRoomBookingRecord] CHECK CONSTRAINT [FK_MeetingRoomBookingRecord_MeetingRoom]


CREATE TABLE [dbo].[MeetingRoom](
	[Id] [varchar](10) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
	[HasVideoConferencing] [bit] NOT NULL,
	[HasWhiteboard] [bit] NOT NULL,
	[HasIndividualAC] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_MeetingRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MeetingRoom] ADD  CONSTRAINT [DF_MeetingRoom_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
```
