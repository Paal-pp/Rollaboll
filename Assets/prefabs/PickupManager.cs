using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pickupPrefab;

    void Start()
    {
        for (int i =0 ; i < 10 ; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4f, 4f), 0.5f, Random.Range(-4f, 4f));
            Instantiate(pickupPrefab , pos , Quaternion.identity);
        }
    }
    }

