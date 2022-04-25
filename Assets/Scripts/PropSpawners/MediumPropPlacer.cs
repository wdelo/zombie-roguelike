using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab6
{
    public class MediumPropPlacer : MonoBehaviour
    {
        [SerializeField] List<GameObject> props = new List<GameObject>();
        void Start()
        {
            this.gameObject.SetActive(false);
            this.GetComponent<MeshRenderer>().enabled = false;
            PlaceProp();

        }

        private void PlaceProp()
        {
            var rand = new System.Random();
            GameObject prop = props[rand.Next(props.Count)];
            Vector3 pos = this.transform.position;
            pos.y = 0;
            if (prop.name == "locker 1")
                pos.y += 0.3f;
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            Instantiate(prop, pos, rotation, this.transform.parent);
        }
    }
}