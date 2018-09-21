using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using PostViewerApp.Data;

namespace PostViewerApp.Net
{
    public class DataRetriever
    {
        public DataRetriever()
        {
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(json))
                {
                    posts = JsonConvert.DeserializeObject<Post[]>(json).ToList();
                }
            }

            return posts;
        }

        public List<Comment> GetComments(int? postId)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/posts/"+postId+"/comments");

                if (!string.IsNullOrEmpty(json))
                {
                    comments = JsonConvert.DeserializeObject<Comment[]>(json).ToList();
                }
            }

            return comments;
        }

        public User GetUser(int? userId)
        {
            User user = new User();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/users/" + userId);

                if (!string.IsNullOrEmpty(json))
                {
                    user = JsonConvert.DeserializeObject<User>(json);
                }
            }

            return user;
        }
    }
}
