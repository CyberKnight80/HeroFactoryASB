namespace CinemaProject
{
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Client film = new Client(new FilmFactory());
    //         film.setReales();
    //         film.setScore();
    //
    //         Client serial = new Client(new SerialFactory());
    //         serial.setReales();
    //         serial.setScore();
    //
    //         Console.ReadLine();
    //     }
    // }

    public interface Score
    {
        public void score();
    }

    public interface Release
    {
        public void release();
    }

    class addScore : Score
    {
        public void score()
        {
            Console.WriteLine("add score");
        }
    }

    class removeScore : Score
    {
        public void score()
        {
            Console.WriteLine("remove score");
        }
    }

    class releaseDate : Release
    {
        public void release()
        {
            Console.WriteLine("release date");
        }
    }

    class addReleaseDate : Release
    {
        public void release()
        {
            Console.WriteLine("add release date");
        }
    }

    abstract class cinemaFactory
    {
        public abstract Score createScore();
        public abstract Release createRelease();

    }

    class FilmFactory : cinemaFactory
    {
        public override Release createRelease()
        {
            return new addReleaseDate();
        }

        public override Score createScore()
        {
            return new addScore();
        }
    }

    class SerialFactory : cinemaFactory
    {
        public override Release createRelease()
        {
            return new releaseDate();
        }

        public override Score createScore()
        {
            return new removeScore();
        }
    }

    class Client
    {
        private Score score;
        private Release release;

        public Client(cinemaFactory factory)
        {
            score = factory.createScore();
            release = factory.createRelease();
        }

        public void setReales()
        {
            release.release();
        }

        public void setScore()
        {
            score.score();
        }
    }
}