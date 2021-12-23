
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace курсовой.Classes
{
    class pdfWork
    {
        public void letter_formation(string Owner = null, string summa = null)
        {
            CommandBD cbd = new CommandBD();

            DataTable dt = new DataTable();

            string surname;

            dt = cbd.Select("users", "SecondName", Owner);
            surname = dt.Rows[0]["SecondName"].ToString();

            var document = new iTextSharp.text.Document();
            using (var writer = PdfWriter.GetInstance(document, new FileStream("check.pdf", FileMode.Create)))
            {
                document.Open();

                BaseFont baseFont = BaseFont.CreateFont(@"D:\4 сем\курсачООП\arial\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.UNDERLINE);

                writer.DirectContent.BeginText();
                writer.DirectContent.SetFontAndSize(baseFont, 12f);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "OOO Парковка ", 10, 820, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Владелец Огурцова А. А. ", 10, 800, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Товарный чек от " + DateTime.Now.ToString(), 180, 700, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Наименование операции", 30, 660, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Плата за автостоянку ", 300, 660, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Плательщик", 30, 640, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, surname, 300, 640, 0);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Сумма к оплате " + summa + "р.", 30, 620, 0);
                writer.DirectContent.EndText();

                document.Open();
                iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(10, " ", font);//интервал между строками, текст, шрифт
                document.Add(paragraph);

                document.Close();
                writer.Close();
            }
        }

    }

}

