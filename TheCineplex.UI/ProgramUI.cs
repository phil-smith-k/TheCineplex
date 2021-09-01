using System;
using System.Collections.Generic;
using System.Linq;
using TheCineplex.Models;
using TheCineplex.Models.Enumerations;
using TheCineplex.Models.Interfaces;
using TheCineplex.Repos;

namespace TheCineplex.UI
{
    internal class ProgramUI
    {
        private readonly MovieRepository _movieRepository = new MovieRepository();
        private readonly ConcertRepository _concertRepository = new ConcertRepository();
        //private List<MovieTicket> _tickets = new List<MovieTicket>();
        private List<Ticket> _tickets = new List<Ticket>();

        internal void Run()
        {
            this.SeedMovies();

            while (this.RunMenu());
        }

        private bool RunMenu()
        {
            this.DisplayMenu();

            switch (Console.ReadLine()) 
            {
                case "1":
                    this.AddTicket();
                    return true;
                case "2":
                    this.FinishTransaction();
                    return true;
                case "3":
                    return false;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadLine();
                    return true;
            }
        }

        private void AddTicket()
        {
            Movie movieChoice = this.ChooseMovie(_movieRepository.GetAll());
            DateTime showTime = this.ChooseDate(movieChoice.ShowTimes);
            int quantity = this.ChooseQuantity();

            //MovieTicket ticket = new MovieTicket(quantity, movieChoice, showTime);
            Ticket ticket = new Ticket(movieChoice, quantity, showTime);
            _tickets.Add(ticket);
        }

        private void FinishTransaction()
        {
            Console.Clear();

            if (!_tickets.Any())
            {
                Console.WriteLine("Please add tickets to the sale before finishing transaction");
                return;
            }

            Receipt receipt = new Receipt(_tickets);

            this.PrintReceipt(receipt);
            //Console.WriteLine(receipt.GetReceiptText());

            //Console.WriteLine();

            //foreach (var ticket in _tickets)
            //{
            //    Console.WriteLine(ticket.GetTicketText());
            //}

            Console.ReadKey();
            _tickets.Clear();
        }

        private void DisplayMovieMenu(List<Movie> movies, int index)
        {
            Console.Clear();

            foreach (var movie in movies)
            {
                if (movies.IndexOf(movie) == index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(movie);
                    Console.ResetColor();

                    continue;
                }

                Console.WriteLine(movie);
            }
        }

        private Movie ChooseMovie(List<Movie> movies)
        {
            int movieCount = movies.Count;
            int index = default;

            void DecrementIndex()
            {
                if (--index < 0)
                {
                    index = movieCount - 1;
                }
            }
            void IncrementIndex()
            {
                if (++index >= movieCount)
                {
                    index = default;
                }
            }

            while (true)
            {
                this.DisplayMovieMenu(movies, index);
                switch (Console.ReadKey().Key) 
                {
                    case ConsoleKey.UpArrow:
                        DecrementIndex();
                        break;
                    case ConsoleKey.DownArrow:
                        IncrementIndex();
                        break;
                    case ConsoleKey.Enter:
                        return movies.ElementAt(index);
                }
            }
        }

        private void DisplayDateMenu(List<DateTime> showTimes, int index)
        {
            Console.Clear();

            foreach (var date in showTimes)
            {
                if (showTimes.IndexOf(date) == index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(date);
                    Console.ResetColor();

                    continue;
                }

                Console.WriteLine(date);
            }
        }

        private DateTime ChooseDate(List<DateTime> showTimes)
        {
            int movieCount = showTimes.Count;
            int index = default;

            while (true)
            {
                this.DisplayDateMenu(showTimes, index);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (--index < default(int))
                        {
                            index = movieCount - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (++index >= movieCount)
                        {
                            index = default;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return showTimes.ElementAt(index);
                }
            }
        }

        private int ChooseQuantity()
        {
            return this.PromptUserForInt("How many tickets?", "Not a valid number.");
        }

        private int PromptUserForInt(string message, string errorMessage)
        {
            int result;

            Console.Clear();
            Console.WriteLine(message);

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(errorMessage);
            }

            return result;
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine($"----- MAIN MENU ------\n" +
                              $"1. Sell Ticket\n" +
                              $"2. Finish Transaction\n" +
                              $"3. Exit\n");
        }

        private void PrintReceipt(Receipt receipt)
        {
            foreach (var ticket in receipt.Tickets)
            {
                this.Print(ticket);
            }

            this.Print(receipt);
        }

        private void Print(IPrintable printable)
        {
            Console.WriteLine(printable.GenerateText());
        }

        private void SeedMovies()
        {
            DateTime showTime1 = new DateTime(2021, 6, 24, 18, 0, 0);
            DateTime showTime2 = new DateTime(2021, 6, 24, 20, 0, 0);
            DateTime showTime3 = new DateTime(2021, 6, 25, 10, 30, 0);
            DateTime showTime4 = new DateTime(2021, 6, 25, 17, 30, 0);
            DateTime showTime5 = new DateTime(2021, 6, 25, 20, 0, 0);
            DateTime showTime6 = new DateTime(2021, 6, 26, 16, 0, 0);
            DateTime showTime7 = new DateTime(2021, 6, 26, 19, 45, 0);
            DateTime showTime8 = new DateTime(2021, 6, 26, 21, 30, 0);

            List<DateTime> showTimes = new List<DateTime>
            {
                showTime1,
                showTime2,
                showTime3,
                showTime4,
                showTime5,
                showTime6,
                showTime7,
                showTime8,
            };

            _movieRepository.Create(new Movie("A Quiet Place", Rating.PG13, showTimes));
            _movieRepository.Create(new Movie("Pulp Fiction", Rating.R, showTimes));
            _movieRepository.Create(new Movie("The Devil Wears Prada", Rating.PG13, showTimes));
            _movieRepository.Create(new Movie("Frozen II", Rating.G, showTimes));
            _movieRepository.Create(new Movie("In The Heights", Rating.PG, showTimes));
            _movieRepository.Create(new Movie("It", Rating.R, showTimes));
        }

        private void SeedConcerts()
        {
            DateTime showTime1 = new DateTime(2021, 6, 24, 18, 0, 0);
            DateTime showTime2 = new DateTime(2021, 6, 24, 20, 0, 0);
            DateTime showTime3 = new DateTime(2021, 6, 25, 10, 30, 0);

            List<DateTime> showTimes = new List<DateTime>
            {
                showTime1,
                showTime2,
                showTime3
            };

            Concert concert1 = new Concert("Lady Gaga", showTimes);
            Concert concert2 = new Concert("Taylor Swift", showTimes);
            Concert concert3 = new Concert("Kendrick Lamar", showTimes);

            _concertRepository.Create(concert1);
            _concertRepository.Create(concert2);
            _concertRepository.Create(concert3);
        }
    }
}