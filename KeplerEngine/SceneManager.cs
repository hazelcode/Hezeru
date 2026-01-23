using KeplerEngine.Rendering;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace KeplerEngine;

public class SceneManager
{

    public class SceneRenderLayer : RenderLayer
    {
        public IScene Scene { get; set; }

        new public byte Order { get => base.Order; set
            {
                base.Order = value;
                Globals.ReorderRenderLayers();
            } }

        public void ChangeScene(IScene scene)
        {
            Scene = scene;
        }
        public SceneRenderLayer(byte order) : base(order) { }

        public override void Render(GameTime gameTime)
        {
            if (Scene == null) return;

            Scene.Draw();
        }
    }

    private readonly Stack<IScene> sceneStack;
    
    public SceneRenderLayer SceneLayer { get; } = new SceneRenderLayer(0);
    
    public SceneManager()
    {
        sceneStack = [];
    }

    /// <summary>
    /// This method changes the order in which Kepler Engine renders the actual scene,
    /// under or over other graphical overlays;
    /// not the actual scene.
    /// </summary>
    public void SetRenderLayerOrder(byte order)
    {
        SceneLayer.Order = order;
        Globals.ReorderRenderLayers();
    }

    public IScene GetCurrentScene()
    {
        return sceneStack.Peek();
    }

    public void AddScene(IScene scene, bool removeLastScene = false)
    {
        scene.Load();
        if (removeLastScene)
            RemoveScene();

        sceneStack.Push(scene);
        SceneLayer.ChangeScene(scene);
    }

    public void RemoveScene()
    {
        sceneStack.Pop();
    }
}