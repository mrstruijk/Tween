using UnityEngine;


public class DemoScaleTween : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] private float m_scaler;
   
    [ContextMenu(nameof(TestScaleDown))]
    private void TestScaleDown()
    {
        TweenManager.TweenScale(gameObject, gameObject.transform.localScale, gameObject.transform.localScale / m_scaler, 4).SetEase(EasingType.EaseInBounce);
    }
   
    [ContextMenu(nameof(TestScaleUp))]
    private void TestScaleUp()
    {
        TweenManager.TweenScale(gameObject, gameObject.transform.localScale, gameObject.transform.localScale * m_scaler, 4).SetEase(EasingType.EaseInCubic);
    }
}