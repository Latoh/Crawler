
public class ItemSizeList
{

    public List<ItemSize> ItemSizes { get; private set; }

    private ItemSizeList()
    {
        ItemSizes = new List<ItemSize>();
    }

    public static ItemSizeList Create()
    {
        return new ItemSizeList();
    }

    public ItemSizeList Add(ItemSize itemSize)
    {
        ItemSizes.Add(itemSize);

        return this;
    }
}