using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVirus : MonoBehaviour
{
    [SerializeField] private GameObject virusObject;
    private GameObject virusClone;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            virusClone = Instantiate(virusObject);
            virusClone.transform.position = transform.position;
        }
    }
}
