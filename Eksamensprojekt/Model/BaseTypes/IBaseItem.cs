namespace Model.BaseTypes
{
    public interface IBaseItem
    {
        string ItemName { get; set; }
        string ItemNo { get; set; }
        double ItemPrice { get; set; }
        int CountPerPallet { get; set; }
    }
}
