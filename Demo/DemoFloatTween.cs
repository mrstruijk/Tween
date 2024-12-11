using TMPro;
using UnityEngine;


/// <summary>
/// With help from Claude
/// </summary>
public class DemoFloatTween : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_textField;
    
    public float FloatToTween;


    [ContextMenu(nameof(TestFloatDown))]
    private void TestFloatDown()
    {
        TweenManager.TweenFloat(
            () => FloatToTween,
            value => { FloatToTween = value; },
            0,
            5
        ).OnUpdate(SetText);
    }


    private void SetText()
    {
        if (m_textField != null)
        {
            m_textField.text = FloatToTween.ToString();
        }
    }


    [ContextMenu(nameof(TestFloatUp))]
    private void TestFloatUp()
    {
        TweenManager.TweenFloat(
            () => FloatToTween,
            value => { FloatToTween = value; },
            10,
            5
        ).OnUpdate(SetText);
    }
}