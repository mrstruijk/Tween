using UnityEngine;


public class DemoScaleTween : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] private float m_scaler;
    
    
    [ContextMenu(nameof(TestScaleUpDirect))]
    private void TestScaleUpDirect()
    {
        transform.TweenScale(transform.localScale, transform.localScale * m_scaler, 4).WithEase(EasingType.EaseInOutBounce);
    }
    
    [ContextMenu(nameof(TestScaleDownFromHere))]
    private void TestScaleDownFromHere()
    {
        transform.TweenScale(transform.localScale / m_scaler, 2).WithEase(EasingType.EaseOutElastic);
    }
}