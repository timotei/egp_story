using System;

namespace egp_story
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TheStory game = new TheStory())
            {
                game.Run();
            }
        }
    }
#endif
}

