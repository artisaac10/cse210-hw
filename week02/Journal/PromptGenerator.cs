using System;
using System.Collections.Generic;

public class PromptGenerator
{
//options for what prompt can be given
    private List<string> _prompts = new List<string>()
    {
        "What was your favorite part about today?",
        "How did you show Christs love to people around you?",
        "Where did you go today for lunch?",
        "What was your favorite thing you ate today and why?",
        "If you could change one part of your day what would you change?"
    };
      private Random _random = new Random();
//break it into digits that the code can randomly select to generate a prompt
      public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}