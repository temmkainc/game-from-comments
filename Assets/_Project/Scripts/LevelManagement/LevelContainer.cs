using UnityEngine;

namespace Comments.Level
{

    public class LevelContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform SpawnPoint { get; set; }
        [field: SerializeField] public FinishPoint FinishPoint { get; set; }
        [field: SerializeField] public DeathZone DeathZone { get; set; }
    }
}