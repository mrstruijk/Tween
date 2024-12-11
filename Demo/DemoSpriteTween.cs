using UnityEngine;


namespace SOSXR.Tweening.Demo
{
    public class DemoSpriteTween : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer m_spriteRenderer;


        [ContextMenu(nameof(TestAlphaFadeOut))]
        private void TestAlphaFadeOut()
        {
            m_spriteRenderer.TweenAlpha(0, 4);
        }


        [ContextMenu(nameof(TestAlphaFadeIn))]
        private void TestAlphaFadeIn()
        {
            m_spriteRenderer.TweenAlpha(1, 4);
        }
    }
}