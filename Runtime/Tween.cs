using System;
using UnityEngine;


/// <summary>
///     From Sasquatch B Studio Tutorial: https://www.youtube.com/watch?v=43o0FzU55V4
/// </summary>
public class Tween<T> : ITween
{
    private T _startValue;
    private T _endValue;
    private float _duration; // In seconds
    private Action<T> _onTweenUpdate; // Called every frame, to lerp the value of type T  
    private float _elapsedTime = 0f; // In seconds
    private EasingType _easingType = EasingType.Linear;

    private float _delayElapsedTime = 0f; // Seconds
    private int _loopsCompleted = 0;
    private bool _reverse = false;
    private bool _pingPong = false;
    private int _loopCount = 1;
    private float _percentThreshold = -1f;

    private Action _onUpdate;
    private Action _onPercentCompleted;
    
    /// <summary>
    ///     Constructor
    /// </summary>
    public Tween(object target, string identifier, T startValue, T endValue, float duration, Action<T> onTweenUpdate)
    {
        Target = target;
        Identifier = identifier;
        _startValue = startValue;
        _endValue = endValue;
        _duration = duration;
        _onTweenUpdate = onTweenUpdate;
        
        TweenManager.Instance.AddTween<T>(this);
    }


    /// <summary>
    ///     Will be called from TweenManager
    /// </summary>
    public void Update()
    {
        if (IsPaused)
        {
            return;
        }
        
        if (IgnoreTimeScale)
        {
            _delayElapsedTime += Time.unscaledDeltaTime;
        }
        else
        {
            _delayElapsedTime += Time.deltaTime;
        }

        if (_delayElapsedTime < DelayTime)
        {
            return;
        }
        
        if (IsComplete)
        {
            return; 
        }

        if (TargetWasDestroyed())
        {
            FullKill();
            return;
        }

        if (IgnoreTimeScale)
        {
            _elapsedTime += Time.unscaledDeltaTime;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }

        float percentage = _elapsedTime / _duration;
        float easedPercentage = Ease(_easingType, percentage);
        T currentValue;

        if (_reverse)
        {
            currentValue = Interpolate(_endValue, _startValue, easedPercentage);
        }
        else
        {
            currentValue = Interpolate(_startValue, _endValue, easedPercentage);
        }
        
        _onUpdate?.Invoke();
        _onTweenUpdate?.Invoke(currentValue);

        if (_percentThreshold >= 0f && percentage >= _percentThreshold)
        {
            _onPercentCompleted?.Invoke();
            _percentThreshold = -1f; // Making sure it doesn't get called every frame (combined with the above >=0 check)
        }

        if (_elapsedTime < _duration)
        {
            return;
        }

        _loopsCompleted++;
        _elapsedTime = 0f;

        if (_pingPong)
        {
            _reverse = !_reverse;
        }

        if (_loopCount > 0 && _loopsCompleted >= _loopCount)
        {
            OnCompleteKill();
        }
    }

    /// <summary>
    /// Some cents from my testing if anyone's interested. The Interpolate() function as in the video allocates GC, due to boxing of value types 'is' and 'object' conversions. In my case 180 objects allocated 30kb of GC per frame, so I've found that making the function abstract and overloading it in ie FloatTween : Tween<float> avoided the GC allocation and it ended up being faster since there was no need for conversions and if statements.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public T Interpolate(T start, T end, float percentage)
    {
        if (start is float startFloat && end is float endFloat)
        {
            var value = Mathf.LerpUnclamped(startFloat, endFloat, percentage); // Important to use LerpUnclamped for floats in a Tween Library, because some Easing functions purposely overshoot the end values. They don't work when using regular Lerp.
            var generic = (T) (object) value; // Because we're trying to create a generic system, this method returns a generic type. Casting it through T and object should do so.

            return generic;
        }

        if (start is Vector3 startVector && end is Vector3 endVector)
        {
            return (T)(object) Vector3.LerpUnclamped(startVector, endVector, percentage); // Direct cast for brevity
        }

        if (start is Color startColor && end is Color endColor)
        {
            return (T)(object) Color.Lerp(startColor, endColor, percentage); // Not using Unclamped for color, since they get a little weird when overshot.
        }

        throw new NotImplementedException($"Interpolation for type {typeof(T)} is not yet implemented");
    }

    /// <summary>
    /// Specifically for when the tween completes and is finished
    /// </summary>
    public void OnCompleteKill()
    {
        IsComplete = true;

        _onUpdate = null;
        _onTweenUpdate = null;
        _onPercentCompleted = null;
    }

    
    /// <summary>
    /// Will get killed if the object referencing the tween gets destroyed
    /// </summary>
    public void FullKill()
    {
        OnCompleteKill();
        WasKilled = true;
        onComplete = null;
        
    }


    public bool TargetWasDestroyed()
    {
        if (Target is MonoBehaviour monoBehaviour && monoBehaviour == null)
        {
            return true;
        }

        if (Target is GameObject go && go == null)
        {
            return true;
        }

        if (Target is Delegate del && del.Target == null)
        {
            return true;
        }

        return false;
    }


    public void Pause()
    {
        IsPaused = true;
    }


    public void Resume()
    {
        IsPaused = false;
    }


    public void Toggle()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public Tween<T> SetEase(EasingType easingType)
    {
        _easingType = easingType;

        return this;  // This allows for Method Chaining
    }
    
    /// <summary>
    /// -1 loops forever
    /// </summary>
    /// <param name="loopCount"></param>
    /// <returns></returns>
    public Tween<T> SetPingPong(int loopCount = 1)
    {
        _loopCount = loopCount;
        _pingPong = true;

        return this;
    }


    public Tween<T> SetOnComplete(Action doOnComplete)
    {
        this.onComplete = doOnComplete;

        return this;
    }


    public Tween<T> SetIgnoreTimeScale()
    {
        IgnoreTimeScale = true;

        return this;
    }


    public Tween<T> SetOnUpdate(Action onUpdate)
    {
        this._onUpdate = onUpdate;

        return this;
    }


    public Tween<T> SetOnPercentCompleted(float percentCompleted,Action onPercentCompleted) // Better called 'thresholdPercentage'
    {
        _percentThreshold = Mathf.Clamp01(percentCompleted); // This is weird, and I think should be scaled and not clamped
        this._onPercentCompleted = onPercentCompleted;

        return this;
    }


    public Tween<T> SetStartDelay(float delayTime)
    {
        DelayTime = delayTime;

        return this;
    }
    
    public object Target { get; }
    public bool IsComplete { get; private set; }
    public bool WasKilled { get; private set; }
    public bool IsPaused { get; private set; }
    public bool IgnoreTimeScale { get; private set; }
    public string Identifier { get; }
    public float DelayTime { get; private set; }
    public Action onComplete { get; set; }


    public static float Ease(EasingType equation, float t)
    {
        switch (equation)
        {
            case EasingType.Linear:
                return EasingEquations.Linear(t);
            case EasingType.EaseInQuad:
                return EasingEquations.EaseInQuad(t);
            case EasingType.EaseOutQuad:
                return EasingEquations.EaseOutQuad(t);
            case EasingType.EaseInOutQuad:
                return EasingEquations.EaseInOutQuad(t);
            case EasingType.EaseInCubic: 
                return EasingEquations.EaseInCubic(t);
            case EasingType.EaseOutCubic:
                return EasingEquations.EaseOutCubic(t);
            case EasingType.EaseInOutCubic :
                return EasingEquations.EaseInOutCubic(t);
            case EasingType.EaseInQuart:
                return EasingEquations.EaseInQuart(t);
            case EasingType.EaseOutQuart:
                return EasingEquations.EaseOutQuart(t);
            case EasingType.EaseInOutQuart:
                return EasingEquations.EaseInOutQuart(t);
            case EasingType.EaseInQuint:
                return EasingEquations.EaseInQuint(t);  
            case EasingType.EaseOutQuint:
                return EasingEquations.EaseOutQuint(t);
            case EasingType.EaseInOutQuint:
                return EasingEquations.EaseInOutQuint(t);
            case EasingType.EaseInSine:
                return EasingEquations.EaseInSine(t);
            case EasingType.EaseOutSine:
                return EasingEquations.EaseOutSine(t);
            case EasingType.EaseInOutSine:
                return EasingEquations.EaseInOutSine(t);
            case EasingType.EaseInExpo:
                return EasingEquations.EaseInExpo(t);
            case EasingType.EaseOutExpo:
                return EasingEquations.EaseOutExpo(t);
            case EasingType.EaseInOutExpo:
                return EasingEquations.EaseInOutExpo(t);
            case EasingType.EaseInCirc:
                return EasingEquations.EaseInCirc(t);
            case EasingType.EaseOutCirc:
                return EasingEquations.EaseOutCirc(t);
            case EasingType.EaseInOutCirc:
                return EasingEquations.EaseInOutCirc(t);
            case EasingType.EaseInElastic:
                return EasingEquations.EaseInElastic(t);
            case EasingType.EaseOutElastic:
                return EasingEquations.EaseOutElastic(t);
            case EasingType.EaseInOutElastic:
                return EasingEquations.EaseInOutElastic(t);
            case EasingType.EaseInBack:
                return EasingEquations.EaseInBack(t);
            case EasingType.EaseOutBack:
                return EasingEquations.EaseOutBack(t);
            case EasingType.EaseInOutBack:
                return EasingEquations.EaseInOutBack(t);
            case EasingType.EaseInBounce:
                return EasingEquations.EaseInBounce(t);
            case EasingType.EaseOutBounce:
                return EasingEquations.EaseOutBounce(t);
            case EasingType.EaseInOutBounce:
                return EasingEquations.EaseInOutBounce(t);
            default:
                throw new ArgumentOutOfRangeException(nameof(equation), equation, null);
            
        }
    }
}