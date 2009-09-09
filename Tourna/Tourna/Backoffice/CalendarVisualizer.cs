using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrongerOrg.Backoffice
{
    public class CalendarVisualizer
    {
        private IEnumerable<DateTime> _dates;
        public CalendarVisualizer(IEnumerable<DateTime> dates)
        {
            this._dates = dates;
        }

        public void Display(Control control)
        {
            var grup = this._dates.GroupBy(x => new { x.Year, x.Month });



            //Calendar newCal = new Calendar();
            foreach (var grouping in grup)
            {

                Calendar cal = new Calendar();
                cal.SelectionMode = CalendarSelectionMode.None;
                cal.ShowNextPrevMonth = false;
                
                
                cal.VisibleDate = new DateTime(grouping.Key.Year, grouping.Key.Month, 1);

                foreach (DateTime date in grouping)
                    cal.SelectedDates.Add(date);

                control.Controls.Add(cal);

                
            }

            
        }

    }
}
