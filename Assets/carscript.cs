using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carscript : MonoBehaviour
{
    Transform car;
    UnityEngine.AI.NavMeshAgent nav;
    public TriggerEvent dich;
    private int score=0;
    public Text botLap;
    GameObject gamemanager;
    public Transform[] listpoint;
    public int currentindex = 0;
    

    // Start is called before the first frame update
    public void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Start()
    {
    }
    void lapTrigger(Collider a)
    {
        if(a.gameObject.tag=="Car")
        {
            score++;
            botLap.text = score.ToString();
            if (botLap.text == "4")
            {
                SceneManager.LoadScene(4);
            }
        }
    }
    void Update()
    {
        car = listpoint[currentindex];
        nav.SetDestination(car.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            if(currentindex == listpoint.Length-1)
            {
                currentindex = 0;
            }
            else
            {
                currentindex++;
                
            }     
        }
    }

}
