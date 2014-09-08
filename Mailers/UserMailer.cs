using Mvc.Mailer;

namespace SCMS.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Notification(string to)
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Notification";
				x.ViewName = "Notification";
				x.To.Add(to);
			});
		}
 	}
}