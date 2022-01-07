public class ItemImage
{
    public string Url { get; private set; }

    private ItemImage()
    {

    }

    public static ItemImage Create(string url)
    {
        return new ItemImage()
            .SetImageUrl(url);
    }

    public ItemImage SetImageUrl(string url)
    {
        var startIndex = url.IndexOf("\"") + 1;
        var endIndex = url.IndexOf("_") - startIndex;
        Url = url.Substring(startIndex, endIndex);
        return this;
    }
}