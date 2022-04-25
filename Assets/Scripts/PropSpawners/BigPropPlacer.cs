using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab6
{
    public class BigPropPlacer : MonoBehaviour
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
            if (prop.name.Contains("shelf"))
                pos = new Vector3(pos.x, pos.y, pos.z - 3);
            if (prop.name.Contains("palette"))
                pos.y += 0.61f;
            Quaternion rotation = new Quaternion();
            if (prop.name.Contains("contain"))
                rotation.eulerAngles = new Vector3(0, 90, 0);
            else
                rotation.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            Instantiate(prop, pos, rotation, this.transform.parent);
            Debug.Log(prop + "'s collider: " + prop.GetComponent<BoxCollider>());
        }

    }
}
