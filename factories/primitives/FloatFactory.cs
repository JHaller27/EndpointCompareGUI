using EndpointCompareGui.proxies;
using Godot;

namespace EndpointCompareGui.factories.primitives
{
    public class FloatFactory : PrimitiveFactory<float>
    {
        public FloatFactory() : base("Float")
        {
        }

        public override ValueProxy<float> Create() => new FloatProxy(this.PrimitiveScene.Instance<SpinBox>());
    }
}
