using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class FlickeringLights : MonoBehaviour
{
    public float maxInterval;
    int interval;
    float lifeTime;
    Player player;
    bool started;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        System.Random random = new System.Random();
        float randomFloat = (float)random.NextDouble() * player.timeRadomize;
        lifeTime = player.timeTillDisaster + randomFloat;
        started = false;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(!started && lifeTime<0)
        {
            StartCoroutine(FlickerLight());
            started = true;
        }
    }

    private IEnumerator FlickerLight()
    {
        while (true)
        {
            transform.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            transform.GetChild(0).GetComponent<Light>().enabled = false;

            float waitTime = UnityEngine.Random.Range(0, maxInterval);
            yield return new WaitForSeconds(waitTime);

            transform.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            transform.GetChild(0).GetComponent<Light>().enabled = true;

            waitTime = UnityEngine.Random.Range(0, maxInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
