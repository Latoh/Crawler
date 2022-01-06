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
            .SubstringPieces(itemPrice)
            .SubstringPrice(itemPrice);
    }

    public ItemPrice SubstringPieces(string itemPrice)
    {
        var index = itemPrice.IndexOf("$");
        Pieces = itemPrice.Substring(0, index);
        return this;
    }

    public ItemPrice SubstringPrice(string itemPrice)
    {
        var index = itemPrice.IndexOf("$");
        Price = Convert.ToDecimal(itemPrice.Substring(index + 1));
        return this;
    }
}

