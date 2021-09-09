using MimeKit;
using MailKit.Net.Smtp;
namespace ProdStore
{
    public class EmailService
    {
        public void Send(string email)
        {
            
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("NixStore", "sheverdln02@gmail.com"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = "Информация о заказе";
            message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color:black;\">Ваш заказ принят. Позже с вами свяжется наш менеджер. Спасибо за покупку</div>" }.ToMessageBody();
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("sheverdln02@gmail.com", "QWE123456qwe");
                client.Send(message);
            }
        }
    }
}
