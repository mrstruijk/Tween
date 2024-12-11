using TMPro;
using UnityEngine;


public class DemoFloatTweenTwo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_textField;

    public float FloatToTween;

    [SerializeField] private float _floatValue;


    [ContextMenu(nameof(TestFloatDown))]
    private void TestFloatDown()
    {
        TweenManager.TweenFloat(() => _floatValue, value => _floatValue = value, 0, 5).OnUpdate(SetFloatValue);
    }


    private void SetFloatValue()
    {
        FloatToTween = _floatValue;

        if (m_textField != null)
        {
            m_textField.text = FloatToTween.ToString();
        }
    }


    [ContextMenu(nameof(TestFloatUp))]
    private void TestFloatUp()
    {
        TweenManager.TweenFloat(() => _floatValue, value => _floatValue = value, 10, 5).OnUpdate(SetFloatValue);
    }
}