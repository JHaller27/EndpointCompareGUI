using System.Collections.Generic;
using Godot;

namespace EndpointCompareGui.proxies
{
    public class EnumProxy : IProxy
    {
        public Control Create() => EnumValue.Initialize(this.Items);
        private IEnumerable<string> Items { get; }

        public EnumProxy(IEnumerable<string> items)
        {
            this.Items = items;
        }
    }
}