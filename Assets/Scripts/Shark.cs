using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] private float sharkSpeed = 5f;
    [SerializeField] private GameObject coin;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * sharkSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < SharkSpawner.minX ||
            transform.position.x > SharkSpawner.maxX ||
            transform.position.y < SharkSpawner.minY ||
            transform.position.y > SharkSpawner.maxY)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);
            Debug.Log("Kill Shark");
            GameManager.instance.IncreaseScore();
        }
    } 
}
