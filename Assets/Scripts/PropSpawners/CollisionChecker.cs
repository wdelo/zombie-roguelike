using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (!collision.gameObject.name.Contains("Player") && !collision.gameObject.name.Contains("Zombie"))
        {
            Debug.Log("Rotated");
            collision.gameObject.transform.Rotate(new Vector3(0, 5, 0));
        }
    }
}
