using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections;
using System.Net;
using System.Net.Mail;

namespace Util.Mail
{
    public class MailExchange
    {
        public static void SendMailExchange(string server, string usermail, string userpassword, string mailTo, string subject, string body, Hashtable attachment)
        {
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);
                service.Url = new Uri(server);
                service.Credentials = new WebCredentials(usermail, userpassword);

                EmailMessage message = new EmailMessage(service);
                message.Subject = subject;
                message.Body = body;
                message.Importance = Importance.High;
                message.IsDeliveryReceiptRequested = true;
                message.IsReadReceiptRequested = true;

                if (attachment != null && attachment.Count > 0)
                {
                    foreach (string key in attachment.Keys)
                    {
                        if (attachment[key] is byte[])
                        {
                            byte[] data = (byte[])attachment[key];
                            message.Attachments.AddFileAttachment(key, data);
                        }
                        else if (attachment[key] is string)
                        {
                            string path = (string)attachment[key];
                            message.Attachments.AddFileAttachment(key, path);
                        }
                        else
                        {
                            throw new Exception("bad attachment type");
                        }
                    }
                }

                message.ToRecipients.Add(mailTo);
                message.SendAndSaveCopy();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static void SendMailSmtp(string server, int port, string domain, string username, string userpassword, string mailfrom, string mailto, string subject, string body)
        {
            MailMessage mail = new MailMessage(mailfrom, mailto);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = server;
            smtpClient.Port = port;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            CredentialCache.DefaultNetworkCredentials.Domain = domain;
            CredentialCache.DefaultNetworkCredentials.UserName = username;
            CredentialCache.DefaultNetworkCredentials.Password = userpassword;

            smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            smtpClient.Send(mail);
        }
    }
}