using System.Collections.Generic;
using Godot;

namespace EndpointCompareGui.factories
{
    public class EnumFactory : IFactory
    {
        public Control Create() => EnumValue.Initialize(this.Items);
        private IEnumerable<string> Items { get; }

        public EnumFactory(IEnumerable<string> items)
        {
            this.Items = items;
        }
    }
}