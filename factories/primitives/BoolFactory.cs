using EndpointCompareGui.proxies;
using Godot;

namespace EndpointCompareGui.factories.primitives
{
    public class BoolFactory : PrimitiveFactory<bool>
    {
        public BoolFactory() : base("Bool")
        {
        }

        public override ValueProxy<bool> Create() => new BoolProxy(this.PrimitiveScene.Instance<CheckButton>());
    }
}
