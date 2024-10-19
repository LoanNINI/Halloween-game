using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    public Light2D Lighting;
    public float Oil = 100;


    bool Off_On = false;
    bool Db_Oil = false;
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Off_On = !Off_On;
        }
        Lighting.enabled = Off_On;

        if (Oil <= 0)
        {
            Off_On = false;
            Lighting.enabled = false;
        }

        if (Db_Oil == false && Off_On == true)
        {
            StartCoroutine(Oil_Decread());
        }
    }

    IEnumerator Oil_Decread ()
    {
        Db_Oil = true;
        Oil -= 1f;
        yield return new WaitForSeconds(1);
        Db_Oil = false;
    }

}
