using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS
{
    class Register
    {
        public static int DoRegister (string userName, string password)
        {
            if (Utilities.VerifyLength(userName) == false)
            {
                return Config.BAD_USER_LENGTH;
            }
            if (Utilities.VerifyLength(password) == false)
            {
                return Config.BAD_PASS_LENGTH;
            }

            /**
            // GetUserList = gets the users file content into an array.
            string[] usersList = Utilities.GetUserList();

            for (int i = 0; i<usersList.Length; i++)
            {
                // divide the each line into user and password array.
                string[] currentUser = usersList[i].Split(':');
                // compare the input user name with the decoded current user name.
                if(userName == Utilities.Base64Decode(currentUser[0]))
                {
                    return Config.USER_EXISTS;
                }

            }
            */


            // Encode and MD5 our inputs.
            string encodedUserName = Utilities.Base64Encode(userName);
            string hashedPassword = Utilities.MD5(password);

            string appendLine = encodedUserName + ":" + hashedPassword;

            // insert to the database.
            Utilities.AppendToFile(Config.DATABASE_FILE_PATH, appendLine);
            return Config.REGISTER_OK;
        }
    }
}
