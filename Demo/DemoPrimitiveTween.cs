using TMPro;
using UnityEngine;


namespace SOSXR.Tweening.Demo
{
    /// <summary>
    ///     With help from Claude
    /// </summary>
    public class DemoPrimitiveTween : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_textField;

        public float Float;
        public Vector2 Vector2;
        public Vector3 Vector3;
        public Quaternion Quaternion;


        [ContextMenu(nameof(TestFloatDown))]
        private void TestFloatDown()
        {
            Float.Tween(value => { Float = value; }, 0, 5).OnUpdate(SetText).WithEase(EasingType.EaseInCirc);
        }


        [ContextMenu(nameof(TestFloatUp))]
        private void TestFloatUp()
        {
            Float.Tween(value => { Float = value; }, 10, 5).OnUpdate(SetText).WithEase(EasingType.EaseOutCirc);
        }


        [ContextMenu(nameof(TestVector2Down))]
        private void TestVector2Down()
        {
            Vector2.Tween(value => { Vector2 = value; }, Vector2.zero, 5).OnUpdate(SetText).WithEase(EasingType.EaseInSine);
        }


        [ContextMenu(nameof(TestVector2Up))]
        private void TestVector2Up()
        {
            Vector2.Tween(value => { Vector2 = value; }, Vector2.one * 10, 5).OnUpdate(SetText).WithEase(EasingType.EaseOutSine);
        }


        [ContextMenu(nameof(TestVector3Down))]
        private void TestVector3Down()
        {
            Vector3.Tween(value => { Vector3 = value; }, Vector3.zero, 5).OnUpdate(SetText);
        }


        [ContextMenu(nameof(TestVector3Up))]
        private void TestVector3Up()
        {
            Vector3.Tween(value => { Vector3 = value; }, Vector3.one * 10, 5).OnUpdate(SetText);
        }


        [ContextMenu(nameof(TestQuaternionDown))]
        private void TestQuaternionDown()
        {
            Quaternion.Tween(value => { Quaternion = value; }, Quaternion.identity, 5).OnUpdate(SetText).WithEase(EasingType.EaseOutQuart);
        }


        [ContextMenu(nameof(TestQuaternionUp))]
        private void TestQuaternionUp()
        {
            Quaternion.Tween(value => { Quaternion = value; }, Quaternion.Euler(0, 0, 90), 5).OnUpdate(SetText).WithEase(EasingType.EaseInQuart);
        }


        private void SetText()
        {
            if (m_textField == null)
            {
                return;
            }

            m_textField.text = Float + " " + Vector2 + " " + Vector3 + " " + Quaternion;
        }
    }
}