using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Model;
using DataAccessLayer;
using DataAccessLayer.DataHandlers;
using Model.BaseTypes;

namespace ViewModel
{
    public class OfferViewModel : AbstractNotifyPropertyChanged
    {
        private IPersistentItemDataHandler dataHandler;
        private readonly PDFExporter pdfExporter;
        private ICommand clickAddButtonCommand;
        private ICommand clickGeneratePDFCommand;
        private ICommand clickCreateNewOffer;
        private ICommand clickRemoveOfferLineCommand;
        private IExtendOffer currentOffer;
        public IBaseCustomer MyCustomer
        {
            get
            {
                IBaseCustomer customer = new Customer() { CustomerName = "Ingen kunde valgt. Klik for at tilføje" };
                if (currentOffer.MyCustomer != null)
                {
                    customer = currentOffer.MyCustomer;
                }
                return customer;
            }
            set
            {
                currentOffer.MyCustomer = value;
                string[] propertiesChanged = { nameof(OfferTotal), nameof(MyCustomer),nameof(MyCustomerDiscount), nameof(TotalPercentDiscount) };
                NotifyPropertiesChanged(propertiesChanged);
            }
        }
        public string OfferLinesSubtotal
        {
            get { return currentOffer.OfferSubTotal + " DKK"; }
        }
        public string MyCustomerDiscount
        {
            get
            {
                string customerDiscount_Label = "";
                if (MyCustomer != null)
                {
                    customerDiscount_Label = MyCustomer.CustomerDiscountPercent + " %";
                }
                return customerDiscount_Label;
            }
            set
            {
                MyCustomer.CustomerDiscountPercent = Convert.ToDouble(value);
                NotifyPropertyChanged(nameof(TotalPercentDiscount));
            }   
        }
        public double ForwardingAgentPrice
        {
            get
            {
                return currentOffer.ForwardingAgentPrice;
            }
            set {
                currentOffer.ForwardingAgentPrice = value;
                string[] propertiesChanged = { nameof(OfferTotal), nameof(TotalPercentDiscount) };
                NotifyPropertiesChanged(propertiesChanged);
            }
        }
        public IBaseItem SelectedItem { get; set; }
        public IExtendOfferLine SelectedOfferLine { get; set; }
        public string QuantityTextBoxText { get; set; }

        public ICommand CreateNewOfferButtonCommand
        {
            get
            {
                if (clickCreateNewOffer == null)
                {
                    clickCreateNewOffer = new DelegateCommand(
                        param => CreateNewOffer(),
                        param => CanCreateNewOffer()
                    );
                }
                return clickCreateNewOffer;
            }
        }
        public ICommand RemoveOfferLineButtonCommand
        {
            get
            {
                if (clickRemoveOfferLineCommand == null)
                {
                    clickRemoveOfferLineCommand = new DelegateCommand(
                        param => RemoveOfferLine(),
                        param => CanRemoveOfferLine()
                    );
                }
                return clickRemoveOfferLineCommand;
            }
        }
        public ICommand GeneratePdfButtonCommand
        {
            get
            {
                if (clickGeneratePDFCommand == null)
                {
                    clickGeneratePDFCommand = new DelegateCommand(
                        param => GeneratePDF(),
                        param => CanGeneratePDF()
                    );
                }
                return clickGeneratePDFCommand;
            }
        }
        public ICommand AddButtonCommand
        {
            get
            {
                if (clickAddButtonCommand == null)
                {
                    clickAddButtonCommand = new DelegateCommand(
                        param => AddItem(),
                        param => CanAdd()
                    );
                }
                return clickAddButtonCommand;
            }
        }
        public ObservableCollection<IBaseItem> Items {
            get { return dataHandler.Items; }
            set { dataHandler.Items = value; }
        }
        public double OfferDiscountPercent
        {
            get { return Math.Round(currentOffer.OfferDiscountPercent, 2); }
            set
            {
                currentOffer.OfferDiscountPercent = value;
                string[] propertiesChanged = { nameof(OfferTotal), nameof(TotalDiscountedPrice), nameof(TotalPercentDiscount)};
                NotifyPropertiesChanged(propertiesChanged);
            }
        }
        public ObservableCollection<IExtendOfferLine> OfferLines
        {
            get { return currentOffer.OfferLines; }
            set { currentOffer.OfferLines = value; }
        }

        public string OfferTotal {
            get
            {
                return Math.Round(currentOffer.OfferTotal,2) + " DKK";
            }
        }
        public int NoOfTotalPallets
        {
            get
            {
                return OfferLines.Sum(offerLine => offerLine.NoOfPallets);
            }
        }
        public int NoOfTotalPackages
        {
            get
            {
                return OfferLines.Sum(offerLine => offerLine.NoOfPackages);
            }
        }

        public string TotalPercentDiscount
        {
            get
            {
                return currentOffer.TotalPercentDiscount;
            }
        }

        public string TotalDiscountedPrice
        {
            get { return currentOffer.TotalDiscountedPrice; }
        }
        public OfferViewModel()
        {
            dataHandler = DatabaseFacade.GetInstance();
            pdfExporter = new PDFExporter();
            currentOffer = new Offer(DateTime.Now);
            Items = dataHandler.GetAllItems();
            
        }
        public void AddOfferLine(IBaseItem myItem, int quantity)
        {
            IExtendOfferLine newOfferLine = new OfferLine(myItem, quantity);
            OfferLines.Add(newOfferLine);
            newOfferLine.APWC += NotifyPropertyChanged;
            string[] propertiesChanged = {nameof(OfferTotal),nameof(NoOfTotalPackages),nameof(NoOfTotalPallets),nameof(OfferLinesSubtotal),nameof(TotalDiscountedPrice),nameof(TotalPercentDiscount)};
            NotifyPropertiesChanged(propertiesChanged);
        }
        private bool CanCreateNewOffer()
        {
            //TO DO: skal spørge om man vil gemme, inden tilbud nulstilles
            return true;
        }
        private bool CanRemoveOfferLine()
        {
            return true;
        }
        private void CreateNewOffer()
        {
            currentOffer.Clear();
            string[] propertiesChanged = { nameof(OfferTotal), nameof(NoOfTotalPackages), nameof(NoOfTotalPallets), nameof(OfferLinesSubtotal), nameof(TotalDiscountedPrice), nameof(TotalPercentDiscount), nameof(MyCustomer), nameof(ForwardingAgentPrice),nameof(OfferDiscountPercent),nameof(MyCustomerDiscount) };
            NotifyPropertiesChanged(propertiesChanged);
        }
        private void RemoveOfferLine()
        {
            currentOffer.RemoveOfferLine(SelectedOfferLine);
            string[] propertiesChanged = { nameof(OfferTotal), nameof(NoOfTotalPackages), nameof(NoOfTotalPallets), nameof(OfferLinesSubtotal), nameof(TotalDiscountedPrice), nameof(TotalPercentDiscount), };
            NotifyPropertiesChanged(propertiesChanged);
        }
        private string SaveFileDialogWindow()
        {
            SaveFileDialog saveFileDialog;
            saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Gem som",
                Filter = "PDF(*.pdf)|*.pdf",
                DefaultExt = ".PDF",
                FileName = MyCustomer.CustomerName +" " + DateTime.Now.ToShortDateString()
            };
            if (saveFileDialog.ShowDialog() == false)
            { 
                throw new Exception("Der er sket en fejl med at gemme filen");
            }
            return saveFileDialog.FileName;
        }
        private void GeneratePDF()
        {
            try
            {
                pdfExporter.PDFGenerator(currentOffer, SaveFileDialogWindow());
            }
            catch {
                MessageBox.Show("gem PDF blev afbrudt");
            }
        }
        private bool CanGeneratePDF()
        {
            return (OfferLines.Count > 0);     
        }
        private bool CanAdd()
        {
            if(SelectedItem != null)
            {
                return true;
            }

            return false;
        }
        private void AddItem()
        {
            if (SelectedItem != null)
            {
                if (int.TryParse(QuantityTextBoxText, out int quantity))
                    AddOfferLine(SelectedItem, quantity);
                else
                {
                    MessageBox.Show("Ugyldigt heltal. Indtast gyldigt heltal.");
                }
            }
            else
            {
                MessageBox.Show("Du skal vælge en vare fra listen.");
            }
        }
        public void AddCustomer(Customer newCustomer)
        {
            MyCustomer = newCustomer;
        }
    }
}
