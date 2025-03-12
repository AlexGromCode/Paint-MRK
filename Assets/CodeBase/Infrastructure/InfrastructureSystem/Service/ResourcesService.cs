using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class ResourcesService : IResourcesService
    {
        public Object GetPrefab(string path) => Resources.Load(path);
    }
}