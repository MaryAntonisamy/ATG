using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.Libraries.TypeHelpers
{
    public static class DateTimeHelper
    {
        public static bool IsTimeMorethanTenMinutes(DateTime? orignalDateTime, DateTime? dateTimeToCheck)
        {

            bool result = false;

            if (orignalDateTime.HasValue && dateTimeToCheck.HasValue)
            {
                if (dateTimeToCheck.Value.Date == orignalDateTime.Value.Date)
                {

                    if (dateTimeToCheck.Value.Minute > orignalDateTime.Value.Minute + 10)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
