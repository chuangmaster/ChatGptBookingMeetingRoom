namespace chatgpt4api.Response
{
    public class MeetingRoom
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool HasVideoConferencing { get; set; }
        public bool HasWhiteboard { get; set; }
        public bool HasIndividualAC { get; set; }
    }
}
