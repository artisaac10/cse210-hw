using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# in 20 Minutes", "Code Academy", 1200);
        video1.AddComment(new Comment("Alice", "Very helpful tutorial!"));
        video1.AddComment(new Comment("Bob", "Easy to understand."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Travel Destinations", "Travel World", 900);
        video2.AddComment(new Comment("David", "I want to visit Japan!"));
        video2.AddComment(new Comment("Emma", "Amazing video."));
        video2.AddComment(new Comment("Frank", "Great recommendations."));
        video2.AddComment(new Comment("Grace", "Beautiful scenery."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Healthy Breakfast Ideas", "Chef Sarah", 600);
        video3.AddComment(new Comment("Henry", "Looks delicious."));
        video3.AddComment(new Comment("Isabella", "I'll try this tomorrow."));
        video3.AddComment(new Comment("Jack", "Healthy and simple."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Funny Cat Compilation", "Pet Fun", 480);
        video4.AddComment(new Comment("Karen", "This made my day!"));
        video4.AddComment(new Comment("Leo", "So funny 😂"));
        video4.AddComment(new Comment("Mia", "Cats are the best."));
        video4.AddComment(new Comment("Noah", "Watched it twice."));
        videos.Add(video4);

        // Display all videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}