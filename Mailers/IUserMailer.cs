using Mvc.Mailer;
using SCMS.Models;

namespace SCMS.Mailers
{ 
    public interface IUserMailer
    {
        MvcMailMessage Notification(string to, POC POC);
	}
}