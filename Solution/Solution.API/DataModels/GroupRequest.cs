namespace Solution.API.DataModels
{
    public class GroupRequest
    {
        public int GroupRequestId { get; set; }

        public int GroupId { get; set; }

        public string? UserId { get; set; }

        public bool Accepted { get; set; }

        public virtual Group Group { get; set; } = null!;

        //public virtual AspNetUser? User { get; set; }
    }
}
