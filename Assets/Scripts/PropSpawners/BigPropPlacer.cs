using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPropPlacer : MonoBehaviour
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
        Quaternion rotation = new Quaternion();
        /*        if (prop.name.Contains("contain"))
                    rotation.eulerAngles = new Vector3(0, 90, 0);
                else if (prop.name.Contains("oval"))
                    rotation.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);*/
        rotation.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        Vector3 pos = this.transform.position;
        pos.y = 0;
        Instantiate(prop, pos, rotation, this.transform.parent);
    }
}
