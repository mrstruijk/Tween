using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace SOSXR.Tweening
{
    /// <summary>
    ///     From Sasquatch B Studio Tutorial: https://www.youtube.com/watch?v=43o0FzU55V4
    /// </summary>
    public class TweenManager : MonoBehaviour
    {
        private readonly Dictionary<string, ITween> _activeTweens = new();

        private static TweenManager _instance;

        public static TweenManager Instance
        {
            get
            {
                if (!Application.isPlaying)
                {
                    return null;
                }

                if (_instance == null)
                {
                    var manager = new GameObject("TweenManager_Instance");
                    _instance = manager.AddComponent<TweenManager>();

                    DontDestroyOnLoad(manager); // Not sure if this will work properly.
                }

                return _instance;
            }
        }


        public void AddTween<T>(ITween tween)
        {
            if (_activeTweens.TryGetValue(tween.Identifier, out var activeTween))
            {
                Debug.LogFormat(tween.Target as GameObject, "We are redoing an identical tween again before the previous one is completed. Is that intentional?");

                activeTween.OnCompleteKill();
            }

            _activeTweens[tween.Identifier] = tween;
        }


        private void Update()
        {
            var dictionaryAsList = _activeTweens.ToList(); // We're taking a snapshot of the dictionary while we're iterating through it. This way we don't really delete some item from the dictionary while iterating, thus preventing some errors.

            foreach (var (key, tween) in dictionaryAsList)
            {
                tween.Update();

                if (tween.IsComplete && !tween.WasKilled) // The tween.onComplete is called from here because this shouldn't be called while removing items from the dictionary. If this were still called on the Update of the Tween itself, there was a risk of that happening.
                {
                    if (tween.OnComplete != null)
                    {
                        tween.OnComplete.Invoke();
                        tween.NullifyOnComplete();
                    }

                    RemoveTween(key);
                }

                if (tween.WasKilled)
                {
                    RemoveTween(key);
                }
            }
        }


        public void RemoveTween(string identifier)
        {
            if (!_activeTweens.ContainsKey(identifier))
            {
                Debug.LogFormat(this, $"We are trying to remove a tween with identifier {identifier} that doesn't exist.");

                return;
            }

            _activeTweens.Remove(identifier);
        }
    }
}