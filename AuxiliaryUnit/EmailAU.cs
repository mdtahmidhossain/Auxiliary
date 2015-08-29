using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class EmailAU
    {
        public static Attachment MakeAttachment(byte[] obj,string fileName)
        {
            
            return new Attachment(new MemoryStream(obj), fileName);
        }
        public static Attachment MakeAttachment(byte[] obj, string fileName, string mediaType )
        {
            Attachment attachment = MakeAttachment(obj, fileName);
            attachment.ContentType.MediaType = mediaType;
            return attachment;
        }

        public static MailMessage getMailMessage(string subject, string body, string toAddress, string fromAddress)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(toAddress);
            mailMessage.From = new MailAddress(fromAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            return mailMessage;
        }

        public static MailMessage getMailMessage(string subject, string body, List<MailAddress> toWhom, List<MailAddress> ccWhom, List<MailAddress> bCcWhom)

        {
            MailMessage mailMessage = new MailMessage();
            foreach (MailAddress EmailAddress in toWhom)
            {
                mailMessage.To.Add(EmailAddress);
            }
            foreach (MailAddress EmailAddress in ccWhom)
            {
                mailMessage.CC.Add(EmailAddress);
            }
            foreach (MailAddress EmailAddress in bCcWhom)
            {
                mailMessage.Bcc.Add(EmailAddress);
            }

            return mailMessage;
        }

        public static MailMessage getMailMessageWithAttachment(string subject, string body, string toAddress, string fromAddress, Attachment attachment)
        {
            MailMessage mailMessage = getMailMessage(subject, body, toAddress, fromAddress);
            mailMessage.Attachments.Add(attachment);
            return mailMessage;
        }

        public static MailMessage getMailMessageWithAttachment(string subject, string body, List<MailAddress> toWhom, List<MailAddress> ccWhom, List<MailAddress> bCcWhom, List<Attachment> attachments)

        {
            MailMessage mailMessage = new MailMessage();
            mailMessage = getMailMessage(subject, body, toWhom, ccWhom, bCcWhom);
            foreach (Attachment itemAttachment in attachments)
            {
                mailMessage.Attachments.Add(itemAttachment);
            }

            return mailMessage;
        }

        public static SmtpClient getSmtpClient(string smtpClientUrl, int smtpClientPort, string emailUser, string emailPass)
        {
            SmtpClient smtpClient = new SmtpClient(smtpClientUrl, smtpClientPort);
            smtpClient.Credentials = new System.Net.NetworkCredential(emailUser, emailPass);
            return smtpClient;
        }

        public static bool emailSender(MailMessage mailMessageObject, SmtpClient smtpClientObject)
        {
            bool ret = false;
            try
            {
                using (MailMessage mailMessage = mailMessageObject)
                {
                    using (SmtpClient smtpClient = smtpClientObject)
                    {
                        smtpClient.Send(mailMessage);
                        ret = true;
                    }
                }
            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }

        public static bool emailSender(Exception exception, MailMessage mailMessageObject, SmtpClient smtpClientObject)
        {
            MailMessage mailMessage = mailMessageObject;
            mailMessage.Body = ExceptionAU.GetExceptionDetails(exception);
            return emailSender(mailMessage, smtpClientObject);
        }
    }
}