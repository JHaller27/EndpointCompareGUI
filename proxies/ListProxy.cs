using System.Collections.Generic;

namespace EndpointCompareGui.proxies
{
    public class ListProxy<T> : ValueProxy<IEnumerable<T>>
    {
        private ItemList<T> Node { get; }
        public ListProxy(ItemList<T> control) : base(control)
        {
            this.Node = control;
        }

        public override IEnumerable<T> GetValue() => this.Node.GetChildValues();
    }
}
