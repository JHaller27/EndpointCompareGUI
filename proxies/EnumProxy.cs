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

		public override void SetValue(string value)
		{
			for (int i = 0; i < this.Node.GetItemCount(); i++)
			{
				if (this.Node.GetItemText(i) != value) continue;

				this.Node.Selected = i;
				return;
			}
		}
	}
}
