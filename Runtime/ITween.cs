using System;
using UnityEngine;

/// <summary>
/// From Sasquatch B Studio Tutorial: https://www.youtube.com/watch?v=43o0FzU55V4
/// </summary>
public interface ITween
{
    void Update();
    
    void OnCompleteKill();

    void FullKill();

    bool TargetWasDestroyed();
    
    void Pause();
    
    void Resume();
    
    object Target { get; }
    
    bool IsComplete { get; }
    
    bool WasKilled { get; }
    
    bool IsPaused { get; }
     
    bool IgnoreTimeScale { get; } 
    
    string Identifier { get; }
    
    float DelayTime { get; }
    
    Action onComplete { get; set;  }
}