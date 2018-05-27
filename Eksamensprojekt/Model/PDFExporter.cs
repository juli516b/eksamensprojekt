using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model.BaseTypes;

namespace Model
{
    public class PDFExporter
    {
        private readonly Document doc;
        private readonly PdfPTable economyTable;
        private readonly PdfPTable offerLineTable;
        private readonly List customerInformationList;

        public PDFExporter()
        {
            doc = new Document(PageSize.A4);
            var symbol = new Chunk("", FontFactory.GetFont("HELVETICA"));
            economyTable = new PdfPTable(2)
            {
                DefaultCell =
                {
                    Border = 0,
                    HorizontalAlignment = 2
                },
                TotalWidth = 400,
            };
            offerLineTable = new PdfPTable(7)
            {
                DefaultCell =
                {
                    Border = 0,
                    Padding = 4,
                    PaddingLeft = 4,
                    HorizontalAlignment = 2
                },
                TotalWidth = 550,
                HeaderRows = 1,
                SplitLate = false
            };
            customerInformationList = new List()
            {
                ListSymbol = symbol,
                IndentationLeft = 30f
            };
        }

        public void PDFGenerator(IExtendOffer currentOffer, string path)
        { 
            using (doc)
            {
                PdfWriter.GetInstance(doc, new FileStream(path: path, mode: FileMode.Create));
                doc.Open();
                //CUSTOMER INFORMATION LIST
                Paragraph customerInformationParagraph = new Paragraph("KUNDE INFORMATION");
                if (currentOffer.MyCustomer != null)
                {
                    customerInformationList.Add(currentOffer.MyCustomer.CustomerName);
                    customerInformationList.Add(currentOffer.MyCustomer.CustomerAddress);
                    customerInformationList.Add(currentOffer.MyCustomer.CustomerZip + "");
                    customerInformationList.Add("CVR nummer: " + currentOffer.MyCustomer.CVRNumber);
                    customerInformationList.Add(currentOffer.MyCustomer.Email);
                }
                else
                    customerInformationList.Add("INGEN KUNDE VALGT");
                //ECONOMY TABLE
                economyTable.AddCell("SUBTOTAL:");
                economyTable.AddCell(currentOffer.OfferSubTotal + " DKK");
                economyTable.AddCell("KUNDERABAT:");
                if (currentOffer.MyCustomer == null)
                {
                    economyTable.AddCell("0 %");
                }
                else
                {
                    economyTable.AddCell(currentOffer.MyCustomer.CustomerDiscountPercent + " %");
                }
                economyTable.AddCell("TILBUDSRABAT");
                economyTable.AddCell(currentOffer.OfferDiscountPercent + " %");
                economyTable.AddCell("TRANSPORTOMKOSTNINGER:");
                economyTable.AddCell(currentOffer.ForwardingAgentPrice + " DKK");
                economyTable.AddCell("TOTAL RABAT:");
                economyTable.AddCell(currentOffer.TotalPercentDiscount.ToString());
                economyTable.AddCell("TOTAL BELØB SPARET:");
                economyTable.AddCell(currentOffer.TotalDiscountedPrice.ToString());
                economyTable.AddCell("TOTAL:");
                economyTable.AddCell(currentOffer.OfferTotal + " DKK");
                //OFFERLINES TABLE
                //MAKING HEADERROWS
                offerLineTable.AddCell("Vare nr.");
                offerLineTable.AddCell("Varenavn");
                offerLineTable.AddCell("Antal varer");
                offerLineTable.AddCell("Stk. pris, DKK");
                offerLineTable.AddCell("Tilbudspris, DKK");
                offerLineTable.AddCell("Rabat, %");
                offerLineTable.AddCell("Total, DKK");
                //ADDING OFFERLINE TO offerLineTable.
                foreach (OfferLine offerLine in currentOffer.OfferLines)
                {
                    offerLineTable.AddCell(offerLine.ItemNo);
                    offerLineTable.AddCell(offerLine.ItemName);
                    offerLineTable.AddCell(offerLine.Quantity + "");
                    offerLineTable.AddCell(offerLine.ItemPrice + "");
                    offerLineTable.AddCell(offerLine.DiscountedPrice + "");
                    offerLineTable.AddCell(offerLine.PercentDiscount + "");
                    offerLineTable.AddCell(offerLine.OfferLineTotal + "");
                }
                //ADD TO DOCUMENT
                doc.Add(customerInformationParagraph);
                doc.Add(customerInformationList);
                doc.Add(offerLineTable);
                doc.Add(economyTable);
                doc.Close();
            }
        }
    }
}
