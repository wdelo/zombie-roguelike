using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private bool fullAuto;
    [SerializeField] private float rpm = 260;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private int damage = 24;
    [SerializeField] private int ammoSize = 12;
    [SerializeField] private int maxAmmoReserves = 24;
    [SerializeField] private float reloadSpeed = 1.2f;

    private int currentAmmo;
    private int ammoReserves;
    private float secondsToWait;
    private bool canShoot = true;
    private bool isShooting = false;
    private bool isReloading = false;

    private void Awake()
    {
        secondsToWait = 1.0f / (rpm / 60.0f);
        currentAmmo = ammoSize;
        ammoReserves = maxAmmoReserves;
    }

    private void Shoot()
    {
        // play sound
        //Debug.Log("Bang!");
        Debug.Log(currentAmmo-1 + "/" + ammoSize);

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
                Debug.Log("Hit enemy!");
            }
        }
        //Debug.DrawRay(transform.parent.position, transform.parent.forward * range, Color.red, 1.0f);

    }

    private void Reload()
    {
        int ammoLeft = ammoReserves - ammoSize;
        if (ammoLeft < 0)
        {
            currentAmmo = ammoReserves;
            ammoReserves = 0;
        }
        else
        {
            ammoReserves -= ammoSize;
            currentAmmo = ammoSize;

        }
    }

    private IEnumerator ShootFullAuto()
    {
        while (isShooting)
        {
            yield return ShootCoroutine();
        }
    }

    private IEnumerator ShootCoroutine()
    {
        canShoot = false;
        Shoot();
        currentAmmo--;
        yield return new WaitForSeconds(secondsToWait);
        canShoot = true;
        if (currentAmmo <= 0)
        {
            canShoot = false;
            isShooting = false;
        } 
    }

    private IEnumerator ReloadCoroutine()
    {
        canShoot = false;
        isReloading = true;
        yield return new WaitForSeconds(reloadSpeed);
        Reload();
        Debug.Log("Reload complete");
        isReloading = false;
        canShoot = true;
    }

    public void StartShooting()
    {
        if (canShoot && !isReloading)
        {
            isShooting = true;
            if (fullAuto) 
                StartCoroutine("ShootFullAuto");   
            else
                StartCoroutine("ShootCoroutine");          
        }
    }

    public void StopShooting()
    {
        isShooting = false; 
    }


    public void StartReloading()
    {
        if (!isReloading && currentAmmo < ammoSize && ammoReserves > 0)
        {
            isShooting = false;
            Debug.Log("Reloading...");
            StartCoroutine("ReloadCoroutine"); 
        }
    }

}
