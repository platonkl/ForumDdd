using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForumSibsau.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int ResponsesCount {  get; set; }

        public int Likes { get; set; } = 0;

        public int Dislikes { get; set; } = 0;
    }
}
