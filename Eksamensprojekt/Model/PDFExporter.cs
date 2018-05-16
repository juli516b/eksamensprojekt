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
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("PDFTest.pdf", FileMode.Create));
            doc.Open();
            Paragraph newParagraph = new Paragraph("DET HER ER VERDENS FØRSTE PDF WUHU");
            doc.Add(newParagraph);
            List economyList = new List(List.UNORDERED);
            economyList.Add(new ListItem(currentOffer.OfferSubtotal + " DKK"));
            economyList.Add(currentOffer.MyCustomer.CustomerDiscount + " %");
            economyList.Add(currentOffer.OfferDiscount + " %");
            economyList.Add(currentOffer.ForwardingAgentPrice + " DKK");
            economyList.Add(currentOffer.TotalPercentDiscount + " %");
            economyList.Add(currentOffer.TotalDiscountedPrice + " DKK");
            economyList.Add(currentOffer.OfferTotal + " DKK");
            doc.Add(economyList);
            doc.Close();
        }
    }
}
