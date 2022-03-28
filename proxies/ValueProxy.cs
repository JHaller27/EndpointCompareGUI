using Godot;

namespace EndpointCompareGui.proxies
{
    public class ValueProxy
    {
        public Control Control { get; }

        public ValueProxy(Control control)
        {
            this.Control = control;
        }
    }
}
