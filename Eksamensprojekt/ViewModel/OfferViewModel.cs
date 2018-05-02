﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        IPersistentDataHandler dataHandler;
        private ICommand _clickAddButtonCommand;
        private Offer currentOffer;
       // private int quantityTextBoxText;

        public IBaseItem SelectedItem { get; set; }
        public string QuantityTextBoxText { get; set; }

        public ICommand AddButtonCommand
        {
            get
            {
                if (_clickAddButtonCommand == null)
                {
                    _clickAddButtonCommand = new DelegateCommand(
                        param => this.AddObject(),
                        param => this.CanAdd()
                    );
                }
                return _clickAddButtonCommand;
            }
        }

        private bool CanAdd()
        {
            if(SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddObject()
        {
            if (SelectedItem != null)
            {
                if (int.TryParse(QuantityTextBoxText, out int quantity))
                {
                   AddOfferLine((Model.IBaseItem)SelectedItem, quantity);
                    
                }
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
                currentOffer.OfferDiscount = Convert.ToDouble(value);
                NotifyPropertyChanged("OfferTotal");
            }
        }
        public ObservableCollection<OfferLine> OfferLines
        {
            get { return currentOffer.OfferLines; }
            set { currentOffer.OfferLines = value; }
        }

        public double OfferTotal {
            get { return currentOffer.OfferTotal; }
            set { currentOffer.OfferTotal = value; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public OfferViewModel()
        {
            dataHandler = new ItemDataHandler();
            currentOffer = new Offer(DateTime.Now);
            SelectedItem = Items[0];

        }
        public void AddOfferLine(IBaseItem myItem, int quantity)
        {
            OfferLine newOfferLine = new OfferLine(myItem, quantity);
            OfferLines.Add(newOfferLine);
            newOfferLine.APWC += NotifyPropertyChanged;
            NotifyPropertyChanged("OfferTotal");
        }
    }
}
