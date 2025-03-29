using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Cook Rice in a Rice Cooker (EASY)", "Tu Ngo", 273);
        Video video2 = new Video("The Most AMAZING Vanilla Cake Recipe", "Preppy Kitchen", 395);
        Video video3 = new Video("10 Minute Yoga Full Body Stretch for Stiff Bodies", "Yoga with Bird", 611);
        Video video4 = new Video("Top 25 Places To Visit in 2025(The Year Of Travel)", "Kemoy Martin", 605);

        video1.AddComment(new Comment("@lisarucker8161","I love how you celebrate the sound of the rice hitting the pot.  What a nice moment."));
        video1.AddComment(new Comment("@deathklok69", "Thank you! I just purchased my first rice cooker and now i feel confident to use it properly!"));

        video2.AddComment(new Comment("@amyk.644", "I love your focus on the details and how you constantly tell us what bad things would happen if we did it differently."));
        video2.AddComment(new Comment("@amyspeers8012", "Your sprinkle drawer is EVERYTHING!"));
        video2.AddComment(new Comment("@malvar3665", "Finding this channel is the worst thing that has ever happened to my diet plans, thank you."));

        video3.AddComment(new Comment("@loriforsyth2410", "One thing I appreciate is your moments of quiet. Lots of other yoga leaders talk about calm, but they talk so much that it's hard to find it."));
        video3.AddComment(new Comment("@daftoptimist", "Thank you; I work from home and after a particularly stressful morning at my desk this put me back in the right frame of mind."));
        video3.AddComment(new Comment("@khushi5891", "I was frustrated unable to find a workout especially since I'm unable to go to the gym, and my workout was messed up. I chose to end up with a 10 minutes yoga. Absolutely greatful."));

        video4.AddComment(new Comment("@KAldrich17", "Great video!! Keep up the great work"));
        video4.AddComment(new Comment("@happilydivorced7777", "As a proud South African, I’m glad you included our Mother City, Cape Town. I love it too. It’s my favourite destination."));
        video4.AddComment(new Comment("@izlandsisterztv8792", "Definitely would like to visit Tokyo, my son visited last year. Paris is definitely overhyped."));
        video4.AddComment(new Comment ("@gradmajackie338", "these are all nice places but I am just to drawn to the Caribbean and Riviera Maya. My spirit and soul has been drawn there for the past 9 years"));
  
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

      
        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine(new string('-', 80));
        }
    }
}