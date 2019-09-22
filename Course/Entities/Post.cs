using System;
using System.Collections.Generic;

namespace Course.Entities
{
    class Post
    {
        public string Title { get; set; }
        public DateTime Moment { get; set; }
        public string Content { get; set; }
        public int Likes { get; private set; } = 0; 
        List<Comment> Comments { get; set; } = new List<Comment>() { };

        public Post() { }

        public Post(string title, DateTime moment, string content)
        {
            Title = title;
            Moment = moment;
            Content = content;
        }


        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }

        public void AddLike()
        {
            Likes++;
        }

        public override string ToString()
        {
            string returnString =
                "Post Title: " + Title + "\n" +
                "Created on: " + Moment + "\n" +
                "Content: " + "\n" +
                Content + "\n" +
                "Likes: " + Likes + "\n";

            returnString += "Comments: " + "\n"; 
            foreach (Comment comment in Comments)
            {
                returnString += comment.Text + "\n"; 
            }

            return returnString;
        }
    }
}
