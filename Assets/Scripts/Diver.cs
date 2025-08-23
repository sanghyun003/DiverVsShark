using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Diver : MonoBehaviour
{
    [SerializeField] private float diverSpeed = 1f;
    [SerializeField] private int diverMaxHp = 3;
    private int diverCurrentHp;

    private PlayerHeartUI heartUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diverCurrentHp = diverMaxHp;
        heartUI = FindAnyObjectByType<PlayerHeartUI>();
        heartUI.SetMaxHeart(diverMaxHp);
        heartUI.UpdateHeart(diverCurrentHp);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveTo = new Vector3(horizontal, vertical, 0f);
        transform.position += moveTo * diverSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            Destroy(collision.gameObject);
            
            diverCurrentHp -= 1;
            diverCurrentHp = Mathf.Max(diverCurrentHp, 0); // 0 이하 방지

            heartUI.UpdateHeart(diverCurrentHp);

            if (diverCurrentHp <= 0)
            {
                Destroy(gameObject);
                Debug.Log("GameOver");
                GameOverUI.instance.SetGameOver();
            }
            else
            {
                Debug.Log("Hp--");
            }
        }
    }

    public void UpgradeHp(int amount)
    {
        diverMaxHp += amount;
        diverCurrentHp += amount; // 같이 늘려도 됨
        heartUI.SetMaxHeart(diverMaxHp);
        heartUI.UpdateHeart(diverCurrentHp);
    }
}
