public class ItemSize
{
    public string Size { get; private set; }

    private ItemSize(string size)
    {
        Size = size;
    }

    public static ItemSize Create(string itemSize)
    {

        return new ItemSize(itemSize);
    }
}