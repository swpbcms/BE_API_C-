namespace BCMS.DTO.Interact
{
    public class ReplyCommentDTO
    {
        public string MemberId { get; set; }
        public string PostId { get; set; }
        public string? CommentContent { get; set; }
        public bool Status { get; set; }
        public string? CommentIDReply { get; set; }
    }
}
