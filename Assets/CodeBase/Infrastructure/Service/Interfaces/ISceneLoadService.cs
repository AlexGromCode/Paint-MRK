using System;

namespace CodeBase.Infrastructure
{
  public interface ISceneLoadService
  {
    public event EventHandler SceneChanged;

    public void Load(string name, Action onLoaded = null);
  }
}