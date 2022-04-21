using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPlacement : MonoBehaviour
{
    List<GameObject> bigProps;
    List<GameObject> mediumProps;
    List<GameObject> smallProps;
    void Start()
    {
        bigProps = new List<GameObject> ();
        mediumProps = new List<GameObject>();
        smallProps = new List<GameObject>();
        bigProps.Add((GameObject)Resources.Load("container 1", typeof(GameObject)));
        bigProps.Add((GameObject)Resources.Load("container 2", typeof(GameObject)));
        mediumProps.Add((GameObject)Resources.Load("WaterTank", typeof(GameObject)));
    }

    private void PlaceProps()
    {

    }
}
