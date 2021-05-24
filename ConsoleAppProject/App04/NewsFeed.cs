using System;
using System.Collections.Generic;
namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///  Edited by Phill Horrocks
    ///  Date: 26/03/21
    ///</author> 
    public class NewsFeed
    {
        public const string author = "Phill"; // Testing by setting constant variable
        private readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            // Testing by placing a message post and a photo post
            //MessagePost post = new MessagePost(author, "Hello world! You are awesome");
            //AddMessagePost(post);

            //PhotoPost photoPost = new PhotoPost(author, "pic1.jpg", "Me and my dogs!");
            //AddPhotoPost(photoPost);
        }

        ///<summary>
        /// Add a text post to the news feed.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        /// <summary>
        /// Remove a post from the news feed.
        /// Check to see if the post exists; if it does, execute the Remove
        /// method. If it does not exist, show an error message
        /// </summary>
        public void RemovePost(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nPost ID {id} has been sucessfully removed");
                posts.Remove(post);
                //post.Display();
            }
        }

        public void AddComment(int id, string comment)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nComment added to post ID {id}");
                post.AddComment(comment);

            }
        }

        public void AddLike(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nLike added to post ID {id}");
            }
            post.Like();
        }

        public void UnlikePost(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nUnliked post ID {id}");
            }
            post.Unlike();
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (TODO: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine("\n---------------------------------------------\n");
            }
        }

        /// <summary>
        /// Locate a specific post ID within the posts by trying to
        /// match the ID passed to an ID already in the system
        /// </summary>
        public Post FindPost(int id)
        {
            foreach (Post post in posts)
            {
                if (post.PostID == id)
                {
                    return post;
                }
            }
            return null;
        }
        
    }

}
