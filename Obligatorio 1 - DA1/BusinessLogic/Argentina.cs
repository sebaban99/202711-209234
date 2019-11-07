using System;
using System.Text;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Argentina
    {
        public Argentina() { }

        private bool IsPhoneNumberLengthValid(string phoneNumber)
        {
            return phoneNumber.Length == 6 || phoneNumber.Length == 7 ||
                phoneNumber.Length == 8;
        }

        private bool IsHyphenPositionValid(string phoneNumber)
        {
            return phoneNumber.IndexOf("-") != 0 &&
                phoneNumber.IndexOf("-") != phoneNumber.Length - 1;
        }

        private string RemoveHyphensFromString(string phoneNumber)
        {
            StringBuilder onlyNumbers = new StringBuilder(phoneNumber);
            onlyNumbers.Replace("-", "");
            return onlyNumbers.ToString();
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            if (IsHyphenPositionValid(phoneNumber) &&
                IsPhoneNumberLengthValid(RemoveHyphensFromString(phoneNumber)))
            {
                return true;
            }
            else
            {
                throw new BusinessException("Número de teléfono inválido, " +
                         "guión en primera posición");
            }
        }

        private string[] ObtainActualMessage(string[] messageSplit)
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

        public bool IsMessageValid(string message)
        {
            string[] messageSplit = message.Split(new Char[] { ' ' });
            string[] actualMessage = ObtainActualMessage(messageSplit);
            return IsMessageLengthValid(actualMessage);

        }

        private bool IsMessageLengthValid(string[] actualMessage)
        {
            if (actualMessage.Length == 3 || actualMessage.Length == 4)
            {
                return true;
            }
            else
            {
                throw new BusinessException("Largo de mensaje incorrecto, " +
                    "verificar mensaje");
            }
        }


        public virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
