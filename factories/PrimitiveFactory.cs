using EndpointCompareGui.proxies;
using Godot;

namespace EndpointCompareGui.factories
{
    public class PrimitiveFactory : IFactory
    {
        public ValueProxy Create() => new(this.PrimitiveScene.Instance() as Control);

        private PackedScene PrimitiveScene { get; }

        public PrimitiveFactory(PackedScene scene)
        {
            this.PrimitiveScene = scene;
        }

        public PrimitiveFactory(string name) : this((PackedScene)ResourceLoader.Load($"res://scenes/primitives/{name}Value.tscn"))
        {
        }
    }
}
