using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPropPlacer : MonoBehaviour
{
    [SerializeField]List<GameObject> props = new List<GameObject>();
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        PlaceProp();
    }

    private void PlaceProp()
    {
        var rand = new System.Random();
        GameObject prop = props[rand.Next(props.Count)];
        Vector3 pos = this.transform.position;
        pos.y = 0;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        Instantiate(prop, pos, rotation, this.transform.parent);
    }
}
