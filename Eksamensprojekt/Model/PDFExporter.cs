using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;

namespace Model
{
    public class PDFExporter
    {
        private string SaveFileDialogWindow()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select PDFFile",
                Filter = "PDF(*.pdf)|*.pdf",
                DefaultExt = ".PDF",
                FileName = DateTime.Now.ToShortDateString()
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return "Du skal fatte noget";
            }
        }
        public void PDFGenerator(Offer currentOffer)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(SaveFileDialogWindow(), FileMode.Create));
            doc.Open();

            PdfContentByte pcb = writer.DirectContent;
            //ECONOMY TABLE
            PdfPTable economyTable = new PdfPTable(2);
            economyTable.DefaultCell.Border = 0;
            economyTable.DefaultCell.HorizontalAlignment = 2;
            economyTable.AddCell("SUBTOTAL:");
            economyTable.AddCell(currentOffer.OfferSubtotal + " DKK");
            economyTable.AddCell("KUNDERABAT:");
            if (currentOffer.MyCustomer != null)
            {
                economyTable.AddCell(currentOffer.MyCustomer.CustomerDiscount + " %");
            }
            else
            {
                economyTable.AddCell("0 %");
            }
            economyTable.AddCell("TILBUDSRABAT");
            economyTable.AddCell(currentOffer.OfferDiscount + " %");
            economyTable.AddCell("TRANSPORTOMKOSTNINGER:");
            economyTable.AddCell(currentOffer.ForwardingAgentPrice + " DKK");
            economyTable.AddCell("TOTAL RABAT:");
            economyTable.AddCell(currentOffer.TotalPercentDiscount);
            economyTable.AddCell("TOTAL BELØB SPARET:");
            economyTable.AddCell(currentOffer.TotalDiscountedPrice);
            economyTable.AddCell("TOTAL:");
            economyTable.AddCell(currentOffer.OfferTotal + " DKK");
            economyTable.TotalWidth = 400;
            //ECONOMY TABLE
            //OFFERLINES TABLE
            PdfPTable offerlineTable = new PdfPTable(7);
            offerlineTable.DefaultCell.Border = 0;
            offerlineTable.DefaultCell.Padding = 4;
            offerlineTable.DefaultCell.PaddingLeft = 4;
            offerlineTable.DefaultCell.HorizontalAlignment = 2;
            offerlineTable.WidthPercentage = 100;
            offerlineTable.AddCell("Vare nr.");
            offerlineTable.AddCell("Varenavn");
            offerlineTable.AddCell("Antal varer");
            offerlineTable.AddCell("Stk. pris, DKK");
            offerlineTable.AddCell("Tilbudspris, DKK");
            offerlineTable.AddCell("Rabat, %");
            offerlineTable.AddCell("Total, DKK");
            offerlineTable.HeaderRows = 1;
            foreach (OfferLine offerLine in currentOffer.OfferLines)
            {
                offerlineTable.AddCell(offerLine.ItemNo);
                offerlineTable.AddCell(offerLine.ItemName);
                offerlineTable.AddCell(offerLine.Quantity + "");
                offerlineTable.AddCell(offerLine.ItemPrice + "");
                offerlineTable.AddCell(offerLine.DiscountedPrice + "");
                offerlineTable.AddCell(offerLine.PercentDiscount + "");
                offerlineTable.AddCell(offerLine.OfferLineTotal + "");
            }
            //OFFERLINES TABLE
            //ADD TO DOCUMENT
            doc.Add(offerlineTable);
            economyTable.WriteSelectedRows(0, -1, 150, 150, pcb);
            doc.Close();
        }
    }
}
