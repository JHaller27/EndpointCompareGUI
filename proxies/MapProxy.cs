using System.Collections.Generic;

namespace EndpointCompareGui.proxies
{
    public class MapProxy<TK,TV> : ValueProxy<IDictionary<TK,TV>>
    {
        private ItemMap<TK, TV> Node { get; }

        public MapProxy(ItemMap<TK, TV> control) : base(control)
        {
            this.Node = control;
        }

        public override IDictionary<TK, TV> GetValue() => this.Node.GetValues();
    }
}
