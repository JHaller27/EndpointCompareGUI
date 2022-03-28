
using Godot;

namespace EndpointCompareGui.proxies
{
    public class FloatProxy : ValueProxy<float>
    {
        private SpinBox Node { get; }

        public FloatProxy(SpinBox control) : base(control)
        {
            this.Node = control;
        }

        public override float GetValue()
        {
            return (float)this.Node.Value;
        }
    }
}
