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
        
        public static List<DateTime> GetAll(List<BusyTime> busyTimes, Dictionary<string, string> userData, CultureInfo culture)
        {
            List<DateTime> AvailableTimes = new List<DateTime>();

            var earliest = DateTime.Parse(userData["Earliest"], culture).ToUniversalTime();
            var UserSuggestedTimeLocal = DateTime.Parse(userData["Earliest"], culture);
            var latest = DateTime.Parse(userData["Latest"], culture).ToUniversalTime();
            var length = int.Parse(userData["Length"]);
            var OfficeHourStart = DateTime.ParseExact(userData["Office Hours"].Split("-")[0],"HH", CultureInfo.InvariantCulture);
            var OfficeHourEnd= DateTime.ParseExact(userData["Office Hours"].Split("-")[1], "HH", CultureInfo.InvariantCulture);

            DateTime TimeToCompare = earliest;

            while (DateTime.Compare(TimeToCompare.AddMinutes(length), latest) <= 0)
            {
                var IsAvailable = true;
                foreach (BusyTime busyTime in busyTimes)
                {
                    if ((DateTime.Compare(TimeToCompare, busyTime.EmployeeMeetingEnd) <= 0
                        && DateTime.Compare(TimeToCompare, busyTime.EmployeeMeetingStart) >= 0) 
                        || TimeToCompare.TimeOfDay < OfficeHourStart.TimeOfDay
                        || TimeToCompare.AddMinutes(length).TimeOfDay > OfficeHourEnd.TimeOfDay)
                    {
                        IsAvailable = false;
                    }
                }
                if (IsAvailable == true)
                {
                    AvailableTimes.Add(UserSuggestedTimeLocal);
                }
                TimeToCompare = TimeToCompare.AddMinutes(length);
                UserSuggestedTimeLocal = UserSuggestedTimeLocal.AddMinutes(length);

            }


            return AvailableTimes;
        }
    }
}
