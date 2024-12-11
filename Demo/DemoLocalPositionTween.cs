using UnityEngine;


namespace SOSXR.Tweening.Demo
{
    public class DemoLocalPositionTween : MonoBehaviour
    {
        [SerializeField] private Vector3 m_endPositionOne = new(3, -2, 0);
        [SerializeField] private Vector3 m_endPositionTwo = new(-3, 2, 2);


        [ContextMenu(nameof(GoToPositionOne))]
        private void GoToPositionOne()
        {
            transform.TweenLocalPosition(m_endPositionOne, 5).WithEase(EasingType.EaseInOutBounce);
        }


        [ContextMenu(nameof(GoToPositionTwo))]
        private void GoToPositionTwo()
        {
            transform.TweenLocalPosition(m_endPositionTwo, 3);
        }
    }
}