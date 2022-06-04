using System;

namespace AuthorProblem
{
    [Author("Victor")]
    class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Nikola")]
        public void Sum()
        {

        }

        [Author("Nikola")]
        public void Set()
        {

        }
    }
}
