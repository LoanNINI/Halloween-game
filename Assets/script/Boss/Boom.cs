using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float TimeDeploy = 3.5f;
    public GameObject Circle;
    public GameObject ParticleEffect;
    
    void Start()
    {
        StartCoroutine(TimeCount());
    }
    IEnumerator TimeCount ()
    {
        for (float i = .1f; i <TimeDeploy; i += .1f)
        {
            yield return new WaitForSeconds(.1f);
        }
        Circle.GetComponent<SpriteRenderer>().enabled = false;
        ParticleEffect.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
