namespace EventProject.Application.DTOs;

public class CommentDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; }
    public List<CommentDto> Replies { get; set; } = new();


}
