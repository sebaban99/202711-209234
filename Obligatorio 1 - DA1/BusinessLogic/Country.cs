using BusinessLogic.Exceptions;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public abstract class Country
    {
        protected readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);
        protected readonly DateTime MAXIMUM_HOUR = DateTime.Today.AddHours(18);
        protected string countryTag;


        public abstract DateTime ExtractStartingHour(string message);

        public abstract int ExtractMinutes(string message);

        public abstract bool IsMessageValid(string message);

        protected abstract bool IsStartingHourValid(string[] actualMessage);

        protected abstract bool AreMinutesValid(string[] actualMessage);

        public abstract bool IsPhoneNumberValid(string phoneNumber);

        public virtual DateTime ExtractFinishingHour(string message)
        {
            DateTime finishingHour = ExtractStartingHour(message);
            finishingHour = finishingHour.AddMinutes(ExtractMinutes(message));
            if (finishingHour > MAXIMUM_HOUR)
            {
                return MAXIMUM_HOUR;
            }
            else return finishingHour;
        }

        public virtual string ExtractLicensePlate(string message)
        {
            string[] messageInArray = MessageToArray(message);
            if (messageInArray[0].Length == 7)
            {
                return FormatLicensePlate(messageInArray[0]);
            }
            else
            {
                string licensePlateInMessage = messageInArray[0] + messageInArray[1];
                return FormatLicensePlate(licensePlateInMessage);
            }
        }

        public virtual string FormatPhoneNumber(string aPhone)
        {
            return aPhone;
        }

        public string GetCountryTag()
        {
            return countryTag;
        }


        protected string[] ObtainActualMessage(string[] messageSplit)
        {
            int notEmptyStrings = 0;
            foreach (string s in messageSplit)
            {
                if (s != "")
                {
                    notEmptyStrings++;
                }
            }
            string[] actualMessage = new string[notEmptyStrings];
            int actualMessageIndex = 0;
            foreach (string s in messageSplit)
            {
                if (s != "")
                {
                    actualMessage[actualMessageIndex] = string.Copy(s);
                    actualMessageIndex++;
                }
            }
            return actualMessage;
        }

        public string[] MessageToArray(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            return ObtainActualMessage(messageSplit);
        }

        protected int StringToInt(string number)
        {
            return Int32.Parse(number);
        }

        protected virtual bool IsHourValid(string hours)
        {
            return Int32.Parse(hours) >= 10 && Int32.Parse(hours) < 18;
        }

        protected virtual bool IsMinuteValid(string minutes)
        {
            return Int32.Parse(minutes) < 60;
        }

        protected string GetTodaysDate_dd_MM_yyyy_Only()
        {
            return GetDateTimeNow().ToString("d", new CultureInfo("fr-FR"));
        }

        protected bool IsHourAfterActualHour(string hour)
        {
            return GetDateTimeNow() <= DateTime.Parse(GetTodaysDate_dd_MM_yyyy_Only()
                + " " + hour, new CultureInfo("fr-FR"));
        }

        protected bool ContainsLettersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[a-zA-Z]+$");
        }

        protected bool ContainsNumbersOnly(string message)
        {
            return Regex.IsMatch(message, @"^[0-9]+$");
        }

        protected virtual bool IsHourFormatValid(string hour)
        {
            if (hour.IndexOf(':') != hour.Length / 2)
            {
                return false;
            }
            else
            {
                string HH_half = hour.Substring(0, hour.IndexOf(':'));
                string mm_half = hour.Substring(hour.IndexOf(':') + 1);

                return HH_half.Length == 2 && mm_half.Length == 2 &&
                    ContainsNumbersOnly(HH_half) && ContainsNumbersOnly(mm_half) &&
                    IsHourValid(HH_half) && IsMinuteValid(mm_half) &&
                    IsHourAfterActualHour(hour);
            }
        }

        public virtual bool IsLicensePlateValid(string[] actualMessage)
        {
            bool isLicensePlateValid = false;
            if (actualMessage[0].Length == 7)
            {
                isLicensePlateValid =
                   ContainsLettersOnly(actualMessage[0].Substring(0, 3)) &&
                   ContainsNumbersOnly(actualMessage[0].Substring(3));
            }
            else if (actualMessage[0].Length == 3 && actualMessage[1].Length == 4)
            {
                isLicensePlateValid = ContainsLettersOnly(actualMessage[0]) &&
                    ContainsNumbersOnly(actualMessage[1]);
            }
            if (!isLicensePlateValid)
            {
                throw new BusinessException("Formato de licencia incorrecto");
            }
            else return true;
        }

        public virtual string FormatLicensePlate(string licensePlate)
        {
            StringBuilder formattedLicensePlate = new StringBuilder(licensePlate);
            formattedLicensePlate.Replace(formattedLicensePlate.ToString().Substring(0, 3),
                formattedLicensePlate.ToString().Substring(0, 3).ToUpper().Trim());
            formattedLicensePlate.Insert(3, " ");
            return formattedLicensePlate.ToString();
        }

        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
