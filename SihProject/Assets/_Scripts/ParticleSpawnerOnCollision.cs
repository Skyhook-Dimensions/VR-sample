using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawnerOnCollision : MonoBehaviour
{
    public GameObject particle;
    public float scaleDivider = 10;
    public float particleScale = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (FindObjectOfType<Player>().particlesOnCollision)
        {
            GameObject particleSystem = Instantiate(particle, collision.contacts[0].point, Quaternion.Euler(new Vector3(-90, 0, 0)));
            float scale = ((float)collision.contactCount) / scaleDivider;
            //particle.transform.localScale = new Vector3(scale, scale, scale);
            scale = particleScale;
            particle.transform.localScale = new Vector3(scale, scale, scale);
            particleSystem.GetComponent<ParticleSystem>().Play();
            StartCoroutine(destroyParticle(particleSystem));
        }
    }

    IEnumerator destroyParticle(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        Destroy(obj);
    }

}
