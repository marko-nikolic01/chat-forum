using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "User is required.")]
        public User User { get; set; }


        [Required(ErrorMessage = "Comment text is required.")]
        [MaxLength(1000)]
        public string Text { get; set; }


        [Required(ErrorMessage = "DateTime is required.")]
        public DateTime DateTime { get; set; }


        public Comment()
        {
            this.Id = 0;
            this.User = null;
            this.Text = "";
            this.DateTime = DateTime.Now;
        }

        public Comment(string text)
        {
            this.Text = text;
            this.DateTime = DateTime.Now;
        }
    }
}