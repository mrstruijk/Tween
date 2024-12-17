using UnityEngine;


namespace SOSXR.Tweening
{
    /// <summary>
    ///     From ChatGPT
    /// </summary>
    public enum EasingType
    {
        Linear,
        EaseInQuad,
        EaseOutQuad,
        EaseInOutQuad,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic,
        EaseInQuart,
        EaseOutQuart,
        EaseInOutQuart,
        EaseInQuint,
        EaseOutQuint,
        EaseInOutQuint,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInExpo,
        EaseOutExpo,
        EaseInOutExpo,
        EaseInCirc,
        EaseOutCirc,
        EaseInOutCirc,
        EaseInElastic,
        EaseOutElastic,
        EaseInOutElastic,
        EaseInBack,
        EaseOutBack,
        EaseInOutBack,
        EaseInBounce,
        EaseOutBounce,
        EaseInOutBounce, 
        AnimationCurve  // Custom curve
    }


    /// <summary>
    ///     From ChatGPT
    /// </summary>
    public static class EasingEquations
    {
        public static float Linear(float t)
        {
            return t;
        }


        public static float EaseInQuad(float t)
        {
            return t * t;
        }


        public static float EaseOutQuad(float t)
        {
            return t * (2 - t);
        }


        public static float EaseInOutQuad(float t)
        {
            return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
        }


        public static float EaseInCubic(float t)
        {
            return t * t * t;
        }


        public static float EaseOutCubic(float t)
        {
            return --t * t * t + 1;
        }


        public static float EaseInOutCubic(float t)
        {
            return t < 0.5f ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
        }


        public static float EaseInQuart(float t)
        {
            return t * t * t * t;
        }


        public static float EaseOutQuart(float t)
        {
            return 1 - --t * t * t * t;
        }


        public static float EaseInOutQuart(float t)
        {
            return t < 0.5f ? 8 * t * t * t * t : 1 - 8 * --t * t * t * t;
        }


        public static float EaseInQuint(float t)
        {
            return t * t * t * t * t;
        }


        public static float EaseOutQuint(float t)
        {
            return 1 + --t * t * t * t * t;
        }


        public static float EaseInOutQuint(float t)
        {
            return t < 0.5f ? 16 * t * t * t * t * t : 1 + 16 * --t * t * t * t * t;
        }


        public static float EaseInSine(float t)
        {
            return 1 - Mathf.Cos(t * Mathf.PI * 0.5f);
        }


        public static float EaseOutSine(float t)
        {
            return Mathf.Sin(t * Mathf.PI * 0.5f);
        }


        public static float EaseInOutSine(float t)
        {
            return -0.5f * (Mathf.Cos(Mathf.PI * t) - 1);
        }


        public static float EaseInExpo(float t)
        {
            return t == 0 ? 0 : Mathf.Pow(2, 10 * (t - 1));
        }


        public static float EaseOutExpo(float t)
        {
            return Mathf.Approximately(t, 1) ? 1 : 1 - Mathf.Pow(2, -10 * t);
        }


        public static float EaseInOutExpo(float t)
        {
            return t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : t < 0.5f ? Mathf.Pow(2, 10 * (2 * t - 1)) * 0.5f : (2 - Mathf.Pow(2, -10 * (2 * t - 1))) * 0.5f;
        }


        public static float EaseInCirc(float t)
        {
            return 1 - Mathf.Sqrt(1 - t * t);
        }


        public static float EaseOutCirc(float t)
        {
            return Mathf.Sqrt(1 - --t * t);
        }


        public static float EaseInOutCirc(float t)
        {
            return t < 0.5f ? (1 - Mathf.Sqrt(1 - 4 * t * t)) * 0.5f : (Mathf.Sqrt(1 - --t * (2 * t - 2)) + 1) * 0.5f;
        }


        public static float EaseInElastic(float t)
        {
            return t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : -Mathf.Pow(2, 10 * (t - 1)) * Mathf.Sin((t - 1.1f) * 5 * Mathf.PI);
        }


        public static float EaseOutElastic(float t)
        {
            return t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t - 0.1f) * 5 * Mathf.PI) + 1;
        }


        public static float EaseInOutElastic(float t)
        {
            return t == 0
                ? 0
                : Mathf.Approximately(t, 1)
                    ? 1
                    : t < 0.5f
                        ? -0.5f * Mathf.Pow(2, 10 * (2 * t - 1)) * Mathf.Sin((2 * t - 1.1f) * 5 * Mathf.PI)
                        : 0.5f * Mathf.Pow(2, -10 * (2 * t - 1)) * Mathf.Sin((2 * t - 1.1f) * 5 * Mathf.PI) + 1;
        }


        public static float EaseInBack(float t)
        {
            return t * t * (2.70158f * t - 1.70158f);
        }


        public static float EaseOutBack(float t)
        {
            return 1 + --t * t * (2.70158f * t + 1.70158f);
        }


        public static float EaseInOutBack(float t)
        {
            return t < 0.5f
                ? t * t * (7 * t - 2.5f) * 2
                : 1 + --t * t * (7 * t + 2.5f) * 2;
        }


        public static float EaseInBounce(float t)
        {
            return 1 - EaseOutBounce(1 - t);
        }


        public static float EaseOutBounce(float t)
        {
            if (t < 1 / 2.75f)
            {
                return 7.5625f * t * t;
            }

            if (t < 2 / 2.75f)
            {
                return 7.5625f * (t -= 1.5f / 2.75f) * t + 0.75f;
            }

            if (t < 2.5f / 2.75f)
            {
                return 7.5625f * (t -= 2.25f / 2.75f) * t + 0.9375f;
            }

            return 7.5625f * (t -= 2.625f / 2.75f) * t + 0.984375f;
        }


        public static float EaseInOutBounce(float t)
        {
            return t < 0.5f ? EaseInBounce(t * 2) * 0.5f : EaseOutBounce(t * 2 - 1) * 0.5f + 0.5f;
        }
    }
}