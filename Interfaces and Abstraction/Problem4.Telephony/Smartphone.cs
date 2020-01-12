using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string contact)
        {
            try
            {
                ValidateNumber(contact);

                return $"Calling... {contact}";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }

        }

        public string Browse(string site)
        {
            try
            {
                ValidateSite(site);

                return $"Browsing: {site}!";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }

        private void ValidateSite(string currentSite)
        {
            for (int i = 0; i < currentSite.Length; i++)
            {
                if (Char.IsDigit(currentSite[i]))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
        }

        private void ValidateNumber(string currentNumber)
        {
            for (int j = 0; j < currentNumber.Length; j++)
            {
                if (Char.IsDigit(currentNumber[j]) == false)
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
        }
    }
}
