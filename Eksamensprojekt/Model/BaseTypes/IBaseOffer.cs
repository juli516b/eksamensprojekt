using System;

namespace Model.BaseTypes
{
    public interface IBaseOffer
    {
        int? OfferNo { get; set; }
        double OfferDiscountPercent { get; set; }
        DateTime OfferCreationDate { get; set; }
        double ForwardingAgentPrice { get; set; }
    }
}
