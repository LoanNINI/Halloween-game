using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkObject : MonoBehaviour
{
    public Image targetImage;            // Drag your Image component here
    public float fadeDuration = 1f;      // Time it takes to fade in and out
    public float minAlpha = 0f;          // Minimum alpha value (0 = fully transparent)
    public float maxAlpha = 1f;          // Maximum alpha value (1 = fully opaque)

    private void Start()
    {
        if (targetImage != null)
        {
            StartCoroutine(FadeBlink());
        }
    }

    IEnumerator FadeBlink()
    {
        while (true)
        {
            // Fade in (increase alpha)
            yield return StartCoroutine(FadeToAlpha(maxAlpha));

            // Fade out (decrease alpha)
            yield return StartCoroutine(FadeToAlpha(minAlpha));
        }
    }

    IEnumerator FadeToAlpha(float targetAlpha)
    {
        float startAlpha = targetImage.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(targetAlpha); // Ensure it reaches the target alpha exactly
    }

    private void SetAlpha(float alpha)
    {
        Color color = targetImage.color;
        color.a = alpha;
        targetImage.color = color;
    }
}
