namespace ToolsSorter.Service.HoldService
{
    public interface IContainer
    {
        bool TryGetItem(out IHolded item);
    }
}
