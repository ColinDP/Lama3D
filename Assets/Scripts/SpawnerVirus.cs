using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVirus : MonoBehaviour
{
    [SerializeField] private GameObject virusObject;
    [SerializeField] private GameObject virusClone;
    [SerializeField] private int numberOfViruses;
    [SerializeField] private int timeBetweenInstantiate;


    private void Start()
    {
        StartCoroutine(InstantiateViruses());
    }
    
    private IEnumerator InstantiateViruses()
    {
        for (int i = 0; i < numberOfViruses; i++)
        {
            virusClone = Instantiate(virusObject);
            virusClone.transform.position = transform.position;
            yield return new WaitForSeconds(timeBetweenInstantiate);
        }  
    }
}
