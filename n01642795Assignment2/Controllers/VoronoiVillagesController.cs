using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01642795Assignment2.Controllers
{
    /// Year 2018 - Problem S1: Voronoi Villages
 
    /// Changed input - instead of separate parameters for each village's position, all the positions are in a string separated by commas
    public class VoronoiVillagesController : ApiController
    {
        /// <summary>
        ///     Recieves the number of villages along a straight road and the distinct positions of each of these villages. Outputs the smallest neighbourhood size.
        /// </summary>
        /// <param name="numVillages"> The input number of villages (as an integer) </param>
        /// <param name="villages"> The input positions of the villages (as a string with positions separated by commas) </param>
        /// <returns> 
        ///     A string (size of the smallest neighbourhood) 
        /// </returns>
        /// <example>
        ///     GET api/VoronoiVillages/neighbourhoods/5/16,0,10,4,15 --> "3.0"
        /// </example>
        [HttpGet]
        [Route("api/VoronoiVillages/neighbourhoods/{numVillages}/{villages}")]
        public string neighbourhoods(int numVillages, string villages)
        {
            // handle input
                // separate the string by the comma to get each individual village, put into a string array (since input is a string)
                string[] villagesString = villages.Split(',');
                // convert string array to double array so we can perform operations with the numbers
                double[] villagesList = Array.ConvertAll(villagesString, double.Parse);

            // sort array from least to greatest
            Array.Sort(villagesList);

               
            // we know that the smallest neighbourhood can't be the lowest or the highest since they are infinite, so loop only for i = 1 to i = numVillages - 2 (minus 2 since index starts at 0)
            var max = numVillages - 2;
            // variable to store smallest neighbourhood size
            var smallestNeighbourhood = 0.0;

            for (int i = 1;  i <= max; i += 1)
            {
                // calculate distance left of village
                var distanceLeft = villagesList[i] - villagesList[i - 1];
                distanceLeft = distanceLeft / 2;

                // calculate distance right of village
                var distanceRight = villagesList[i + 1] - villagesList[i];
                distanceRight = distanceRight / 2;

                // calculate total size of neighbourhood
                var neighbourhood = distanceLeft + distanceRight;

                // if smallest neighbourhood, assign size to the smallestNeighbourhood variable
                if (i == 1)
                {
                    smallestNeighbourhood = neighbourhood;
                }  
                else if (neighbourhood < smallestNeighbourhood)
                {
                    smallestNeighbourhood = neighbourhood;
                }
            }

            // to format to one decimal place
            string preciseSmallest = smallestNeighbourhood.ToString("0.0");

            return preciseSmallest;
        }
    }
}
