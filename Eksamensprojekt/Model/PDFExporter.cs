using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //List economyList = new List();
            //economyList.SetListSymbol("");
            //economyList.Alignindent()
            //economyList.Add(new ListItem("SUBTOTAL: " + currentOffer.OfferSubtotal + " DKK"));
            //economyList.Add("KUNDERABAT: " + currentOffer.MyCustomer.CustomerDiscount + " %");
            //economyList.Add("TILBUDSRABAT: " + currentOffer.OfferDiscount + " %");
            //economyList.Add("TRANSPORTOMKOSTNINGER: " + currentOffer.ForwardingAgentPrice + " DKK");
            //economyList.Add("TOTAL RABAT: " + currentOffer.TotalPercentDiscount);
            //economyList.Add("TOTAL BELØB SPARET: " + currentOffer.TotalDiscountedPrice);
            //economyList.Add("TOTAL: " + currentOffer.OfferTotal + " DKK");
            economyTable.TotalWidth = 400;
            economyTable.WriteSelectedRows(0, -1, 150, 150, pcb);
            doc.Close();
        }
    }
}
