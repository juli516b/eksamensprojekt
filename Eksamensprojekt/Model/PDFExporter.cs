using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Model
{
    public class PDFExporter
    {
        public void PDFGenerator(Offer currentOffer)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("PDFTest.pdf", FileMode.Create));
            doc.Open();
            Paragraph newParagraph = new Paragraph("DET HER ER VERDENS FØRSTE PDF WUHU");
            doc.Add(newParagraph);
            PdfContentByte pcb = writer.DirectContent;
            PdfPTable economyTable = new PdfPTable(2);
            //ECONOMY TABLE
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
            economyTable.WriteSelectedRows(0, -1, 150, 150, pcb);
            //ECONOMY TABLE
            //OFFERLINE LIST
            PdfPTable offerlineTable = new PdfPTable(9);
            offerlineTable.AddCell("Vare nr.");
            offerlineTable.AddCell("Varenavn");
            offerlineTable.AddCell("Antal varer");
            offerlineTable.AddCell("Helpaller");
            offerlineTable.AddCell("Løse pakker");
            offerlineTable.AddCell("Stk. pris");
            offerlineTable.AddCell("Tilbudspris");
            offerlineTable.AddCell("Rabat procent");
            offerlineTable.AddCell("Total linjepris");
            offerlineTable.HeaderRows = 1;
            foreach (OfferLine offerLine in currentOffer.OfferLines)
            {
                offerlineTable.AddCell(offerLine.ItemNo);
                offerlineTable.AddCell(offerLine.ItemName);
                offerlineTable.AddCell(offerLine.Quantity + "");
                offerlineTable.AddCell(offerLine.NoOfPallets + "");
                offerlineTable.AddCell(offerLine.NoOfPackages + "");
                offerlineTable.AddCell(offerLine.ItemPrice + " DKK");
                offerlineTable.AddCell(offerLine.DiscountedPrice + " DKK");
                offerlineTable.AddCell(offerLine.PercentDiscount + " %");
                offerlineTable.AddCell(offerLine.OfferLineTotal + " DKK");
            }

            doc.Add(offerlineTable);
            doc.Close();
        }
    }
}
