using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.OnlineRadioDatabase
{
    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message) : base(message)
        {
        }
    }
}
