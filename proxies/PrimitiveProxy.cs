using Godot;

namespace EndpointCompareGui.proxies
{
    public class PrimitiveProxy : IProxy
    {
        public Control Create() => this.PrimitiveScene.Instance() as Control;

        private PackedScene PrimitiveScene { get; }

        public PrimitiveProxy(PackedScene scene)
        {
            this.PrimitiveScene = scene;
        }

        public PrimitiveProxy(string name) : this((PackedScene)ResourceLoader.Load($"res://scenes/primitives/{name}Value.tscn"))
        {
        }
    }
}