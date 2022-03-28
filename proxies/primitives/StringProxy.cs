using Godot;

namespace EndpointCompareGui.proxies
{
    public class StringProxy : ValueProxy<string>
    {
        private LineEdit Node { get; }

        public StringProxy(LineEdit control) : base(control)
        {
            this.Node = control;
        }

        public override string GetValue()
        {
            return this.Node.Text;
        }
    }
}
