using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.queries
{
    public static class GetAvailableTimes
    {
        // here we parse the GET query parameters from api call and look in the db for the records.
        public static List<DateTime> GetAll(List<BusyTime> busyTimes, Dictionary<string, string> userData, CultureInfo culture)
        {
            List<DateTime> AvailableTimes = new List<DateTime>();
            
            // all the query parameters are parsed here, simple
            var earliest = DateTime.Parse(userData["Earliest"], culture).ToUniversalTime();
            var UserSuggestedTimeLocal = DateTime.Parse(userData["Earliest"], culture);
            var latest = DateTime.Parse(userData["Latest"], culture).ToUniversalTime();
            var length = int.Parse(userData["Length"]);

            // parsing the 8-17 working hours into actual datetime objects
            var OfficeHourStart = DateTime.ParseExact(userData["Office Hours"].Split("-")[0],"HH", CultureInfo.InvariantCulture);
            var OfficeHourEnd= DateTime.ParseExact(userData["Office Hours"].Split("-")[1], "HH", CultureInfo.InvariantCulture);

            // set the time to be compared with db to earlies, this will be checked against all records,
            // then will be incremented by meeting duration to find next available slot
            DateTime TimeToCompare = earliest;

            while (DateTime.Compare(TimeToCompare.AddMinutes(length), latest) <= 0)
            {
                var IsAvailable = true;
                foreach (BusyTime busyTime in busyTimes)
                {
                    // checks if requested time is conflicting with another meeting, or is it before or after working hours
                    // if any of this checks fails the current time candidate wont be returned as a viable time
                    if ((DateTime.Compare(TimeToCompare, busyTime.EmployeeMeetingEnd) <= 0
                        && DateTime.Compare(TimeToCompare, busyTime.EmployeeMeetingStart) >= 0) 
                        || TimeToCompare.TimeOfDay < OfficeHourStart.TimeOfDay
                        || TimeToCompare.AddMinutes(length).TimeOfDay > OfficeHourEnd.TimeOfDay)
                    {
                        IsAvailable = false;
                    }
                }
                // if after all checks for this time slot, nothing is conflicting, time is added to viable options
                if (IsAvailable == true)
                {
                    AvailableTimes.Add(UserSuggestedTimeLocal);
                }

                // both the UTC equivalent and local time user asked is incremented for the whole duration of their request, by their 
                // requested duration in minutes.
                TimeToCompare = TimeToCompare.AddMinutes(length);
                UserSuggestedTimeLocal = UserSuggestedTimeLocal.AddMinutes(length);

            }


            return AvailableTimes;
        }
    }
}
