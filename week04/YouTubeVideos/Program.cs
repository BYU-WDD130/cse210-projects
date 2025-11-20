class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Exploring Cayos Cochinos", "TravelHonduras", 420);
        Video video2 = new Video("How to Make Gelatin Art", "RedRoseDesserts", 310);
        Video video3 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);

        // Add comments to video 1
        video1.AddComment(new Comment("Ana", "Amazing place! I want to visit."));
        video1.AddComment(new Comment("Luis", "Great video, thanks for sharing."));
        video1.AddComment(new Comment("Maria", "The water looks incredible."));

        // Add comments to video 2
        video2.AddComment(new Comment("Carla", "This recipe is beautiful."));
        video2.AddComment(new Comment("Sofia", "I will try this for my mom's birthday."));
        video2.AddComment(new Comment("Pedro", "Very clear instructions!"));

        // Add comments to video 3
        video3.AddComment(new Comment("John", "This helped me a lot, thanks!"));
        video3.AddComment(new Comment("Eva", "Explained clearly."));
        video3.AddComment(new Comment("Sam", "Now I finally understand classes!"));

        // Put videos in list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
        }

        Console.WriteLine("-----------------------------------------");
    }
}