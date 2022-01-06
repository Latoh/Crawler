public class Product
{
    public string Url { get; private set; }
    public string Name { get; private set; }
    public ItemPriceList ItemPriceList { get; private set; }
    public ItemSizeList ItemSizeList { get; private set; }
    public ItemImageList ItemImageList { get; private set; }

    private Product(string name, ItemPriceList itemPriceList, ItemSizeList itemSizeList,
        ItemImageList itemImageList)
    {
        Name = System.Net.WebUtility.HtmlDecode(name);
        ItemPriceList = itemPriceList;
        ItemSizeList = itemSizeList;
        ItemImageList = itemImageList;
    }

    public static Product Create(string name, ItemPriceList itemPriceList, ItemSizeList itemSizeList,
        ItemImageList itemImageList)
    {
        return new Product(name, itemPriceList, itemSizeList, itemImageList);
    }
}
