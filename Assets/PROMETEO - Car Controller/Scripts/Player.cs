using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TriggerEvent dich;
    private int score = 0;
    public Text playerLap;
    void Start()
    {
       
    }
    void lapTrigger(Collider other)
    {
    }
}
