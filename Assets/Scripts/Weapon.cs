using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    public GameObject tip;

    public float fireRate;

    public float bulletForce;

    /// <summary>
    /// Allow the destruction of a bullet after a certain delay.
    /// </summary>
    /// <param name="bullet"> bullet object to destroy</param>
    /// <param name="delay"> delay after which the bullet object will be destroyed</param>
    /// <returns></returns>
    private IEnumerator destroy(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    /// <summary>
    /// Allow the destruction of a bullet after a certain delay.
    /// </summary>
    /// <param name="bullet"> bullet object to destroy</param>
    /// <param name="delay"> delay after which the bullet object will be destroyed</param>
    /// <returns></returns>
    public void destroyBullet(GameObject bullet, float delay)
    {
        StartCoroutine(destroy(bullet, delay));
    }

}
