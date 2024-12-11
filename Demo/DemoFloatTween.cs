using TMPro;
using UnityEngine;


public class DemoFloatTween : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_textField;

    public float FloatToTween;

    private float _floatValue;


    private float GetLerpValue()
    {
        return _floatValue;
    }


    private void SetLerpValue(float newValue)
    {
        _floatValue = newValue;
    }


    [ContextMenu(nameof(TestFloatDown))]
    private void TestFloatDown()
    {
        TweenManager.TweenFloat(GetLerpValue, SetLerpValue, 0, 5).SetOnUpdate(SetFloatValue);
    }


    private void SetFloatValue()
    {
        FloatToTween = GetLerpValue();

        if (m_textField != null)
        {
            m_textField.text = FloatToTween.ToString();
        }
    }


    [ContextMenu(nameof(TestFloatUp))]
    private void TestFloatUp()
    {
        TweenManager.TweenFloat(GetLerpValue, SetLerpValue, 10, 5).SetOnUpdate(SetFloatValue);
    }
}