using EndpointCompareGui.proxies;
using Godot;

namespace EndpointCompareGui.factories.primitives
{
    public class StringFactory : PrimitiveFactory<string>
    {
        public StringFactory() : base("String")
        {
        }

        public override ValueProxy<string> Create() => new StringProxy(this.PrimitiveScene.Instance<LineEdit>());
    }
}
