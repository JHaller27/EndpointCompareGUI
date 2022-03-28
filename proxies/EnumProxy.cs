namespace EndpointCompareGui.proxies
{
    public class EnumProxy : ValueProxy<string>
    {
        private EnumValue Node { get; }

        public EnumProxy(EnumValue control) : base(control)
        {
            this.Node = control;
        }

        public override string GetValue()
        {
            return this.Node.GetItemText(this.Node.Selected);
        }
    }
}
