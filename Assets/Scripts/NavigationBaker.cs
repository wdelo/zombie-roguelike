using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace Lab6
{
    public class NavigationBaker : MonoBehaviour
    {

        public NavMeshSurface[] surfaces;

        void Start()
        {
            for (int i = 0; i < surfaces.Length; i++)
                surfaces[i].BuildNavMesh();
        }

    }
}