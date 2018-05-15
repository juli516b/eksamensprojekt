using System.Collections.Generic;
using Model.BaseTypes;

namespace Model
{
    public class ItemDataHandler : IPersistentItemDataHandler
    {
        public IList<IBaseItem> GetAll(IList<IBaseItem> items)
        {
            IBaseItem item1 = new Item("X - Tra Crispy, Coated, lige 10 * 10mm skin-on", "230027", 10,"Frankrig",25.5, 100);
            IBaseItem item2 = new Item("Kyllingefilet 15 % lage 140 - 180g 2x2,5kg", "162194", 376.77, "Østrig",30, 125);
            IBaseItem item3 = new Item("Kyllingevinger 3 - leds 8x2Kg", "74299", 411.52, "Sverige", 75, 150);
            IBaseItem item4 = new Item("X-Tra Crispy, Coated, lige 14 * 14mm", "1015866 - 6K", 31.76, "JulianLand", 2.5, 75);
            IBaseItem item5 = new Item("Spicy Kartoffelbåd 1 / 8, skin - on", "1016423 - 1V", 25.95, "Spanien", 50,50);
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);
            return items;
        }
    }
}
