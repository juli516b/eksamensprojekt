﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model;
using Model.BaseTypes;
using Model.DataHandlers;

namespace ViewModel
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        readonly IPersistentItemDataHandler dataHandler;
        private readonly PDFExporter pdfExporter;
        private ICommand clickAddButtonCommand;
        private ICommand clickGeneratePDFCommand;
        private readonly Offer currentOffer;

        public Customer MyCustomer
        {
            get
            {
                Customer customer = new Customer() { CustomerName = "Ingen kunde valgt. Klik for at tilføje" };
                if (currentOffer.MyCustomer != null)
                {
                    customer = currentOffer.MyCustomer;
                }
                return customer;
            }
            set
            {
                currentOffer.MyCustomer = value;
                NotifyPropertyChanged("MyCustomer");
                NotifyPropertyChanged("OfferTotal");
                NotifyPropertyChanged("MyCustomerDiscount");
                NotifyPropertyChanged("TotalPercentDiscount");
            }
        }
        public string OfferLinesSubtotal
        {
            get { return currentOffer.OfferSubtotal + " DKK"; }
        }
        public string MyCustomerDiscount
        {
            get
            {
                string customerDiscount_Label = "";
                if (MyCustomer != null)
                {
                    customerDiscount_Label = MyCustomer.CustomerDiscount + " %";
                }
                return customerDiscount_Label;
            }
            set
            {
                MyCustomer.CustomerDiscount = Convert.ToDouble(value);
                NotifyPropertyChanged("TotalPercentDiscount");
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
                NotifyPropertyChanged("TotalPercentDiscount");
                NotifyPropertyChanged("OfferTotal");
            }
        }
        public IBaseItem SelectedItem { get; set; }
        public string QuantityTextBoxText { get; set; }

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

        private void GeneratePDF()
        {
            pdfExporter.PDFGenerator(currentOffer);
        }
        private bool CanGeneratePDF()
        {
            return (OfferLines.Count > 0);     
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

        public IList<IBaseItem> Items {
            get { return ItemRepository.GetInstance(dataHandler).Items; }
            set { ItemRepository.GetInstance(dataHandler).Items = value; }
        }
        public string OfferDiscount
        {
            get { return Math.Round(currentOffer.OfferDiscount,2).ToString(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    currentOffer.OfferDiscount = 0;

                }
                else { 
                    currentOffer.OfferDiscount = Convert.ToDouble(value);
                }
                NotifyPropertyChanged("TotalDiscountedPrice");
                NotifyPropertyChanged("TotalPercentDiscount");
                NotifyPropertyChanged("OfferTotal");
            }
        }
        public ObservableCollection<OfferLine> OfferLines
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public OfferViewModel()
        {
            dataHandler = new ItemDataHandler();
            pdfExporter = new PDFExporter();
            currentOffer = new Offer(DateTime.Now);

            SelectedItem = Items[0];
        }
        public void AddOfferLine(IBaseItem myItem, int quantity)
        {
            OfferLine newOfferLine = new OfferLine(myItem, quantity);
            OfferLines.Add(newOfferLine);
            newOfferLine.APWC += NotifyPropertyChanged;
            NotifyPropertyChanged("OfferTotal");
            NotifyPropertyChanged("NoOfTotalPackages");
            NotifyPropertyChanged("NoOfTotalPallets");
            NotifyPropertyChanged("OfferLinesSubtotal");
            NotifyPropertyChanged("TotalDiscountedPrice");
            NotifyPropertyChanged("TotalPercentDiscount");
        }
    }
}
