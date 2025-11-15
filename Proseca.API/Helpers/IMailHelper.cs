
using MailKit.Net.Smtp;
using MimeKit;
using Proseca.Shared.Responses;


namespace Proseca.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }

}
