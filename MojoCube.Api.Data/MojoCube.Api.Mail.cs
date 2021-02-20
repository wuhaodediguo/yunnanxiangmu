using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;


namespace MojoCube.Api.Mail
{
    public class Normal
    {
        private string _From;

        private string _DisplayName;

        private string _To;

        private string _CC;

        private string _Bcc;

        private string _Subject;

        private string _Body;

        private string _SmtpHost;

        private string _UserName;

        private string _Password;

        private int _Port;

        private bool _EnableSsl;

        public string From
        {
            get
            {
                return this._From;
            }
            set
            {
                this._From = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this._DisplayName;
            }
            set
            {
                this._DisplayName = value;
            }
        }

        public string To
        {
            get
            {
                return this._To;
            }
            set
            {
                this._To = value;
            }
        }

        public string CC
        {
            get
            {
                return this._CC;
            }
            set
            {
                this._CC = value;
            }
        }

        public string Bcc
        {
            get
            {
                return this._Bcc;
            }
            set
            {
                this._Bcc = value;
            }
        }

        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }

        public string Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this._Body = value;
            }
        }

        public string SmtpHost
        {
            get
            {
                return this._SmtpHost;
            }
            set
            {
                this._SmtpHost = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        public int Port
        {
            get
            {
                return this._Port;
            }
            set
            {
                this._Port = value;
            }
        }

        public bool EnableSsl
        {
            get
            {
                return this._EnableSsl;
            }
            set
            {
                this._EnableSsl = value;
            }
        }

        public bool Send()
        {
            bool result;
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(this._From, this._DisplayName, Encoding.UTF8);
                mailMessage.To.Add(new MailAddress(this._To));
                if (this._CC != null)
                {
                    mailMessage.CC.Add(new MailAddress(this._CC));
                }
                if (this._Bcc != null)
                {
                    mailMessage.Bcc.Add(new MailAddress(this._Bcc));
                }
                mailMessage.Subject = this._Subject;
                mailMessage.Body = this._Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                new SmtpClient(this._SmtpHost)
                {
                    Port = this._Port,
                    EnableSsl = this._EnableSsl,
                    Credentials = new NetworkCredential(this._UserName, this._Password)
                }.Send(mailMessage);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }

    public class MyThread
    {
        private string _From;

        private string _DisplayName;

        private string _To;

        private string _CC;

        private string _Bcc;

        private string _Subject;

        private string _Body;

        private string _SmtpHost;

        private string _UserName;

        private string _Password;

        private int _Port;

        private bool _EnableSsl;

        public MailMessage myMail;

        public SmtpClient smtp;

        public Thread thread;

        public string From
        {
            get
            {
                return this._From;
            }
            set
            {
                this._From = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this._DisplayName;
            }
            set
            {
                this._DisplayName = value;
            }
        }

        public string To
        {
            get
            {
                return this._To;
            }
            set
            {
                this._To = value;
            }
        }

        public string CC
        {
            get
            {
                return this._CC;
            }
            set
            {
                this._CC = value;
            }
        }

        public string Bcc
        {
            get
            {
                return this._Bcc;
            }
            set
            {
                this._Bcc = value;
            }
        }

        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }

        public string Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this._Body = value;
            }
        }

        public string SmtpHost
        {
            get
            {
                return this._SmtpHost;
            }
            set
            {
                this._SmtpHost = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        public int Port
        {
            get
            {
                return this._Port;
            }
            set
            {
                this._Port = value;
            }
        }

        public bool EnableSsl
        {
            get
            {
                return this._EnableSsl;
            }
            set
            {
                this._EnableSsl = value;
            }
        }

        public bool Send()
        {
            bool result;
            try
            {
                this.myMail = new MailMessage();
                this.myMail.From = new MailAddress(this._From, this._DisplayName, Encoding.UTF8);
                this.myMail.To.Add(new MailAddress(this._To));
                if (this._CC != null)
                {
                    this.myMail.CC.Add(new MailAddress(this._CC));
                }
                if (this._Bcc != null)
                {
                    this.myMail.Bcc.Add(new MailAddress(this._Bcc));
                }
                this.myMail.Subject = this._Subject;
                this.myMail.Body = this._Body;
                this.myMail.IsBodyHtml = true;
                this.myMail.Priority = MailPriority.Normal;
                this.smtp = new SmtpClient(this._SmtpHost);
                this.smtp.Port = this._Port;
                this.smtp.EnableSsl = this._EnableSsl;
                this.smtp.Credentials = new NetworkCredential(this._UserName, this._Password);
                this.thread = new Thread(new ThreadStart(this.SendThread));
                this.thread.Start();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void SendThread()
        {
            try
            {
                this.smtp.Send(this.myMail);
            }
            catch
            {
                this.thread.Abort();
            }
        }
    }
}
