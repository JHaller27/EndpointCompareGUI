using Godot;

namespace EndpointCompareGui.factories
{
    public class ItemMapFactory : IFactory
    {
        public Control Create() => ItemMap.Initialize(this.KeyFactory, this.ValFactory, this.AddButtonText);

        private IFactory KeyFactory { get; }
        private IFactory ValFactory { get; }
        private string AddButtonText { get; }

        public ItemMapFactory(IFactory keyFactory, IFactory valFactory, string addButtonText = "+ Add Item")
        {
            this.KeyFactory = keyFactory;
            this.ValFactory = valFactory;
            this.AddButtonText = addButtonText;
        }
    }
}