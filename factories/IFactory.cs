using EndpointCompareGui.proxies;

namespace EndpointCompareGui.factories
{
	public interface IFactory<T>
	{
		ValueProxy<T> Create();
	}
}
