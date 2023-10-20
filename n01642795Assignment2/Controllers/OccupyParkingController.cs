using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01642795Assignment2.Controllers
{
    /// Year 2018 - Problem J2: Occupy parking
    
    /// Changed input - instead of periods (.), used underscores (_)
    public class OccupyParkingController : ApiController
    {
        /// <summary>
        ///     Recieves the number of parking spaces in the parking lot, information about yesterday's parking spaces, and information about today's parking spaces. Outputs the number of parking spaces occupied both yesterday and today
        /// </summary>
        /// <param name="parkingSpaces"> The input number of parking spaces (as an integer) </param>
        /// <param name="parkingYesterday"> The input information about yesterday's parking spaces (as a string) (C = occupied, _ = not occupied) </param>
        /// <param name="parkingToday"> The input information about today's parking spaces (as a string) (C = occupied, _ = not occupied) </param>
        /// <returns> 
        ///     An integer (number of parking spaces that were occupied both yesterday and today) 
        /// </returns>
        /// <example>
        ///     GET api/OccupyParking/parkingLot/5/CC__C/_CC__ --> 1
        ///     GET api/OccupyParking/parkingLot/7/CCCCCCC/C_C_C_C --> 4
        /// </example>
        [HttpGet]
        [Route("api/OccupyParking/parkingLot/{parkingSpaces}/{parkingYesterday}/{parkingToday}")]
        public int parkingLot(int parkingSpaces, string parkingYesterday, string parkingToday)
        {

            // variable to keep a tally of the number of occupied spaces both yesterday and today (C's)
            int occupiedCount = 0;
            // need to offset the number of parking spaces by 1 since array index starts at 0
            int parkingSpacesOffset = parkingSpaces - 1;

            // loop for as many parking spaces
            for(int i = 0; i <= parkingSpacesOffset; i += 1)
            {
                // check if char in string is C (space is occupied) today and yesterday, if yes add to tally
                if (parkingYesterday[i] == 'C' && parkingYesterday[i] == parkingToday[i])
                {
                    occupiedCount++;
                }
            }
            
            return occupiedCount;
        }
    }
}
