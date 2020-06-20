using System;
using System.Text.RegularExpressions;

namespace Env.Commun.Domaine
{
    public class CodePostal
    {
        public const int CodePostalLength = 11;
        public string Code { get; private set; }

        public CodePostal(string code)
        {
            if (!Valider(code)) throw new DomainException("Code postal invalide");
            Code = code;
        }

        public bool Valider(string postalCode)
        {
            //Canadian Postal Code in the format of "H0H 0H0"
            var pattern = "^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$";

            var reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            return reg.IsMatch(postalCode) && Code.Replace(" ", String.Empty).Length != CodePostalLength;
        }
    }
}