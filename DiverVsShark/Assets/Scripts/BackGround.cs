using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float speedIncreaseRate = 0.02f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < -29f)
        {
            transform.position += new Vector3(51f, 0f);
        }
        moveSpeed += speedIncreaseRate * Time.deltaTime;
    }
}
