using Mvc.Mailer;

namespace SCMS.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Notification(string to);
	}
}