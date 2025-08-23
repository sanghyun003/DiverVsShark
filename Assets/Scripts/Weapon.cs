using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject weaponPrefab; // 휘두를 무기
    [SerializeField] private Transform handPosition;  // 무기가 나타날 위치
    [SerializeField] private float swingDuration = 0.5f; // 휘두르는 시간
    [SerializeField] private float swingAngle = 90f;     // 휘두르는 총 각도
    [SerializeField] private float baseAngle = 0f;       // 휘두르는 중심 각도 (0° = 오른쪽)

    private GameObject currentWeapon;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwingWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwingWeapon();
        }
    }

    void SwingWeapon()
    {
        if (currentWeapon != null) return;

        // 무기 생성
        currentWeapon = Instantiate(weaponPrefab, handPosition.position, Quaternion.Euler(0, 0, baseAngle - swingAngle / 2), handPosition);

        // Coroutine으로 휘두르기
        StartCoroutine(SwingAndDestroy());
    }

    IEnumerator SwingAndDestroy()
    {
        float elapsed = 0f;
        float startAngle = baseAngle;
        float endAngle = baseAngle - swingAngle;

        while (elapsed < swingDuration)
        {
            elapsed += Time.deltaTime;
            float angle = Mathf.Lerp(startAngle, endAngle, elapsed / swingDuration);
            currentWeapon.transform.localRotation = Quaternion.Euler(0, 0, angle);
            yield return null;
        }

        Destroy(currentWeapon);
        currentWeapon = null;
    }
}
