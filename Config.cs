using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS
{
    class Config
    {
        // =============================
        // Database Section
        // =============================
        public const string DATABASE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Users\noni\Desktop\UNS\UNS\UNS\data\UNS.mdf;Integrated Security=True;";

        // =============================
        // Login & Register Section
        // =============================
        public const int MAXIMUM_LOGIN_INPUT_LENGTH = 32;   // Maximum user/password input length
        public const int MINIMUM_LOGIN_INPUT_LENGTH = 3;    // Minimum user/password input length
        public const int LOGIN_OK = 1;                      // Login was success
        public const int BAD_USER_LENGTH = 2;               // Bad username length
        public const int BAD_PASS_LENGTH = 4;               // Bad password length
        public const int BAD_USER_OR_PASS = 3;              // Login - Incorrect username or password
        public const int REGISTER_OK = 1;                   // Register was success
        public const int USER_EXISTS = 3;                   // Register - User already exists
    }
}
