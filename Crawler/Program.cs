using HtmlAgilityPack;

var url = "https://kidskimberry.en.alibaba.com/product/1600425793258-823061133/2022_Children_s_wear_two_sets_of_pure_color_suspenders_chest_pit_stripe_jacket_and_pants_toddler_girls_summer_clothing_set.html?spm=a2700.shop_pl.41413.33.3c3c63fcjyYSTy";

Crawler.startCrawlerAsync(url);
Console.ReadLine();

partial class Crawler
{
    public static async Task startCrawlerAsync(string url)
    {
        var htmlDocument = await GetHtmlDocument(url);

        var itemName = GetItemName(htmlDocument);
        var itemPriceList = GetItemPriceList(htmlDocument);
        var itemSizeList = GetItemSizeList(htmlDocument);
        var itemImageList = GetItemImageList(htmlDocument);

        var product = Product.Create(itemName, itemPriceList, itemSizeList,
            itemImageList);

        Console.WriteLine(product.Name);
    }

    public static async Task<HtmlDocument> GetHtmlDocument(string url)
    {
        var client = new HttpClient();
        var html = await client.GetStringAsync(url);
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        return htmlDocument;
    }

    public static string GetItemName(HtmlDocument htmlDocument)
    {
        var moduleTitleList = htmlDocument.DocumentNode.Descendants("div")
          .Where(n => n.GetAttributeValue("id", "").Equals("module_title")).ToList();

        return moduleTitleList[0].InnerText;
    }

    public static ItemPriceList GetItemPriceList(HtmlDocument htmlDocument)
    {
        var modulePriceList = htmlDocument.DocumentNode.Descendants("li")
            .Where(n => n.GetAttributeValue("class", "").Contains("ma-ladder-price-item")).ToList();

        var itemPriceList = ItemPriceList.Create();

        foreach (var item in modulePriceList)
        {
            itemPriceList.Add(ItemPrice.Create(item.InnerText));
        }

        return itemPriceList;
    }

    public static ItemSizeList GetItemSizeList(HtmlDocument htmlDocument)
    {
        var moduleSizeList = htmlDocument.DocumentNode.Descendants("span")
            .Where(n => n.GetAttributeValue("class", "").Contains("sku-attr-val-frame")
            && !n.GetAttributeValue("class", "").Contains("picture-frame")).ToList();

        var itemSizeList = ItemSizeList.Create();

        foreach (var item in moduleSizeList)
        {
            itemSizeList.Add(ItemSize.Create(item.InnerText));
        }

        return itemSizeList;
    }

    public static ItemImageList GetItemImageList(HtmlDocument htmlDocument)
    {
        var imageList = htmlDocument.DocumentNode.Descendants("li")
            .Where(n => n.GetAttributeValue("class", "").Contains("main-image-thumb-item")).ToList();

        var itemImageList = ItemImageList.Create();

        foreach (var item in imageList)
        {
            itemImageList.Add(ItemImage.Create(item.InnerHtml));
        }

        return itemImageList;
    }
}