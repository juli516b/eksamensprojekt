using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BaseTypes
{
    public interface IBaseOffer 
    {
        int? OfferNo { get; set; }
        IBaseCustomer MyCustomer { get; set; }
        ObservableCollection<IExtendOfferLine> OfferLines { get; set; }
        double OfferDiscountPercent { get; set; }
        DateTime OfferCreationDate { get; set; }
        double ForwardingAgentPrice { get; set; }
    }
}
