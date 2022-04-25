using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lab6
{

    public class HUD : MonoBehaviour
    {
        [SerializeField] Slider healthBar;
        [SerializeField] Text currentAmmo;
        [SerializeField] Text magSize;
        [SerializeField] Text ammoPool;
        Health health;
        Gun gun;
        void Start()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
            healthBar.maxValue = health.GetMaxHealth();
            magSize.text = gun.GetAmmoSize().ToString();
            ammoPool.text = gun.GetAmmoReserves().ToString();
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.value = health.GetHealth();
            currentAmmo.text = gun.GetCurrentAmmo().ToString();
        }
    }
}