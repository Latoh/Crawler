public class ItemPrice
{
    public string Pieces { get; private set; }
    public decimal Price { get; private set; }

    private ItemPrice()
    {

    }

    public static ItemPrice Create(string itemPrice)
    {

        return new ItemPrice()
            .SetPieces(itemPrice)
            .SetPrice(itemPrice);
    }

    public ItemPrice SetPieces(string itemPrice)
    {
        var startIndex = itemPrice.IndexOf("-") + 1;
        var endIndex = itemPrice.IndexOf("P") - startIndex;
        Pieces = itemPrice.Substring(startIndex, endIndex).Trim();
        return this;
    }

    public ItemPrice SetPrice(string itemPrice)
    {
        var index = itemPrice.IndexOf("$");
        Price = Convert.ToDecimal(itemPrice.Substring(index + 1));
        return this;
    }
}

