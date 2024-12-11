using UnityEngine;


namespace SOSXR.Tweening.Demo
{
    public class DemoPositionTween : MonoBehaviour
    {
        [SerializeField] private Vector3 m_endPositionOne = new(3, -2, 0);
        [SerializeField] private Vector3 m_endPositionTwo = new(-3, 0, 2);


        [ContextMenu(nameof(GoToPositionOne))]
        private void GoToPositionOne()
        {
            transform.TweenPosition(m_endPositionOne, 4).WithEase(EasingType.EaseInOutExpo);
        }


        [ContextMenu(nameof(GoToPositionTwo))]
        private void GoToPositionTwo()
        {
            transform.TweenPosition(m_endPositionTwo, 2);
        }
    }
}