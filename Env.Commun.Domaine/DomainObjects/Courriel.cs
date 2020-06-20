using System.Text.RegularExpressions;

namespace Env.Commun.Domaine
{
    public class Courriel
    {
        public const int CourrielMaxLength = 254;
        public const int CourrielMinLength = 5;
        public string Adresse { get; private set; }

        public Courriel(string adresse)
        {
            if (!Valider(adresse)) throw new DomainException("Courriel invalide");
            Adresse = adresse;
        }

        public static bool Valider(string courriel)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(courriel) && courriel.Length <= CourrielMaxLength && courriel.Length >= CourrielMinLength;
        }
    }
}