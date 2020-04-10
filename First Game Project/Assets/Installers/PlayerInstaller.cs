using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IUnityService>()
                .To<UnityService>()
                .AsSingle();
    }
}