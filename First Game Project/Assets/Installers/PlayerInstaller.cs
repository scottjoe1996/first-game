using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPlayerMovementInput>()
                .To<PlayerMovementInput>()
                .AsSingle();

        Container.Bind<IPlayerAttackInput>()
                .To<PlayerAttackInput>()
                .AsSingle();
    }
}