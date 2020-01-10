using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.OnlineRadioDatabase
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException(string message) : base(message)
        {
        }
    }
}
