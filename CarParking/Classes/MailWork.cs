using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace курсовой.Classes
{
    class MailWork
    {
        internal CommandBD CommandBD
        {
            get => default;
            set
            {
            }
        }

        public bool CheckInternet()
        {
            WebClient client = new WebClient();
            try
            {
                using (client.OpenRead("http://www.google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public void Send_letter(string login = null, string ml = null)
        {
            CommandBD cbd = new CommandBD();

            DataTable dt = new DataTable();

            //Создание письма
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.mail.ru", 25);
            client.Credentials = new System.Net.NetworkCredential("ogurtsova-01", "20022001alog");
            string mail = "";
            if (login != null)
            {
                dt = cbd.Select("users", "SecondName", login);
                mail = dt.Rows[0]["Mail"].ToString();
                if (mail == "")
                {
                    letter MWShow = new letter(login);
                    MWShow.Show();
                }
                else
                {
                    try
                    {
                        MailMessage message = new MailMessage("ogurtsova-01@mail.ru", mail, "парковка", "парковка");
                        client.EnableSsl = true;
                        //Прикрепление файла
                        string file = "check.pdf";
                        Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
                        //Добавление дополнительной информации о файле вложения
                        ContentDisposition disposition = attach.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(file);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                        //Связь файла вложения с письмом и отправка письма
                        message.Attachments.Add(attach);
                        client.Send(message);
                        MessageBox.Show("Чек отправлен");
                        attach.Dispose();

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка в отправление, такого адреса не найдено");
                    }
                    finally
                    {
                        string fn = "check.pdf";
                        File.Delete(fn);
                    }
                }
            }



        }

        private void DisposeAttachments()
        {
            throw new NotImplementedException();
        }
    }
}
