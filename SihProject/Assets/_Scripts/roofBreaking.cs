using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofBreaking : MonoBehaviour
{
    public float waitForSecs;
    public float dropForSecs;
    public List<GameObject> rocks;
    public float xRandomizer;
    public float zRandomizer;
    public float sizeRandomizer;
    public float interval;
    float lifeTime;
    Player player;
    System.Random random;
    float tempTime;
    

    private void Start()
    {
        player = FindObjectOfType<Player>();
        random = new System.Random();
        float randomFloat = (float)random.NextDouble() * player.timeRadomize;
        lifeTime = player.timeTillDisaster + randomFloat + waitForSecs;
        tempTime = interval;
    }

    private void FixedUpdate()
    {
        if (lifeTime < 0)
        {
            if (dropForSecs > 0)
            {
                tempTime -= Time.deltaTime;
                if (tempTime < 0)
                {
                    float x = (float)(random.NextDouble() * (2 * xRandomizer) - xRandomizer);
                    float z = (float)(random.NextDouble() * (2 * zRandomizer) - zRandomizer);
                    int randomIndex = random.Next(0, rocks.Count);
                    GameObject rock = rocks[randomIndex];
                    rock.transform.localScale = Vector3.one * ((float)(random.NextDouble() * (sizeRandomizer - 1) + 1));
                    Instantiate(rock, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), Quaternion.identity);
                    tempTime = interval;
                }
            }
            dropForSecs -= Time.deltaTime;
        }
        else lifeTime -= Time.deltaTime;
    }

}
