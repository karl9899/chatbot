using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BotProcivicaV3.Utilities
{
    public static class MailValidator
    {
        public static bool GetEmailAddress(string response, out string contactInfo)
        {
            /*

            contactInfo = string.Empty;
            var match1 = Regex.Match(response, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            var match2 = Regex.Match(response, "mailto:"+ @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (match1.Success)
            { //[azAZ]|[0-9]
                contactInfo = match1.Value;
                return true;
            }
            else if (match2.Success)
            { //[azAZ]|[0-9]
                contactInfo = match2.Value;
                return true;
            }
            else
                return false;
            */
            string email;
            try
            {
                if (response.Substring(0, 7).Equals("mailto:"))
                    email = response.Substring(7, response.Length - 7);
                else
                    email = response.Substring(0, response.Length);
                MailAddress m = new MailAddress(email);
                contactInfo = email;
                return true;
            }
            catch (FormatException)
            {
                contactInfo = "";
                return false;
            }
        }

        public static bool GetTwitterHandle(string response, out string contactInfo)
        {
            contactInfo = string.Empty;
            if (!response.StartsWith("@"))
                return false;
            contactInfo = response;
            return true;
        }
    }
}