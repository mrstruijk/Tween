using UnityEngine;


namespace SOSXR.Tweening.Demo
{
    public class DemoRelativeLocalPositionTween : MonoBehaviour
    {
        [SerializeField] private Vector3 m_endPositionOne = new(5, -1, 1);
        [SerializeField] private Vector3 m_endPositionTwo = new(-8, -2, 2);

        [Header("Read Only")]
        [SerializeField] private Vector3 _startPosition;


        private void Awake()
        {
            _startPosition = transform.localPosition;
        }


        [ContextMenu(nameof(GoToPositionOne))]
        private void GoToPositionOne()
        {
            transform.TweenRelativeLocalPosition(_startPosition, m_endPositionOne, 2.5f).WithEase(EasingType.Linear);
        }


        [ContextMenu(nameof(GoToPositionTwo))]
        private void GoToPositionTwo()
        {
            transform.TweenRelativeLocalPosition(_startPosition, m_endPositionTwo, 3).WithEase(EasingType.EaseInSine);
        }


        [ContextMenu(nameof(GoBackToStart))]
        private void GoBackToStart()
        {
            transform.TweenLocalPosition(transform.localPosition, _startPosition, 2).WithEase(EasingType.EaseOutSine);
        }
    }
}