using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private bool fullAuto;
    [SerializeField] private float rpm;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private int damage = 50;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int ammoSize;
    [SerializeField] private int ammoReserves;

    private float secondsToWait;
    private bool canShoot = true;
    private bool shooting = false;

    private void Awake()
    {
        secondsToWait = 1.0f / rpm / 60.0f;
    }

    private void Shoot()
    {
        // play sound
        Debug.Log("Bang!");

        // spawn muzzle flash particle effect

        // perform raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, range))
        {
            Vector3 hitPoint = hit.point; 
            if (hit.collider.tag != null && hit.collider.CompareTag("Enemy"))
            {
                // play hit sound

                // spawn blood particle effect
                
                // decrease health
                hit.collider.gameObject.GetComponent<Health>().DecreaseHealth(damage);

            }
        }
        Debug.DrawRay(transform.parent.position, transform.parent.forward * range, Color.red, 1.0f);

    }
    private IEnumerator ShootCoroutine()
    {
        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(secondsToWait);
        canShoot = true;
    }

    private IEnumerator ShootFullAuto()
    {
        while (shooting)
        {
            yield return ShootCoroutine();
        }
    }

    public void StartShooting()
    {
        if (canShoot)
        {
            shooting = true;
            if (fullAuto) 
                StartCoroutine("ShootFullAuto");   
            else
                StartCoroutine("ShootCoroutine");          
        }
    }

    public void StopShooting()
    {
        shooting = false; 
    }

}
