using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LogoManager : MonoBehaviour
{

 public Image logoImage;
    public float fadeDuration = 2.0f;
    public string nextSceneName = "game";

    private void Start()
    {
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // 페이드 인
        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            Color newColor = logoImage.color;
            newColor.a = t / fadeDuration;
            logoImage.color = newColor;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        // 페이드 아웃
        for (float t = fadeDuration; t > 0.0f; t -= Time.deltaTime)
        {
            Color newColor = logoImage.color;
            newColor.a = t / fadeDuration;
            logoImage.color = newColor;
            yield return null;
        }

        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }


}
