using Godot;

namespace EndpointCompareGui.proxies
{
    public class ItemListProxy : IProxy
    {
        public Control Node => ItemList.Initialize(this.ItemProxy, this.AddButtonText);

        private IProxy ItemProxy { get; }
        private string AddButtonText { get; }

        public ItemListProxy(IProxy proxy, string addButtonText = "+ Add Item")
        {
            this.ItemProxy = proxy;
            this.AddButtonText = addButtonText;
        }
    }
}