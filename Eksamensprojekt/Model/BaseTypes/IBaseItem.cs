﻿namespace Model.BaseTypes
{
    public interface IBaseItem
    {
        string ItemName { get; set; }
        string ItemNo { get; set; }
        double ItemPrice { get; set; }
        string ItemCountry { get; set; }
        double ItemWeight { get; set; }
        int CountPerPallet { get; set; }
    }
}
