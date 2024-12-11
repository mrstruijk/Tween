using System;


namespace SOSXR.Tweening
{
    /// <summary>
    ///     From Sasquatch B Studio Tutorial: https://www.youtube.com/watch?v=43o0FzU55V4
    /// </summary>
    public interface ITween
    {
        object Target { get; }

        bool IsComplete { get; }

        bool WasKilled { get; }

        bool IsPaused { get; }

        bool DoIgnoreTimeScale { get; }

        string Identifier { get; }

        float DelayTime { get; }

        Action OnComplete { get; }


        void Update();


        void OnCompleteKill();


        void FullKill();


        bool TargetWasDestroyed();


        void Pause();


        void Resume();


        void Toggle();


        void NullifyOnComplete();
    }
}