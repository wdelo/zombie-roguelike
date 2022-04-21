using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPropPlacer : MonoBehaviour
{
    List<GameObject> props = new List<GameObject>();
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        props.Add((GameObject)Resources.Load("box", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("WaterTank", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("WorkLight", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("Warehouse Crates", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("bin", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("cabinet", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("OxygenTank", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("locker 2", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("locker 1", typeof(GameObject)));
        props.Add((GameObject)Resources.Load("RoadDivider", typeof(GameObject)));
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
