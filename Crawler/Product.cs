public class Product
{
    public string Name { get; private set; }
    public ItemPriceList ItemPriceList { get; private set; }

    private Product(string name, ItemPriceList itemPriceList)
    {
        Name = System.Net.WebUtility.HtmlDecode(name);
        ItemPriceList = itemPriceList;
    }

    public static Product Create(string name, ItemPriceList itemPriceList)
    {
        return new Product(name, itemPriceList);
    }
}
