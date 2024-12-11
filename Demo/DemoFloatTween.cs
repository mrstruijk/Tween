using TMPro;
using UnityEngine;


/// <summary>
///     With help from Claude
/// </summary>
public class DemoFloatTween : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_textField;

    public float Float;


    [ContextMenu(nameof(TestFloatDown))]
    private void TestFloatDown()
    {
        Float.Tween(value => { Float = value; }, 0, 5).OnUpdate(SetText);
    }


    [ContextMenu(nameof(TestFloatUp))]
    private void TestFloatUp()
    {
        Float.Tween(value => { Float = value; }, 10, 5).OnUpdate(SetText);
    }


    private void SetText()
    {
        if (m_textField == null)
        {
            return;
        }

        m_textField.text = Float.ToString();
    }
}