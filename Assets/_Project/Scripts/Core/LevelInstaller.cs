using UnityEngine;
using Zenject;

namespace Comments.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [field: SerializeField] public Player PlayerPrefab { get; private set; }
        [field: SerializeField] public PlayerInputContainer PlayerInputCanvasPrefab { get; private set; }
        [field: SerializeField] public LevelContainer LevelContainer { get; private set; }

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInNewPrefab(PlayerPrefab).AsSingle().NonLazy();
            Container.Bind<PlayerInputContainer>().FromComponentInNewPrefab(PlayerInputCanvasPrefab).AsSingle().NonLazy();

            Container.Bind<LevelContainer>().FromInstance(LevelContainer).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelInitializer>().AsSingle().NonLazy();

            Container.Bind<GameManager>().AsSingle().NonLazy();
        }
    }
}

