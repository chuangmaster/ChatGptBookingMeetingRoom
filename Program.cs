using System.Data.SqlTypes;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/meetingroom", () =>
{
  using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=chatgpt;"))
    {
        var dbResult = connection.Query<MeetingRoomBookingRecord>(@"SELECT * FROM MeetingRoomBookingRecord" ).ToList();
        if (dbResult.Count == 0)
        {
            return Results.Ok(new { Message = "All you can book" });
        }
        else
        {
            return Results.Ok(new { dbResult });
        }
    }
})
.WithName("GetMeetingRoom")
.WithOpenApi();



app.MapPost("/meetingroom", (Booking booking) =>
{
    using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=chatgpt;"))
    {
        var dbResult = connection.Execute(@"
        INSERT INTO [dbo].[MeetingRoomBookingRecord]
               ([Id]
               ,[RoomId]
               ,[BookUserName]
               ,[StartDateTime]
               ,[EndDateTime])
        VALUES
               (@id
               ,@RoomId
               ,@BookUserName 
               ,@StartDateTime 
               ,@EndDateTime )", new
        {
            Id = Guid.NewGuid(),
            RoomId = booking.RoomId,
            BookUserName = booking.UserName,
            StartDateTIme = booking.StartDateTime,
            EndDateTime = booking.EndDateTime,
        });
        if (dbResult > 0)
        {
            return Results.Ok(new { Message = "Reserved Success" });
        }
        else
        {
            return Results.BadRequest(new { Message = "Please Check again booking data" });
        }
    }
})
.WithName("PostMeetingRoomBooking")
.WithOpenApi();


app.Run();


class Booking
{
    public string? RoomId { get; set; }

    public string? UserName { get; set; }

    public string? StartDateTime { get; set; }

    public string? EndDateTime { get; set; }
}

public class MeetingRoomBookingRecord
{
    public Guid Id { get; set; }
    public string RoomId { get; set; }
    public string BookUserName { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreateDatetime { get; set; }

}
