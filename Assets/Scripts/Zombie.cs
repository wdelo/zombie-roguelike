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
            nav.SetDestination(target.position);
            if (Vector3.Distance(transform.position, target.position) < 2)
            {
                animator.SetBool("Attacking", true);
            }
            else
                animator.SetBool("Attacking", false);
            animator.SetFloat("Speed", nav.velocity.magnitude);
        }
    }
}