using UnityEngine;


public class DemoSpriteTween : MonoBehaviour
{
    [ContextMenu(nameof(TestAlphaFadeOut))]
    private void TestAlphaFadeOut()
    {
        TweenManager.TweenSpriteAlpha(gameObject, 1, 0, 4);
    }


    [ContextMenu(nameof(TestAlphaFadeIn))]
    private void TestAlphaFadeIn()
    {
        TweenManager.TweenSpriteAlpha(gameObject, 0, 1, 4);
    }
}