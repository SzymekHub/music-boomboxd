using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class CommentManager
    {
        private List<Comment> comments;

        public CommentManager()
        {
            comments = new List<Comment>();
        }

        public void Add(Comment comment)
        {
            comments.Add(comment);
        }

        public Comment[] GetArray()
        {
            return comments.ToArray();
        }

        public bool Remove(Comment comment)
        {
            return comments.Remove(comment);
        }
    }
}
