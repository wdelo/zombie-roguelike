using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent nav;
    private Animator animator;

    private void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        Debug.Log(target);
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 10)
        {
            
            nav.SetDestination(target.position);
        }
        else
        {
            //Debug.Log(Vector3.Distance(transform.position, target.position));
            nav.SetDestination(transform.position);
        }
        if (Vector3.Distance(transform.position, target.position) < 2)
        {
            animator.SetBool("Attacking", true);
        }
        else
            animator.SetBool("Attacking", false);
        animator.SetFloat("Speed", nav.velocity.magnitude);
        //Debug.Log(nav.velocity.magnitude);
    }
}
