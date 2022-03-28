using EndpointCompareGui.proxies;
using Godot;

namespace EndpointCompareGui.factories.primitives
{
    public class IntFactory : PrimitiveFactory<int>
    {
        public IntFactory() : base("Int")
        {
        }

        public override ValueProxy<int> Create() => new IntProxy(this.PrimitiveScene.Instance<SpinBox>());
    }
}
