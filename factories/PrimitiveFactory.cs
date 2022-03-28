using EndpointCompareGui.proxies;
using Godot;

namespace EndpointCompareGui.factories
{
    public abstract class PrimitiveFactory<T> : IFactory<T>
    {
        public abstract ValueProxy<T> Create();

        protected PackedScene PrimitiveScene { get; }

        private PrimitiveFactory(PackedScene scene)
        {
            this.PrimitiveScene = scene;
        }

        protected PrimitiveFactory(string name) : this((PackedScene)ResourceLoader.Load($"res://scenes/primitives/{name}Value.tscn"))
        {
        }
    }
}
