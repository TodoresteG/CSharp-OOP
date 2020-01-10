using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.OnlineRadioDatabase
{
    class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException(string message) : base(message)
        {
        }
    }
}
