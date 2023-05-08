using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public int speed;
    public static GameManage instance;
    UnityEngine.AI.NavMeshAgent nav;
    public GameObject levelmenu;
    void Start()
    {
        instance= this;
    }
    void Update()
    {
      
    }
}
