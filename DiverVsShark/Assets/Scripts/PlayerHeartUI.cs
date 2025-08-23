using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHeartUI : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab; // 하트 Prefab
    [SerializeField] private Transform heartContainer; // 하트 부모
    private List<Image> heartFills = new List<Image>();

    private int maxHp;

    // 현재 체력 최대치에 맞춰 하트 추가
    public void SetMaxHeart(int maxHp)
    {
        this.maxHp = maxHp;

        // 기존 하트 제거
        foreach (Transform child in heartContainer)
            Destroy(child.gameObject);
        heartFills.Clear();

        // 기존 하트보다 maxHp가 많으면 부족한 만큼 추가
        for (int i = 0; i < maxHp; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            Image fill = heart.transform.Find("HeartFilled").GetComponent<Image>();
            heartFills.Add(fill);
        }
    }

    // 체력 변화 반영
    public void UpdateHeart(int currentHp)
    {
        for (int i = 0; i < heartFills.Count; i++)
        {
            heartFills[i].enabled = i < currentHp;
        }
    }
}
