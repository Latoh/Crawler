public class ItemImageList
{
    public List<ItemImage> ItemImages { get; private set; }

    private ItemImageList()
    {
        ItemImages = new List<ItemImage>();
    }

    public static ItemImageList Create()
    {
        return new ItemImageList();
    }

    public ItemImageList Add(ItemImage itemSize)
    {
        ItemImages.Add(itemSize);

        return this;
    }
}
