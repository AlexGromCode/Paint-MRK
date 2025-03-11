using UnityEngine;

namespace CodeBase.Infrastructure
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig")]
    public class GameConfigSo : ScriptableObject
    {
        [field: SerializeField] public SceneName FirstSceneName { get; private set; }
        [field: SerializeField] public SceneName InitialGameScene { get; private set; }
        [field: SerializeField] public SceneName GameScene { get; private set; }
    }
}