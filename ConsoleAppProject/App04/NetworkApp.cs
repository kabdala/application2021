using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// Main app menu to call the various other methods
    /// within the scope of this app. Loop this menu while
    /// the boolean condition for quitting is false.
    /// </summary>
    public class NetworkApp
    {
        private NewsFeed news = new NewsFeed();
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("NetworkApp", 0.1);

            DisplayCurrentDateAndTime();

            string[] choices = new string[]
            {
                "Post a message",
                "Post an image",
                "Display all posts",
                "Display posts by date",
                "Display posts by author",
                "Remove a post",
                "Add a comment",
                "Like or Unlike a post",
                "Quit the app"
            };

            bool wantToQuit = false;
            do
            {
                ConsoleHelper.OutputTitle("Main Menu");
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: DisplayAll(); break;
                    case 4: DisplayByDate(); break;
                    case 5: DisplayByAuthor(); break;
                    case 6: RemovePost(); break;
                    case 7: AddComment(); break;
                    case 8: LikeOrUnlikePost(); break;

                    case 9: wantToQuit = true; break;
                }
            } while (!wantToQuit);
        }

        /// <summary>
        /// Given that we're going to be asking for an author name throughout
        /// this app, it makes sense to implement a specific method for
        /// getting the 'author' that we can re-use.
        /// </summary>
        public string InputName()
        {
            Console.Write("    # Please enter your name: ");
            string author = Console.ReadLine();
            return author; // pass the string back out
        }

        /// <summary>
        /// Add a post message; ask the user for their name then ask
        /// for the message. Pass the message to the AddMessagePost
        /// then display the message
        /// </summary>
        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("** POST A MESSAGE **");
            string author = InputName();

            Console.Write("    # Enter your message: ");
            string message = Console.ReadLine();
            
            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);
            PostSuccessMessage();
            post.Display();
        }

        /// <summary>
        /// Add a photo message; ask the user for their name then
        /// ask for an image filename followed by an image caption.
        /// Pass the author, filename and caption to AddPhotoPost 
        /// then display the message.
        /// </summary>
        private void PostImage()
        {
            ConsoleHelper.OutputTitle("** POST AN IMAGE **");
            string author = InputName();

            Console.Write("    # Please enter image filename: ");
            string filename = Console.ReadLine();

            Console.Write("    # Please enter image caption: ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption);
            news.AddPhotoPost(post);
            PostSuccessMessage();
            post.Display();
        }

        private void DisplayAll()
        {
            ConsoleHelper.OutputTitle("** DISPLAY ALL POSTS **");
            news.Display();
        }

        private void DisplayByDate()
        {
            ConsoleHelper.OutputTitle("** DISPLAY POSTS BY DATE **");
            //throw new NotImplementedException();
        }
        private void DisplayByAuthor()
        {
            ConsoleHelper.OutputTitle("** DISPLAY POSTS BY AUTHOR **");
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a post from the system. Get a number from the 
        /// user by using the ConsoleHelper class 
        /// </summary>
        private void RemovePost()
        {
            ConsoleHelper.OutputTitle("** REMOVE A POST **");
            int id = (int)ConsoleHelper.InputNumber("    # Please enter the post ID to delete: ", 1, Post.GetNumberOfPosts());
            news.RemovePost(id);
        }

        /// <summary>
        /// Add a comment to a post. Ask user for ID number of comment
        /// </summary>
        private void AddComment()
        {
            //throw new NotImplementedException();
            ConsoleHelper.OutputTitle("** ADD COMMENT **");
            int id = (int)ConsoleHelper.InputNumber("    # Please enter the post ID to add a comment: ", 1, Post.GetNumberOfPosts());

            Console.Write("    # Please enter your comment: ");
            string comment = Console.ReadLine();
            news.AddComment(id, comment);
        }

        /// <summary>
        /// Like or unlike a post. Ask use for ID number of post
        /// </summary>
        private void LikeOrUnlikePost()
        {
            ConsoleHelper.OutputTitle("** LIKE OR UNLIKE A POST **");

            // TODO: Display a list of posts with ID's before choosing?

            Console.Write("    # Would you like to (1) Like or (2) unlike a post?: ");
            string likeOrUnlike = Console.ReadLine();

            if(likeOrUnlike == "1")
            {
                int id = (int)ConsoleHelper.InputNumber("    # Please enter the post ID to add a like: ", 1, Post.GetNumberOfPosts());
                news.AddLike(id);
            }
            else if (likeOrUnlike == "2")
            {
                int id = (int)ConsoleHelper.InputNumber("    # Please enter the post ID to add a unlike: ", 1, Post.GetNumberOfPosts());
                news.UnlikePost(id);
            }
           
        }

        /// <summary>
        /// Short method to display the current date and time to the user
        /// </summary>
        private void DisplayCurrentDateAndTime()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("\tCurrent Date: " + dateTime.ToLongDateString());
            Console.WriteLine("\tCurrent Time: " + dateTime.ToLongTimeString());
            Console.WriteLine("\t-=-=-=-=-=-=-=-=-=-=-=-=-\n");
        }

        /// <summary>
        /// Display a success message to the user when they have made
        /// a post
        /// </summary>
        private void PostSuccessMessage()
        {
            Console.WriteLine("Your message was posted sucessfully");
        }
    }
}
