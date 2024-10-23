using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;

    bool Firing = false;
    void Update()
    {
        Vector3 Mouseposition = Input.mousePosition;
        Mouseposition = Camera.main.ScreenToWorldPoint(Mouseposition);

        Vector2 direction = new Vector2(Mouseposition.x - transform.position.x, Mouseposition.y - transform.position.y);
        transform.up = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire ()
    {
        if (Firing == false)
        {
            StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        Firing = true;
        GameObject objbullet = Instantiate(Bullet, transform.parent.transform.parent);
        objbullet.transform.position = transform.position;
        objbullet.transform.rotation = transform.rotation;
        SoundAudioManager.soundAudioManager.Play_Sound("Fire", 4);
        yield return new WaitForSeconds(3);
        Firing = false;
    }
}
