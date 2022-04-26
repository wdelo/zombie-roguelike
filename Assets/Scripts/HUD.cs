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
        [SerializeField] Text score;
        GameManager gameManager;
        Health health;
        Gun gun;
        void Start()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().GetGun();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            healthBar.maxValue = health.GetMaxHealth();
            healthBar.value = health.GetMaxHealth();
            magSize.text = gun.GetAmmoSize().ToString();
        }
        void Update()
        {
            healthBar.value = health.GetHealth();
            currentAmmo.text = gun.GetCurrentAmmo().ToString();
            ammoPool.text = gun.GetAmmoReserves().ToString();
            score.text = gameManager.GetScore().ToString();
        }
    }
}