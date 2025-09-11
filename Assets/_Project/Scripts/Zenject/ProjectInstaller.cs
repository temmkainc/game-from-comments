using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Application.targetFrameRate = 144;

        Container.BindInterfacesAndSelfTo<LevelManager>().AsSingle().NonLazy();
    }
}
