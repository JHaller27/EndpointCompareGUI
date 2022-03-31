
using Godot;

namespace EndpointCompareGui.proxies
{
    public class IntProxy : ValueProxy<int>
    {
        private SpinBox Node { get; }

        public IntProxy(SpinBox control) : base(control)
        {
            this.Node = control;
        }

        public override int GetValue()
        {
            return (int)this.Node.Value;
        }

        public override void SetValue(int value)
        {
            this.Node.Value = value;
        }
    }
}
