using System;
using UnityEngine;


public static class TweenExtensionsPrimitives
{
    public static Tween<float> Tween(this float floatValue, Func<float> getValueToTween, Action<float> setValueToTween, float endValue, float duration)
    {
        var startValue = getValueToTween();

        var target = setValueToTween.Target;
        var identifier = $"{target.GetHashCode()}_Float";

        return new Tween<float>(
            target,
            identifier,
            startValue,
            endValue,
            duration,
            setValueToTween);
    }


    public static Tween<float> Tween(this float startValue, Action<float> setValueToTween, float endValue, float duration)
    {
        return Tween(startValue, () => startValue, setValueToTween, endValue, duration);
    }
}


public static class TweenExtensionsVector3
{
    public static Tween<Vector3> Tween(this Transform trans, Vector3 startScale, Vector3 endScale, float duration)
    {
        var id = $"{trans.GetInstanceID()}_Scale";

        var tween = new Tween<Vector3>(trans, id, startScale, endScale, duration, value => { trans.localScale = value; });

        return tween;
    }


    public static Tween<Vector3> Tween(this Transform trans, Vector3 endScale, float duration)
    {
        return Tween(trans, trans.localScale, endScale, duration);
    }


    public static Tween<Vector3> Tween(this Transform trans, float uniformEndScale, float duration)
    {
        var endScale = new Vector3(uniformEndScale, uniformEndScale, uniformEndScale);

        return Tween(trans, trans.localScale, endScale, duration);
    }
}


public static class TweenExtensionsRenderers
{
    public static Tween<float> Tween(this SpriteRenderer spriteRenderer, float startAlpha, float endAlpha, float duration)
    {
        var id = $"{spriteRenderer.GetInstanceID()}_Alpha";

        var tween = new Tween<float>(spriteRenderer, id, startAlpha, endAlpha, duration, value =>
        {
            var color = spriteRenderer.color; // Colors are structs, therefore you cannot modify them directly
            color.a = value;
            spriteRenderer.color = color;
        });

        return tween;
    }


    public static Tween<float> Tween(this SpriteRenderer spriteRenderer, float endAlpha, float duration)
    {
        return Tween(spriteRenderer, spriteRenderer.color.a, endAlpha, duration);
    }
}