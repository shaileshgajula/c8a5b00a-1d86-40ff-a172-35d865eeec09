using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text;
using StrongerOrg.BackOffice.Scheduler;

namespace StrongerOrg.Backoffice
{
    public partial class Schedules : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, ImageClickEventArgs e)
        {
            WriteCalendar(RadScheduler.ExportToICalendar(RadScheduler1.Appointments));
        }

        private void WriteCalendar(string data)
        {
            HttpResponse response = Page.Response;

            response.Clear();
            response.Buffer = true;

            response.ContentType = "text/calendar";
            response.ContentEncoding = Encoding.UTF8;
            response.Charset = "utf-8";

            response.AddHeader("Content-Disposition", "attachment;filename=\"LeagueManagmentPlatform.ics\"");

            response.Write(data);
            response.End();
        }
        protected void RadScheduler1_FormCreated(object sender, Telerik.Web.UI.SchedulerFormCreatedEventArgs e)
        {
            //RadScheduler scheduler = (RadScheduler)sender;



            //if (e.Container.Mode == SchedulerFormMode.AdvancedInsert || e.Container.Mode == SchedulerFormMode.AdvancedEdit)
            //{
            //    RadDateInput startInput = (RadDateInput)e.Container.FindControl("StartInput");
            //    startInput.DateFormat = scheduler.AdvancedForm.DateFormat + " " + scheduler.AdvancedForm.TimeFormat;
            //    startInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);

            //    RadDateInput endInput = (RadDateInput)e.Container.FindControl("EndInput");
            //    endInput.DateFormat = scheduler.AdvancedForm.DateFormat + " " + scheduler.AdvancedForm.TimeFormat;
            //    endInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.End);

            //}
        }

        protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {
            if (e.CommandName == "Insert" || e.CommandName == "Update")
            {
                Guid tournamentId = new Guid(Request.QueryString["TournamentId"].ToString());
                DropDownList ddlPlayerA = e.Container.FindControl("ddlPlayerA") as DropDownList;
                DropDownList ddlPlayerB = e.Container.FindControl("ddlPlayerB") as DropDownList;
                RadTimePicker startDate = e.Container.FindControl("RadTimePicker1") as RadTimePicker;
                DateTime startFullDate = e.Container.Appointment.Start;
                DateTime selectedTime = startDate.SelectedDate.Value;
                DateTime sd = new DateTime(startFullDate.Year, startFullDate.Month, startFullDate.Day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second);
                DateTime ed = sd.AddMinutes(15);
                Guid ddlPlayerAGuid = new Guid(ddlPlayerA.SelectedValue);
                Guid ddlPlayerBGuid = new Guid(ddlPlayerB.SelectedValue);
                string subject = string.Format("{0} vs. {1}", ddlPlayerA.SelectedItem.Text, ddlPlayerB.SelectedItem.Text);
                SchedulesBL.ScheduleInsert(tournamentId, ddlPlayerAGuid, ddlPlayerBGuid, sd, ed);
            }
        }

        
    }
}
