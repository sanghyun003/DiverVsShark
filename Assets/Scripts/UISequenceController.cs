using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISequenceController : MonoBehaviour
{
    [Header("Logo Settings")]
    public Transform logo;
    public float logoDuration = 0.5f;

    [Header("Button Settings")]
    public Button[] buttons;
    public float buttonDuration = 0.3f;
    public float buttonDelay = 0.2f;

    void Start()
    {
        // 처음에는 로고와 버튼을 작게 설정
        logo.localScale = Vector3.zero;
        foreach (var btn in buttons)
            btn.transform.localScale = Vector3.zero;

        StartCoroutine(PlayUISequence());
    }

    IEnumerator PlayUISequence()
    {

        // 2️⃣ 버튼 순차 커지는 애니메이션
        foreach (var btn in buttons)
        {
            yield return StartCoroutine(ScaleUp(btn.transform, Vector3.one, buttonDuration));
            yield return new WaitForSeconds(buttonDelay);
        }
    }

    IEnumerator ScaleUp(Transform target, Vector3 targetScale, float duration)
    {
        Vector3 startScale = target.localScale;
        float time = 0f;

        while (time < duration)
        {
            target.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        target.localScale = targetScale; // 끝 값을 정확히 맞춤
    }
}
