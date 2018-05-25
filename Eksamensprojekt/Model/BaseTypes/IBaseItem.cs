namespace Model.BaseTypes
{
    public interface IBaseItem
    {
        int ItemId { get; set; }
        string ItemName { get; set; }
        string ItemNo { get; set; }
        double ItemPrice { get; set; }
        double ItemWeight { get; set; }
        int CountPerPallet { get; set; }
    }
}
