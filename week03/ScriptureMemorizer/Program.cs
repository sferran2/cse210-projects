using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("1 Nephi", 3, 7), 
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."), 
            new Scripture(new Reference("2 Nephi", 2, 25), 
                "Adam fell that men might be; and men are, that they might have joy."),            
            new Scripture(new Reference("2 Nephi", 2, 27), 
                "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself."),
            new Scripture(new Reference("2 Nephi", 9, 28, 29), 
                "O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish. But to be learned is good if they hearken unto the counsels of God."),            
            new Scripture(new Reference("Mosiah", 3, 19), 
                "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father."),
            new Scripture(new Reference("Alma", 32, 21), 
                "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."),            
            new Scripture(new Reference("Alma", 37, 35), 
                "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God."),            
            new Scripture(new Reference("Helaman", 5, 12), 
                "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall."),
            new Scripture(new Reference("Moroni", 10, 4, 5), 
                "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.")
        };

        //Exceeding Requirements
        // Work with a library of scriptures and choose scriptures at random to present to the user.

        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count); 
        Scripture selectedScripture = scriptures[randomIndex]; 

        Console.Clear();
        Console.WriteLine("\n" + selectedScripture.GetDisplayText());
        Console.WriteLine("\nPress ENTER to continue or type 'quit' to finish.");

        while (!selectedScripture.IsCompletelyHidden())
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            selectedScripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine("\n" + selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to continue or type 'quit' to finish.");
        }

        Console.WriteLine("\nProgram has ended.");
    }
}


