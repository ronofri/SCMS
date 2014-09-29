using Mvc.Mailer;
using SCMS.Models;

namespace SCMS.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Notification(string to, POC POC)
		{
			ViewBag.POC = POC;
			return Populate(x =>
			{
				x.Subject = "Notification";
				x.ViewName = "Notification";
				x.To.Add(to);
			});
		}
 	}
}