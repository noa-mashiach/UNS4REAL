using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UNS
{
    class Login
    {
       
        /// <summary>
        /// This function logins the user on success and return error on failure.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="userPassword">The users password.</param>
        /// <returns>Boolean</returns>
        public static int DoLogin(string userName, string userPassword)
        {
            //  Check if the userName and the password are in the right length.
            if(Utilities.VerifyLength(userName) == false)
            {
                return Config.BAD_USER_LENGTH;
            }
            if (Utilities.VerifyLength(userPassword) == false)
            {
                return Config.BAD_PASS_LENGTH;
            }
            
            string hashedPassword = Utilities.MD5(userPassword);

            DataTable loginQuery = Utilities.Query("SELECT Id FROM [dbo].[Student] WHERE Username='" + userName + "' AND Password='" + hashedPassword + "';");

            if (loginQuery.Rows.Count > 0)
            {
                return Config.LOGIN_OK;
            }
            else
            {
                return Config.BAD_USER_OR_PASS;
            }
        }


    }
}
