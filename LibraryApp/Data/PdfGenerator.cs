using iTextSharp.text;
using iTextSharp.text.pdf;
using Library.ExportToPdf.Contracts;
using Library.ExportToPdf.Models;
using LibraryApp.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.ExportToPdf
{
    public class PdfGenerator : IPdfGenerator
    {
        public void Generate(LibraryDbContext dbContext)
        {
            FileStream fs = new FileStream("../../../ExportedFiles/BooksReport.pdf", FileMode.Create,
                                                                                        FileAccess.Write, 
                                                                                            FileShare.None);

            Document document = new Document(this.CreatePdfRectangle());

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            this.FillDocument(document, dbContext);
        }

        private Rectangle CreatePdfRectangle()
        {
            Rectangle rect = new Rectangle(PageSize.A4);
            rect.BackgroundColor = new BaseColor(100, 100, 100);
            return rect;
        }

        private void FillDocument(Document document, LibraryDbContext dbContext)
        {
            document.Open();

            this.GenerateData(document, dbContext);

            document.Close();
        }

        private void GenerateData(Document document, LibraryDbContext dbContext)
        {

            var books = dbContext.Books
                .Select(book => new ReportBook()
                {
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author.FirstName + " " + book.Author.LastName,
                    Year = book.Year,
                    Price = book.Price
                }).ToList();

            PdfPTable table = new PdfPTable(5);

            int[] widths = new int[] { 20, 40, 20, 15, 20 };

            table.SetWidths(widths);

            table.AddCell(this.CreateCell(new Phrase("Book name"), true));
            table.AddCell(this.CreateCell(new Phrase("Description"), true));
            table.AddCell(this.CreateCell(new Phrase("Author"), true));
            table.AddCell(this.CreateCell(new Phrase("Year"), true));
            table.AddCell(this.CreateCell(new Phrase("Price"), true));

            this.InputData(books, table);

            document.Add(table);
        }

        private void InputData(List<ReportBook> books, PdfPTable table)
        {
            for (int i = 0; i < books.Count; i++)
            {
                table.AddCell(this.CreateCell(new Phrase(books[i].Title)));
                table.AddCell(this.CreateCell(new Phrase(books[i].Description)));
                table.AddCell(this.CreateCell(new Phrase(books[i].Author)));
                table.AddCell(this.CreateCell(new Phrase(books[i].Year.ToString())));
                table.AddCell(this.CreateCell(new Phrase(books[i].Price.ToString("0.00") + '\u20AC')));
            }
        }

        private PdfPCell CreateCell(Phrase phrase, bool isHeader = false, int cellColspan = 0)
        {
            PdfPCell cell = new PdfPCell(phrase);
            if (isHeader)
            {
                cell.BackgroundColor = new BaseColor(255, 153, 55);
            }
            else
            {
                cell.BackgroundColor = new BaseColor(100, 204, 150);
            }

            cell.Colspan = cellColspan;
            cell.MinimumHeight = 25;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = 1;

            return cell;
        }
    }
}
