using Godot;

namespace EndpointCompareGui.factories
{
    public class ItemListFactory : IFactory
    {
        public Control Create() => ItemList.Initialize(this.ItemFactory, this.AddButtonText);

        private IFactory ItemFactory { get; }
        private string AddButtonText { get; }

        public ItemListFactory(IFactory factory, string addButtonText = "+ Add Item")
        {
            this.ItemFactory = factory;
            this.AddButtonText = addButtonText;
        }
    }
}