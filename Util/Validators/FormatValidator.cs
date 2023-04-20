using System.Text.RegularExpressions;

namespace Util.Validators
{
    public class FormatValidator
    {
        /// <summary>
        /// Expresion Regular para validar los emails
        /// </summary>
        /// <param name="nulos">email</param>
        /// <returns></returns>
        public static bool ValidarEmail(string email)
        {
            /*RegexOptions Options = RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline;
            Regex regexEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", Options);
            return regexEmail.IsMatch(email);*/

            string MatchEmailPattern =
                   @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            

            return Regex.IsMatch(email, MatchEmailPattern);
        }
    }
}