using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BerTlv;

namespace Parser.Utility
{
    public class TLVParserUtility
    {
        public string getParsedTLV(string rawTLV){
            var parsedTLV = "";
            var cleanedTLV = replaceWhitespace(rawTLV,"");
            if(!OnlyHexInString(cleanedTLV)){
                throw new FormatException("Invalid Hex");
            }
            ICollection<Tlv> tlvs = Tlv.ParseTlv(cleanedTLV);
            Console.WriteLine(tlvs);


            parsedTLV = cleanedTLV;
            return parsedTLV;
        }

        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string replaceWhitespace(string input, string replacement) 
        {
            return sWhitespace.Replace(input, replacement);
        }

        public bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
    
}