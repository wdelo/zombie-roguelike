using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] GameObject leftCube;
    [SerializeField] GameObject rightCube;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(leftCube, new Vector3(-0.5f, 0.5f, 11.5f), Quaternion.identity);
        StartCoroutine("SpawnOtherCube");
    }

    IEnumerator SpawnOtherCube()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(rightCube, new Vector3(3.5f, 0.5f, 11.5f), Quaternion.identity);
    }

}
