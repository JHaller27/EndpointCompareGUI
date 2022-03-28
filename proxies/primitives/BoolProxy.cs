
using Godot;

namespace EndpointCompareGui.proxies
{
    public class BoolProxy : ValueProxy<bool>
    {
        private CheckButton Node { get; }

        public BoolProxy(CheckButton control) : base(control)
        {
            this.Node = control;
        }

        public override bool GetValue()
        {
            return this.Node.Pressed;
        }
    }
}
