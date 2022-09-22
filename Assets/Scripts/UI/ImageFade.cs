using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    private float fadeTime;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
        fadeTime = 1f;
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(FadeInOut));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1f, 0f));
            yield return StartCoroutine(Fade(0f, 1f));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float elapsed = 0;
        float percent = 0;

        while (percent < 1)
        {
            elapsed += Time.deltaTime;
            percent = elapsed / fadeTime;
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(start, end, percent);
            fadeImage.color = color;

            yield return null;
        }
    }
}
