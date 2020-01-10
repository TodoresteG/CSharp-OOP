using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problem4.OnlineRadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] songArgs = Console.ReadLine().Split(';');

                string artist = songArgs[0];
                string name = songArgs[1];
                string[] length = songArgs[2].Split(':');


                try
                {
                    if (songArgs.Length < 3)
                    {
                        throw new InvalidSongException("Invalid song.");
                    }

                    bool isMinutes = int.TryParse(length[0], out int minutes);
                    bool isSeconds = int.TryParse(length[1], out int seconds);

                    if (isMinutes == false || isSeconds == false)
                    {
                        throw new InvalidSongLengthException("Invalid song length.");
                    }

                    Song song = new Song(artist, name, minutes, seconds);
                    this.songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            int totalSeconds = this.songs.Sum(x => x.Minutes * 60 + x.Seconds);

            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Songs added: {this.songs.Count}");
            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }
    }
}
