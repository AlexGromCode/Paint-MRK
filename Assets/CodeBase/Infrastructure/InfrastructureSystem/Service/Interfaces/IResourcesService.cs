using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface IResourcesService
    {
        public Object GetPrefab(string path);
    }
}