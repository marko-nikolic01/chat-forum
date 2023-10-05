using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class CommentSubmissionDTO
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Comment text is required.")]
        [MaxLength(1000)]
        public string Text { get; set; }


        public CommentSubmissionDTO()
        {
            this.UserId = 0;
            this.Text = "";
        }
    }
}
