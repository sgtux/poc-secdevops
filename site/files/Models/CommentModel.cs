namespace VWAT.Models
{
  public class CommentModel : BaseEntity
  {
    public string Description { get; set; }

    public System.DateTime Date { get; set; }

    public override string EntityName => "Comment";
  }
}