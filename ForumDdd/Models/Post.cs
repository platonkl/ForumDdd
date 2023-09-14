﻿namespace ForumDdd.Models
{
    public class Post
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedDate { get; set;}
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        

    }
}
