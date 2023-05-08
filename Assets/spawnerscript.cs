using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    public GameObject car;
    public float carcount = 0;
    void Start()
    {
        InvokeRepeating("SpawnCar", 1, 4);
    }
    void SpawnCar()
    {
        if(carcount <=5)
        {
            Instantiate(car, transform.position, Quaternion.identity);
            carcount++;
        }
        
    }
}
