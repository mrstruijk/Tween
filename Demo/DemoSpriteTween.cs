using UnityEngine;


public class DemoSpriteTween : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_spriteRenderer;


    [ContextMenu(nameof(TestAlphaFadeOut))]
    private void TestAlphaFadeOut()
    {
        m_spriteRenderer.Tween(0, 4);
    }


    [ContextMenu(nameof(TestAlphaFadeIn))]
    private void TestAlphaFadeIn()
    {
        m_spriteRenderer.Tween(1, 4);
    }
}