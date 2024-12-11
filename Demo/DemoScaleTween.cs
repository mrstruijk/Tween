using UnityEngine;


namespace SOSXR.Tweening.Demo
{
    public class DemoScaleTween : MonoBehaviour
    {
        [Range(0f, 10f)] [SerializeField] private float m_endScale;


        [ContextMenu(nameof(From10ToEndScale))]
        private void From10ToEndScale()
        {
            transform.TweenScale(10, m_endScale, 4).WithEase(EasingType.EaseInOutBounce);
        }


        [ContextMenu(nameof(TestScaleDownFromHere))]
        private void TestScaleDownFromHere()
        {
            if (m_endScale == 0)
            {
                Debug.LogError("Cannot divide by zero");

                return;
            }

            transform.TweenScale(transform.localScale / m_endScale, 2).WithEase(EasingType.EaseOutElastic);
        }
    }
}