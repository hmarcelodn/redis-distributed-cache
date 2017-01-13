namespace SouthWorks.Events.Infrastructure.Serializer
{
    public interface IItemSerializer
    {
        byte[] Serialize(object item);

        object Deserialize(byte[] itemBytes);
    }
}
