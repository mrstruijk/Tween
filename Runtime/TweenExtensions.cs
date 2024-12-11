using UnityEngine;


public static class TweenExtensions
{
    public static Tween<Vector3> TweenScale(this Transform trans, Vector3 startScale, Vector3 endScale, float duration)
    {
        var id = $"{trans.GetInstanceID()}_Scale";

        var tween = new Tween<Vector3>(trans, id, startScale, endScale, duration, value => { trans.localScale = value; });

        return tween;
    }


    public static Tween<Vector3> TweenScale(this Transform trans, Vector3 endScale, float duration)
    {
        return TweenScale(trans, trans.localScale, endScale, duration);
    }


    public static Tween<Vector3> TweenScale(this Transform trans, float uniformEndScale, float duration)
    {
        var endScale = new Vector3(uniformEndScale, uniformEndScale, uniformEndScale);

        return TweenScale(trans, trans.localScale, endScale, duration);
    }
}