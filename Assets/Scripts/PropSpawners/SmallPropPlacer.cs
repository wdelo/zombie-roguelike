using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPropPlacer : MonoBehaviour
{
    List<GameObject> props = new List<GameObject>();
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        props.Add((GameObject)Resources.Load("jerry can 1", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("jerry can 2", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Box 1", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Propane Tank", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Oil Barrel-2", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Oil barrel-1", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("ConstructionCone", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Nitrogen Tank", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Crate-1", typeof(GameObject)));
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
