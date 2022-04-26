using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lab6
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private bool fullAuto;
        [SerializeField] private float rpm = 260;
        [SerializeField] private float range = 10.0f;
        [SerializeField] private int damage = 24;
        [SerializeField] private int ammoSize = 12;
        [SerializeField] private int maxAmmoReserves = 24;
        [SerializeField] private float reloadSpeed = 1.2f;

        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private ParticleSystem bloodSplatter;
        [SerializeField] private AudioClip[] shotSounds;
        [SerializeField] private AudioClip reloadSound;

        private AudioSource audioSource;

        private int currentAmmo;
        private int ammoReserves;
        private float secondsToWait;
        private bool canShoot = true;
        private bool isShooting = false;
        private bool isReloading = false;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            secondsToWait = 1.0f / (rpm / 60.0f);
            currentAmmo = ammoSize;
            ammoReserves = maxAmmoReserves;
        }
        public int GetCurrentAmmo()
        {
            return currentAmmo;
        }
        public int GetAmmoSize()
        {
            return ammoSize;
        }
        public int GetAmmoReserves()
        {
            return ammoReserves;
        }

        public int GetMaxAmmoReserves()
        {
            return maxAmmoReserves;
        }

        public void AddAmmo(int amount)
        {
            ammoReserves += amount;

            if (ammoReserves >= maxAmmoReserves)
            {
                ammoReserves = maxAmmoReserves;
            }
        }

        private void Shoot()
        {
            // play sound
            audioSource.PlayOneShot(shotSounds[Random.Range(0, shotSounds.Length)]);
            Debug.Log(currentAmmo - 1 + "/" + ammoSize);

        // spawn muzzle flash particle effect
        muzzleFlash.Play();

        // perform raycast
        Debug.Log(transform.root.name);
        RaycastHit hit;
        if (Physics.Raycast(transform.root.position, transform.root.forward, out hit, range))
        {
            Vector3 hitPoint = hit.point; 
            if (hit.collider.tag != null && hit.collider.CompareTag("Enemy"))
            {
                // spawn blood particle effect
                ParticleSystem blood = Instantiate(bloodSplatter, hit.point + hit.normal, Quaternion.LookRotation(-hit.normal));
                blood.Play();
                Destroy(blood, 1.0f);

                // decrease health
                hit.collider.gameObject.GetComponent<Health>().DecreaseHealth(damage);
                Debug.Log("Hit enemy!");
            }
        }
        Debug.DrawRay(transform.root.position, transform.root.forward * range, Color.red, 1.0f);

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
                ammoReserves -= ammoSize - currentAmmo;
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
        audioSource.PlayOneShot(reloadSound);
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
}