using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;


namespace UNS
{
    class Utilities
    {
         // <summary>
        /// Excecute our query.
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>DataTable</returns>
        public static DataTable Query(string query)
        {
            // Creates an SQL connection.
            SqlConnection con = new SqlConnection(Config.DATABASE_CONNECTION_STRING);
            // Opens the connection. 
            con.Open();
            // Execute our query parameter.(מריץ את השאילתה שקיבלנו כפרמטר)
            SqlCommand cmd = new SqlCommand(query, con);
            // לחבר בין מה שחזר מהשאילתה לבין המבנה של מידע שייצרנו
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // DataTable - טבלה זמנית אשר אנו ממלאים אותה בתוצאה שחזרה מהשאילתה 
            DataTable dt = new DataTable();
            // ממלא את התוכן של המקשר בטבלה הזמנית
            da.Fill(dt);

            return dt;
        }
                  

        /// <summary>
        /// This function verifies the user input if its in the correct length.
        /// </summary>
        /// <param name="userInput">User input (username/password)</param>
        /// <returns>Boolean</returns>
        public static bool VerifyLength(string userInput)
        {
            if (userInput.Length < Config.MINIMUM_LOGIN_INPUT_LENGTH || userInput.Length > Config.MAXIMUM_LOGIN_INPUT_LENGTH)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Converts the input to bytes, and then encodes to base64.
        /// </summary>
        /// <param name="inputString">The string to be encoded in base64</param>
        /// <returns>String</returns>
        public static string Base64Encode(string inputString)
        {
            var inputStringBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            return System.Convert.ToBase64String(inputStringBytes);
        }

        /// <summary>
        /// Converts base64 encoded date into bytes and then to string.
        /// This function is the opposite of the Base64Encode function.
        /// </summary>
        /// <param name="encodedString">The string to be decoded in base64</param>
        /// <returns>String</returns>
        public static string Base64Decode(string encodedString)
        {
            var encodedStringBytes = System.Convert.FromBase64String(encodedString);
            return System.Text.Encoding.UTF8.GetString(encodedStringBytes);
        }

        /// <summary>
        /// MD5 = Function that convert the inputString to MD5 hash. 
        /// </summary>
        /// <param name="inputString">string</param>
        /// <returns>string</returns>
        public static string MD5 (string inputString)
        {
            // MD5 class instance that will MD5 our bytes array.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            // The class that will convert our inputString to Bytes.
            UTF8Encoding encode = new UTF8Encoding();
            // Class that will convert the hash bytes to string.
            StringBuilder encryptdata = new StringBuilder();

            byte[] hashedBytes;
            byte[] encodedPassword = encode.GetBytes(inputString);
            // Calc the MD5 hash.
            hashedBytes = md5.ComputeHash(encodedPassword);
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                encryptdata.Append(hashedBytes[i].ToString());
            }

            return encryptdata.ToString();
        }
    }
}
