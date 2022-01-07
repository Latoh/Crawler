public class ItemPriceList
{
    public List<ItemPrice> ItemPrices { get; private set; }

    private ItemPriceList()
    {
        ItemPrices = new List<ItemPrice>();
    }

    public static ItemPriceList Create()
    {
        return new ItemPriceList();
    }

    public ItemPriceList Add(ItemPrice itemPrice)
    {
        ItemPrices.Add(itemPrice);

        return this;
    }
}