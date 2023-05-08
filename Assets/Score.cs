using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 100;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        carcontroller otherscript = FindObjectOfType<carcontroller>();
        if (other.gameObject.tag == "flagscore1")
        {
            otherscript.start();
            Debug.Log(score);
            if (otherscript.xinhan == false)
            {
                score = score - 5;
                Debug.Log(score);
            }
        }
    }
}
