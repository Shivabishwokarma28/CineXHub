/*using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebsite.Models;

namespace MovieStoreWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string searchString)
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Interstellar", Genre = "Sci-Fi", ReleaseDate = new DateTime(2014, 11, 7), ImageUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6vCU67oUEBE97.jpg" },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseDate = new DateTime(2008, 7, 18), ImageUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDp9QmSbmvQYhhq0ws2.jpg" },
                new Movie { Id = 3, Title = "Inception", Genre = "Sci-Fi", ReleaseDate = new DateTime(2010, 7, 16), ImageUrl = "https://image.tmdb.org/t/p/w500/9gk7Fn9sVAsS9699G1o3oH0mS0C.jpg" },
                new Movie { Id = 4, Title = "The Godfather", Genre = "Crime", ReleaseDate = new DateTime(1972, 3, 24), ImageUrl = "https://image.tmdb.org/t/p/w500/3bhkrjOiZ46UfkbbV9U1KlxuoE9.jpg" },
                new Movie { Id = 5, Title = "Pulp Fiction", Genre = "Crime", ReleaseDate = new DateTime(1994, 10, 14), ImageUrl = "https://image.tmdb.org/t/p/w500/d5iIl9h9btztp9kdccS0KGlyic6.jpg" },
                new Movie { Id = 6, Title = "Spider-Man: No Way Home", Genre = "Action", ReleaseDate = new DateTime(2021, 12, 17), ImageUrl = "https://image.tmdb.org/t/p/w500/1g0mXp91Y9Tj9Cy7zSSTz6S47Nt.jpg" },
                new Movie { Id = 7, Title = "The Matrix", Genre = "Sci-Fi", ReleaseDate = new DateTime(1999, 3, 31), ImageUrl = "https://image.tmdb.org/t/p/w500/f89U3Y9L9u2MvOqtS36Yv7C9e9Q.jpg" },
                new Movie { Id = 8, Title = "Gladiator", Genre = "Drama", ReleaseDate = new DateTime(2000, 5, 5), ImageUrl = "https://image.tmdb.org/t/p/w500/ty8TGRjS2v2v12YUNn080vQZwoG.jpg" },
                new Movie { Id = 9, Title = "Avengers: Endgame", Genre = "Action", ReleaseDate = new DateTime(2019, 4, 26), ImageUrl = "https://image.tmdb.org/t/p/w500/or06vS3neeB0vYvS0vPw2pSTX9q.jpg" },
                new Movie { Id = 10, Title = "Joker", Genre = "Drama", ReleaseDate = new DateTime(2019, 10, 4), ImageUrl = "https://image.tmdb.org/t/p/w500/udDclpUhpqhp3EtU6ym0fwX3B9V.jpg" }
            };

            // Search Logic
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Details(int id)
        {
            // 1. You must have the same list of 10 movies here
            var allMovies = GetMyMovies();

            // 2. Use .FirstOrDefault to find the ONE movie that matches the ID
            var selectedMovie = allMovies.FirstOrDefault(m => m.Id == id);

            // 3. Safety check: if ID doesn't exist, don't crash, show 404
            if (selectedMovie == null)
            {
                return NotFound();
            }

            // 4. Send ONLY that one movie to the view
            return View(selectedMovie);
        }

        // To avoid repeating your 10 movies, create this private method at the bottom of the controller
        private List<Movie> GetMyMovies()
        {
            return new List<Movie>
    {
        new Movie { Id = 1, Title = "Interstellar", Genre = "Sci-Fi", Description = "Explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", ImageUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6vCU67oUEBE97.jpg", ReleaseDate = new DateTime(2014, 11, 7) },
        new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", ImageUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDp9QmSbmvQYhhq0ws2.jpg", ReleaseDate = new DateTime(2008, 7, 18) },
        new Movie { Id = 3, Title = "Inception", Genre = "Sci-Fi", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", ImageUrl = "https://image.tmdb.org/t/p/w500/9gk7Fn9sVAsS9699G1o3oH0mS0C.jpg", ReleaseDate = new DateTime(2010, 7, 16) },
        new Movie { Id = 4, Title = "The Godfather", Genre = "Crime", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", ImageUrl = "https://image.tmdb.org/t/p/w500/3bhkrjOiZ46UfkbbV9U1KlxuoE9.jpg", ReleaseDate = new DateTime(1972, 3, 24) },
        new Movie { Id = 5, Title = "Pulp Fiction", Genre = "Crime", Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", ImageUrl = "https://image.tmdb.org/t/p/w500/d5iIl9h9btztp9kdccS0KGlyic6.jpg", ReleaseDate = new DateTime(1994, 10, 14) },
        new Movie { Id = 6, Title = "Spider-Man: No Way Home", Genre = "Action", Description = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear.", ImageUrl = "https://image.tmdb.org/t/p/w500/1g0mXp91Y9Tj9Cy7zSSTz6S47Nt.jpg", ReleaseDate = new DateTime(2021, 12, 17) },
        new Movie { Id = 7, Title = "The Matrix", Genre = "Sci-Fi", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", ImageUrl = "https://image.tmdb.org/t/p/w500/f89U3Y9L9u2MvOqtS36Yv7C9e9Q.jpg", ReleaseDate = new DateTime(1999, 3, 31) },
        new Movie { Id = 8, Title = "Gladiator", Genre = "Drama", Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", ImageUrl = "https://image.tmdb.org/t/p/w500/ty8TGRjS2v2v12YUNn080vQZwoG.jpg", ReleaseDate = new DateTime(2000, 5, 5) },
        new Movie { Id = 9, Title = "Avengers: Endgame", Genre = "Action", Description = "After the devastating events of Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more.", ImageUrl = "https://image.tmdb.org/t/p/w500/or06vS3neeB0vYvS0vPw2pSTX9q.jpg", ReleaseDate = new DateTime(2019, 4, 26) },
        new Movie { Id = 10, Title = "Joker", Genre = "Drama", Description = "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime.", ImageUrl = "https://image.tmdb.org/t/p/w500/udDclpUhpqhp3EtU6ym0fwX3B9V.jpg", ReleaseDate = new DateTime(2019, 10, 4) }
    };
        }
        // ... add the rest of your 10 movies here
    };
        }
    }
    }
}
*/
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebsite.Models;

namespace MovieStoreWebsite.Controllers
{
    public class HomeController : Controller
    {
        // 1. DATA LAYER: This list is visible to EVERYTHING inside this class.
        private static readonly List<Movie> _movieLibrary = new List<Movie>
{
    new Movie { Id = 1, Title = "Interstellar", Genre = "Sci-Fi", Description = "Explorers travel through a wormhole...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg", ReleaseDate = new DateTime(2014, 11, 7) },
    new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", Description = "Batman faces the Joker...", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRgMtkGBfHb06Qfe-eI5WYVbzMZ18yHhdowsA&s", ReleaseDate = new DateTime(2008, 7, 18) },
    new Movie { Id = 3, Title = "Inception", Genre = "Sci-Fi", Description = "A thief steals secrets through dreams...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", ReleaseDate = new DateTime(2010, 7, 16) },
    new Movie { Id = 4, Title = "The Godfather", Genre = "Crime", Description = "The patriarch of a crime dynasty...", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShj353-31As6Sj8JGXEDsJOvGWg9qnmC7Svw&s", ReleaseDate = new DateTime(1972, 3, 24) },
    new Movie { Id = 5, Title = "Pulp Fiction", Genre = "Crime", Description = "Hitmen and gangsters intertwine...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg", ReleaseDate = new DateTime(1994, 10, 14) },
    new Movie { Id = 6, Title = "Spider-Man: No Way Home", Genre = "Action", Description = "Peter asks Doctor Strange for help...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", ReleaseDate = new DateTime(2021, 12, 17) },
    new Movie { Id = 7, Title = "The Matrix", Genre = "Sci-Fi", Description = "A hacker learns the true nature of reality...", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfSjSWOCaw5dnDL2GT1zFd9RMCgUGw5Q2Cfg&s", ReleaseDate = new DateTime(1999, 3, 31) },
    new Movie { Id = 8, Title = "Gladiator", Genre = "Drama", Description = "A General sets out to exact vengeance...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/Gladiator_%282000_film_poster%29.png", ReleaseDate = new DateTime(2000, 5, 5) },
    new Movie { Id = 9, Title = "Avengers: Endgame", Genre = "Action", Description = "The Avengers assemble once more...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", ReleaseDate = new DateTime(2019, 4, 26) },
    new Movie { Id = 10, Title = "Joker", Genre = "Drama", Description = "A mentally troubled comedian spirals...", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e1/Joker_%282019_film%29_poster.jpg", ReleaseDate = new DateTime(2019, 10, 4) }
};

        // 2. INDEX PAGE: Grabs the full list from the bucket
        public IActionResult Index(string searchString)
        {
            var movies = _movieLibrary;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(movies);
        }

        // 3. DETAILS PAGE: Grabs ONE specific movie from the same bucket
        public IActionResult Details(int id)
        {
            var movie = _movieLibrary.FirstOrDefault(m => m.Id == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About() => View();
    }
}