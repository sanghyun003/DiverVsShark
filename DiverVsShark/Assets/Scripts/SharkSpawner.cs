using System;
using System.Numerics;
using Unity.Collections;
using UnityEngine;

using Vec3 = UnityEngine.Vector3;
using Rand = UnityEngine.Random;
using System.Collections;
public class SharkSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Camera cam;
    private Vec3 bottomLeft;
    private Vec3 topRight;
    public static float minX, minY, maxX, maxY;
    void Start()
    {
        if (cam == null) cam = Camera.main;

        bottomLeft = cam.ViewportToWorldPoint(new Vec3(0, 0, 0));
        topRight = cam.ViewportToWorldPoint(new Vec3(1, 1, 0));

        StartSpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        while (player != null)
        {
            yield return new WaitForSeconds(2f);
            Vec3 spawnPos = GetSpawnPosition();
            int index = Rand.Range(0, enemies.Length);
            Instantiate(enemies[index], spawnPos, UnityEngine.Quaternion.identity);
        }
    }
    public void StartSpawnEnemies()
    {
        StartCoroutine("SpawnEnemies");
    }
    public void StopSpawnEnemies()
    {
        StopCoroutine("SpawnEnemies");
    }
    private Vec3 GetSpawnPosition()
    {
        float offset = 2f;
        minX = bottomLeft.x - offset;
        minY = bottomLeft.y - offset;
        maxX = topRight.x + offset;
        maxY = topRight.y + offset;
        float x = 0;
        float y = 0;

        int side = Rand.Range(0, 4);
        //아래
        if (side == 0)
        {
            x = Rand.Range(minX, maxX);
            y = minY;
        }//오른쪽
        else if (side == 1)
        {
            x = maxX;
            y = Rand.Range(minY, maxY);
        }//위
        else if (side == 2)
        {
            x = Rand.Range(minX, maxX);
            y = maxY;
        }//왼쪽
        else if (side == 3)
        {
            x = minX;
            y = Rand.Range(minY, maxY);
        }
        return new Vec3(x, y, 0f);

    }

}
