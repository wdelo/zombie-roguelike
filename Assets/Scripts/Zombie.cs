using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent nav;
    private Animator animator;

    private void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();   
    }
    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
        animator.SetFloat("Speed", nav.velocity.magnitude);
        Debug.Log(nav.velocity.magnitude);
    }
}
