namespace EndpointCompareGui.proxies
{
    public class SingleItemProxy<T> : ValueProxy<T>
    {
        private SingleItem<T> Node { get; }

        public SingleItemProxy(SingleItem<T> control) : base(control)
        {
            this.Node = control;
        }

        public override T GetValue() => this.Node.GetValue();
    }
}
