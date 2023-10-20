using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01642795Assignment2.Controllers
{
    /// Year 2018 - Problem J1: Telemarketer or not?
    public class TelemarketerController : ApiController
    {
        /// <summary>
        ///     Recieves the last 4 digits of a phone number, outputs whether to answer the call based on if the number is a telemarketer number
        /// </summary>
        /// <param name="digit1"> The input number of the first digit (as an integer) </param>
        /// <param name="digit2"> The input number of the second digit (as an integer) </param>
        /// <param name="digit3"> The input number of the third digit (as an integer) </param>
        /// <param name="digit4"> The input number of the fourth digit (as an integer) </param>
        /// <returns>
        ///     A string ("ignore" if a telemarketer number, "answer" if not a telemarketer number)
        /// </returns>
        /// <example>
        ///     GET api/Telemarketer/phoneNumber/9/6/6/8 --> "ignore"
        ///     GET api/Telemarketer/phoneNumber/5/6/6/8 --> "answer"
        /// </example>
        [HttpGet]
        [Route("api/Telemarketer/phoneNumber/{digit1}/{digit2}/{digit3}/{digit4}")]
        public string phoneNumber(int digit1, int digit2, int digit3, int digit4)
        {
            // phone number is a telemarketer number if it has these 3 properties:
                // 1) the first digit is an 8 or 9
                // 2) the last digit is an 8 or 9
                // 3) the second and third digits are the same

            // telemarketer variable remains false (not a telemarketer) unless all 3 properties are true
            bool telemarketer = false;
            string message = "";

            // 1) check if first digit is an 8 or 9, if yes continue to check other digits
            if (digit1 == 8 || digit1 == 9) 
            { 
                // 2) check if last digit is an 8 or 9, if yes continue to check other digits
                if (digit4 == 8 || digit4 == 9)
                {
                    // 3) check if second and third digits are the same, if yes set telemarketer to true (number is a telemarketer)
                    if (digit2 == digit3)
                    {
                        telemarketer = true;
                    }
                }
            }

            // set output message to say "ignore" if a telemarketer number and "answer" if not
            if (telemarketer == true) 
            {
                message = "ignore";
            }
            else
            {
                message = "answer";
            }

            return message;
        }
    }
}
