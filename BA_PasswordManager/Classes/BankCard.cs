using System.Runtime.Serialization;

namespace BA_PasswordManager.Classes
{
    [DataContract]
    internal class BankCard
    {
        [DataMember] internal string cardNumber;
        [DataMember] internal string owner;
        [DataMember] internal string date;
        [DataMember] internal string CVV2;

        internal string system;

        public BankCard(string cardNumber, string owner, string date, string CVV2)
        {
            this.cardNumber = cardNumber;
            this.owner = owner;
            this.date = date;
            this.CVV2 = CVV2;
            system = checkSystem();
        }


        private string checkSystem()
        {
            string cardNumber = this.cardNumber.Replace(" ", "");

            if (cardNumber.StartsWith("4") && (cardNumber.Length == 13 || cardNumber.Length == 16))
                return "Visa";
            else if (cardNumber.StartsWith("5") && cardNumber.Length == 16)
            {
                int secondDigit = int.Parse(cardNumber.Substring(1, 1));
                if (secondDigit >= 1 && secondDigit <= 5)
                    return "MasterCard";
            }
            else if (cardNumber.StartsWith("2") && cardNumber.Length == 16)
                return "Mir";
            else if ((cardNumber.StartsWith("50") || cardNumber.StartsWith("56") || cardNumber.StartsWith("57") || cardNumber.StartsWith("58") || cardNumber.StartsWith("67") || cardNumber.StartsWith("63") || cardNumber.StartsWith("68")) && (cardNumber.Length == 16 || cardNumber.Length == 19))
                return("Maestro");
            return "None";
        }



    }
}
