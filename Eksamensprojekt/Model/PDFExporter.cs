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
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select PDFFile",
                Filter = "PDF(*.pdf)|*.pdf",
                DefaultExt = ".PDF",
                FileName = DateTime.Now.ToShortDateString()
            };
            if (saveFileDialog.ShowDialog() == true)
                return saveFileDialog.FileName;
            throw new Exception("Der er sket en fejl med at gemme filen");
        }
        public void PDFGenerator(Offer currentOffer)
        {
            //INITIALISERE NEW DOCUMENT
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(SaveFileDialogWindow(), FileMode.Create));
            Chunk symbol = new Chunk("", FontFactory.GetFont("HELVETICA"));
            doc.Open();
            Paragraph kundeParagraphListe = new Paragraph("KUNDE INFORMATION");
            List kundeInformationListe = new List()
            {
                ListSymbol = symbol,
                IndentationLeft = 30f
            };
            if (currentOffer.MyCustomer != null)
            {
                kundeInformationListe.Add(currentOffer.MyCustomer.CustomerName);
                kundeInformationListe.Add(currentOffer.MyCustomer.CustomerAdress);
                kundeInformationListe.Add(currentOffer.MyCustomer.CustomerZip + "");
                kundeInformationListe.Add("CVR nummer: " + currentOffer.MyCustomer.CVRNumber);
                kundeInformationListe.Add(currentOffer.MyCustomer.Email);
            }
            else
            kundeInformationListe.Add("INGEN KUNDE VALGT");

            //ECONOMY TABLE
            PdfPTable economyTable = new PdfPTable(2)
            {
                DefaultCell =
                {
                    Border = 0,
                    HorizontalAlignment = 2
                },
                TotalWidth = 400,
            };
            economyTable.AddCell("SUBTOTAL:");
            economyTable.AddCell(currentOffer.OfferSubtotal + " DKK");
            economyTable.AddCell("KUNDERABAT:");
            if (currentOffer.MyCustomer == null)
                economyTable.AddCell("0 %");
            else
                economyTable.AddCell(currentOffer.MyCustomer.CustomerDiscount + " %");
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
            //ECONOMY TABLE
            //OFFERLINES TABLE
            PdfPTable offerLineTable = new PdfPTable(7)
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
            doc.Add(kundeParagraphListe);
            doc.Add(kundeInformationListe);
            doc.Add(offerLineTable);
            doc.Add(economyTable);
            doc.Close();
        }
    }
}
