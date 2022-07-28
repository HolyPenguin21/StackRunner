using UnityEngine;

public class WarpEffect
{
    ParticleSystem particleSystem;

    public WarpEffect(ParticleSystem particleSystem, IGameStateEvents gameStateEvents)
    {
        this.particleSystem = particleSystem;

        gameStateEvents.Add_GameStartListener(StartEffect);
        gameStateEvents.Add_GameEndListener(StopEffect);

        StopEffect();
    }

    private void StartEffect()
    {
        particleSystem.Play();
    }

    private void StopEffect()
    {
        particleSystem.Stop();
    }
}
