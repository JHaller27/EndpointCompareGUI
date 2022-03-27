using Godot;

namespace EndpointCompareGui.proxies
{
    public class ItemMapProxy : IProxy
    {
        public Control Create() => ItemMap.Initialize(this.KeyProxy, this.ValProxy, this.AddButtonText);

        private IProxy KeyProxy { get; }
        private IProxy ValProxy { get; }
        private string AddButtonText { get; }

        public ItemMapProxy(IProxy keyProxy, IProxy valProxy, string addButtonText = "+ Add Item")
        {
            this.KeyProxy = keyProxy;
            this.ValProxy = valProxy;
            this.AddButtonText = addButtonText;
        }
    }
}