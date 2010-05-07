using System;
public static class StorngerOrgExtentions
{
        public static string TruncateSeconds(this TimeSpan ts)
        {
            return string.Format("{0:D2}:{1:D2}", ts.Hours, ts.Minutes);
        }
    }
