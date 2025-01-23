using System;
using UnityEngine;


namespace SOSXR.Tweening
{
    /// <summary>
    ///     From Sasquatch B Studio Tutorial: https://www.youtube.com/watch?v=43o0FzU55V4
    ///     With help from Claude and ChatGPT
    /// </summary>
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


        public static Tween<Vector2> Tween(this Vector2 vector, Func<Vector2> getValueToTween, Action<Vector2> setValueToTween, Vector2 endValue, float duration)
        {
            var startValue = getValueToTween();

            var target = setValueToTween.Target;
            var identifier = $"{target.GetHashCode()}_Vector2";

            return new Tween<Vector2>(
                target,
                identifier,
                startValue,
                endValue,
                duration,
                setValueToTween);
        }


        public static Tween<Vector2> Tween(this Vector2 startValue, Action<Vector2> setValueToTween, Vector2 endValue, float duration)
        {
            return Tween(startValue, () => startValue, setValueToTween, endValue, duration);
        }


        public static Tween<Vector3> Tween(this Vector3 vector, Func<Vector3> getValueToTween, Action<Vector3> setValueToTween, Vector3 endValue, float duration)
        {
            var startValue = getValueToTween();

            var target = setValueToTween.Target;
            var identifier = $"{target.GetHashCode()}_Vector3";

            return new Tween<Vector3>(
                target,
                identifier,
                startValue,
                endValue,
                duration,
                setValueToTween);
        }


        public static Tween<Vector3> Tween(this Vector3 startValue, Action<Vector3> setValueToTween, Vector3 endValue, float duration)
        {
            return Tween(startValue, () => startValue, setValueToTween, endValue, duration);
        }


        public static Tween<Quaternion> Tween(this Quaternion quaternion, Func<Quaternion> getValueToTween, Action<Quaternion> setValueToTween, Quaternion endValue, float duration)
        {
            var startValue = getValueToTween();

            var target = setValueToTween.Target;
            var identifier = $"{target.GetHashCode()}_Quaternion";

            return new Tween<Quaternion>(
                target,
                identifier,
                startValue,
                endValue,
                duration,
                setValueToTween);
        }


        public static Tween<Quaternion> Tween(this Quaternion startValue, Action<Quaternion> setValueToTween, Quaternion endValue, float duration)
        {
            return Tween(startValue, () => startValue, setValueToTween, endValue, duration);
        }
    }


    public static class TweenExtensionsTransform
    {
        public static Tween<Vector3> TweenScale(this Transform trans, Vector3 start, Vector3 end, float duration)
        {
            var id = $"{trans.GetInstanceID()}_Scale";

            var tween = new Tween<Vector3>(trans, id, start, end, duration, value => { trans.localScale = value; });

            return tween;
        }


        public static Tween<Vector3> TweenScale(this Transform trans, Vector3 end, float duration)
        {
            return TweenScale(trans, trans.localScale, end, duration);
        }


        public static Tween<Vector3> TweenScale(this Transform trans, float end, float duration)
        {
            var endValue = new Vector3(end, end, end);

            return TweenScale(trans, trans.localScale, endValue, duration);
        }


        public static Tween<Vector3> TweenScale(this Transform trans, float start, float end, float duration)
        {
            var startValue = new Vector3(start, start, start);
            var endValue = new Vector3(end, end, end);

            return TweenScale(trans, startValue, endValue, duration);
        }


        public static Tween<Vector3> TweenPosition(this Transform trans, Vector3 start, Vector3 end, float duration)
        {
            var id = $"{trans.GetInstanceID()}_Position";

            var tween = new Tween<Vector3>(trans, id, start, end, duration, value => { trans.position = value; });

            return tween;
        }


        public static Tween<Vector3> TweenPosition(this Transform trans, Vector3 end, float duration)
        {
            return TweenPosition(trans, trans.position, end, duration);
        }


        public static Tween<Vector3> TweenPosition(this Transform trans, float end, float duration)
        {
            var endValue = new Vector3(end, end, end);

            return TweenPosition(trans, trans.position, endValue, duration);
        }


        public static Tween<Vector3> TweenLocalPosition(this Transform trans, Vector3 start, Vector3 end, float duration)
        {
            var id = $"{trans.GetInstanceID()}_LocalPosition";

            var tween = new Tween<Vector3>(trans, id, start, end, duration, value => { trans.localPosition = value; });

            return tween;
        }


        public static Tween<Vector3> TweenLocalPosition(this Transform trans, Vector3 end, float duration)
        {
            return TweenLocalPosition(trans, trans.localPosition, end, duration);
        }


        public static Tween<Vector3> TweenLocalPosition(this Transform trans, float end, float duration)
        {
            var endValue = new Vector3(end, end, end);

            return TweenLocalPosition(trans, trans.localPosition, endValue, duration);
        }


        /// <summary>
        ///     So taking into account the starting position, and having the end position be relative to the starting position
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static Tween<Vector3> TweenRelativeLocalPosition(this Transform trans, Vector3 start, Vector3 end, float duration)
        {
            var id = $"{trans.GetInstanceID()}_RelativeLocalPosition";

            // Adjust the end position to be relative to the starting position
            var adjustedEnd = start + end;

            var tween = new Tween<Vector3>(trans, id, start, adjustedEnd, duration, value => { trans.localPosition = value; });

            return tween;
        }


        public static Tween<Vector3> TweenRelativeLocalPosition(this Transform trans, Vector3 end, float duration)
        {
            return TweenRelativeLocalPosition(trans, trans.localPosition, end, duration);
        }


        public static Tween<Vector3> TweenRelativeLocalPosition(this Transform trans, float end, float duration)
        {
            var endValue = new Vector3(end, end, end);

            return TweenRelativeLocalPosition(trans, trans.localPosition, endValue, duration);
        }


        public static Tween<Quaternion> TweenRotation(this Transform trans, Quaternion start, Quaternion end, float duration)
        {
            var id = $"{trans.GetInstanceID()}_Rotation";

            var tween = new Tween<Quaternion>(trans, id, start, end, duration, value => { trans.rotation = value; });

            return tween;
        }


        public static Tween<Quaternion> TweenRotation(this Transform trans, Quaternion end, float duration)
        {
            return TweenRotation(trans, trans.rotation, end, duration);
        }


        public static Tween<Quaternion> TweenLocalRotation(this Transform trans, Quaternion start, Quaternion end, float duration)
        {
            var id = $"{trans.GetInstanceID()}_LocalRotation";

            var tween = new Tween<Quaternion>(trans, id, start, end, duration, value => { trans.localRotation = value; });

            return tween;
        }


        public static Tween<Quaternion> TweenLocalRotation(this Transform trans, Quaternion end, float duration)
        {
            return TweenLocalRotation(trans, trans.localRotation, end, duration);
        }


        public static Tween<Quaternion> TweenLocalRotation(this Transform trans, Vector3 end, float duration)
        {
            var endValue = Quaternion.Euler(end);

            return TweenLocalRotation(trans, trans.localRotation, endValue, duration);
        }
    }


    public static class TweenExtensionsRenderers
    {
        public static Tween<float> TweenAlpha(this SpriteRenderer spriteRenderer, float startAlpha, float endAlpha, float duration)
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


        public static Tween<float> TweenAlpha(this SpriteRenderer spriteRenderer, float endAlpha, float duration)
        {
            return TweenAlpha(spriteRenderer, spriteRenderer.color.a, endAlpha, duration);
        }


        public static Tween<float> TweenAlpha(this CanvasRenderer canvasRenderer, float startAlpha, float endAlpha, float duration)
        {
            var id = $"{canvasRenderer.GetInstanceID()}_Alpha";

            var tween = new Tween<float>(canvasRenderer, id, startAlpha, endAlpha, duration, value => { canvasRenderer.SetAlpha(value); });

            return tween;
        }


        public static Tween<float> TweenAlpha(this CanvasRenderer canvasRenderer, float endAlpha, float duration)
        {
            return TweenAlpha(canvasRenderer, canvasRenderer.GetAlpha(), endAlpha, duration);
        }


        public static Tween<float> TweenAlpha(this Material material, float startAlpha, float endAlpha, float duration)
        {
            var id = $"{material.GetInstanceID()}_Alpha";

            var tween = new Tween<float>(material, id, startAlpha, endAlpha, duration, value =>
            {
                if (material.HasProperty("_Color"))
                {
                    var color = material.color;
                    color.a = value;
                    material.color = color;
                }
            });

            return tween;
        }


        public static Tween<float> TweenAlpha(this Material material, float endAlpha, float duration)
        {
            var startAlpha = material.HasProperty("_Color") ? material.color.a : 1.0f;

            return TweenAlpha(material, startAlpha, endAlpha, duration);
        }


        public static Tween<float> TweenEmission(this Material material, Color startColor, Color endColor, float duration)
        {
            var id = $"{material.GetInstanceID()}_Emission";

            var tween = new Tween<float>(material, id, startColor.r, endColor.r, duration, value =>
            {
                if (material.HasProperty("_EmissionColor"))
                {
                    var color = material.GetColor("_EmissionColor");
                    color.r = value;
                    material.SetColor("_EmissionColor", color);
                }
            });

            return tween;
        }


        public static Tween<float> TweenEmission(this Material material, Color endColor, float duration)
        {
            var startColor = material.HasProperty("_EmissionColor") ? material.GetColor("_EmissionColor") : Color.black;

            return TweenEmission(material, startColor, endColor, duration);
        }
    }
}