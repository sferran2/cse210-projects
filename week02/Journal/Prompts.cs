using System;
using System.Collections.Generic;

public class Prompts
{
     public List<string> _prompts = new List<string>
     {
         "What are three things I am grateful for today, and why?",
         "How have I grown as a person in the past year?",
         "What is one fear I need to face, and what small step can I take toward overcoming it?",
         "What do I admire most about myself?",
         "What is one lesson I have learned recently that has changed my perspective?",
         "If I could give my younger self one piece of advice, what would it be?",
         "How do I typically handle challenges, and what could I improve?",
         "When do I feel most at peace? How can I invite more of that into my life?",
         "What negative thought patterns do I want to break, and how can I reframe them?",
         "How can I show more kindness and patience toward myself?",
         "How has God shown His love for me this week?",
         "How have I felt God answering my prayers recently?",
         "What principle of the gospel do I want to focus on this week?",
         "What is one personal or professional goal I want to achieve this year?",
         "What motivates me to keep pushing forward, even when things get hard?",
         "If I had unlimited resources and time, what dream would I pursue?",
         "How can I turn my current obstacles into opportunities for growth?",
         "What daily habits would help me become the person I want to be?",
         "What small wins have I accomplished recently that deserve celebration?",
         "What is one thing I need to let go of to move forward?",
         "What legacy do I want to leave behind, and how can I start building it today?"
      };

     public string GetRandomPrompt()
     {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
     }
}