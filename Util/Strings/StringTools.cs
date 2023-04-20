using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Enigma.Util
{
    public static class StringTools
    {
        public static string Replicate(char caracter, int numchar)
        {
            return new string(caracter, numchar);
        }

        public static string Replicate(string texto, int numchar)
        {
            return string.Concat(System.Collections.ArrayList.Repeat(texto, numchar).ToArray());
        }

        public static string Left(string str, int count)
        {
            if (string.IsNullOrWhiteSpace(str) || count < 1)
                return str;

            return str.Substring(0, Math.Min(count, str.Length));
        }

        public static string Right(string str, int count)
        {
            if (string.IsNullOrWhiteSpace(str) || count < 1)
            {
                return str;
            }


            return (str.Length <= count
                ? str
                : str.Substring(str.Length - count, count)
                );

        }

        /// <summary>
        /// Retorna la cadena sin los espacios en blanco a la derecha y a la izquierda
        /// </summary>
        /// <param name="cadenaTexto"></param>
        /// <returns></returns>
        public static string TrimAll(string cadenaTexto)
        {
            string resultado;
            resultado = cadenaTexto;
            resultado.TrimEnd();
            resultado.TrimStart();
            return resultado;
        }
    }
}
