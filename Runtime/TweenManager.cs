
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// From Sasquatch B Studio Tutorial: https://www.youtube.com/watch?v=43o0FzU55V4
/// </summary>
public class TweenManager : MonoBehaviour
{
    private static TweenManager _instance;

    public static TweenManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject manager = new GameObject("TweenManager");
                _instance = manager.AddComponent<TweenManager>();
            }

            return _instance;
        }
    }

    private Dictionary<string, ITween> _activeTweens = new();


    public void AddTween<T>(ITween tween)
    {
        if (_activeTweens.ContainsKey(tween.Identifier))
        {
            Debug.LogFormat(tween.Target as GameObject, "We are redoing an identical tween again before the previous one is completed. Is that intentional?");
            
            _activeTweens[tween.Identifier].OnCompleteKill();
        }
        _activeTweens[tween.Identifier] = tween;
    }


    private void Update()
    {
        var dictAsList = _activeTweens.ToList(); // We're taking a snapshot of the dictionary while we're iterating through it. This way we don't really delete some item from the dictionary while iterating, thus preventing some errors.
        
        foreach (var activeTween in dictAsList)
        {
            ITween tween = activeTween.Value;
            tween.Update();

            if (tween.IsComplete && !tween.WasKilled) // The tween.onComplete is called from here because this shouldn't be called while removing items from the dictionary. If this were still called on the Update of the Tween itself, there was a risk of that happening.
            {
                if (tween.onComplete != null)
                {
                    tween.onComplete.Invoke(); // 
                    tween.onComplete = null;
                }
                
                RemoveTween(activeTween.Key);
            }

            if (tween.WasKilled)
            {
                RemoveTween(activeTween.Key);
            }
        }
    }


    public void RemoveTween(string identifier)
    {
        _activeTweens.Remove(identifier);
    }

    
    public static Tween<float> TweenSpriteAlpha(GameObject go, float startAlpha, float endAlpha, float duration)
    {
        SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogErrorFormat($"Component {typeof(SpriteRenderer)} not found!");

            return null;
        }

        string id = $"{spriteRenderer.GetInstanceID()}_Alpha";

        Tween<float> tween = new Tween<float>(go, id, startAlpha, endAlpha, duration, value =>
        {
            Color color = spriteRenderer.color; // Colors are structs, therefore you cannot modify them directly
            color.a = value;
            spriteRenderer.color = color;
        });

        return tween;
    }


    public static Tween<Vector3> TweenScale(GameObject go, Vector3 startScale, Vector3 endScale, float duration)
    {
        string id = $"{go.transform.GetInstanceID()}_Scale";
        var trans = go.transform;

        Tween<Vector3> tween = new Tween<Vector3>(go, id, startScale, endScale, duration, value =>
        {
            trans.localScale = value;
        });

        return tween;
    }


    public static Tween<float> TweenFloat(Func<float> getValueToTween, Action<float> setValueToTween, float endValue, float duration)
    {
        string identifier = $" {getValueToTween.Target.GetHashCode()}_Float";

        object target = getValueToTween.Target;
        var startValue = getValueToTween();

        Tween<float> tween = new Tween<float>(target, identifier, startValue, endValue, duration, value =>
        {
            setValueToTween(value);
        });

        return tween;
    }
    
}