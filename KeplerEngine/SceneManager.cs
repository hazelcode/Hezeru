using System.Collections.Generic;

namespace KeplerEngine;

public class SceneManager
{
    private readonly Stack<IScene> sceneStack;

    public SceneManager()
    {
        sceneStack = [];
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
    }

    public void RemoveScene()
    {
        sceneStack.Pop();
    }
}