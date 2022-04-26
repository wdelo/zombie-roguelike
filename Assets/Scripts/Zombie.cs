//Oskar Klear
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Lab6
{
    public class Zombie : MonoBehaviour
    {
        private Transform target;
        private NavMeshAgent nav;
        private Animator animator;
        [SerializeField] float maxSpeed;
        private int timer;

        private void Start()
        {
            nav = this.GetComponent<NavMeshAgent>();
            animator = this.GetComponent<Animator>();
            target = GameObject.Find("Player").transform;
        }
        void Update()
        {
            if (nav.velocity.magnitude > maxSpeed)
                nav.velocity = nav.velocity.normalized*maxSpeed;
            if (Vector3.Distance(transform.position, target.position) > 1)
                nav.SetDestination(target.position);
            else
                nav.SetDestination(transform.position);
            if (Vector3.Distance(transform.position, target.position) < 2)
            {
                animator.SetBool("Attacking", true);
            }
            else
                animator.SetBool("Attacking", false);
            animator.SetFloat("Speed", nav.velocity.magnitude);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Equals("Player"))
                StartCoroutine(Damage());
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name.Equals("Player"))
                StopCoroutine(Damage());
        }
        IEnumerator Damage()
        {
            while (true)
            {
                target.GetComponent<Health>().DecreaseHealth(5);
                yield return new WaitForSeconds(1);
            }
        }
    }
}