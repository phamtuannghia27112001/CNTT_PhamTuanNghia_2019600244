using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public int speed;
    public static LevelMenu mLevelMenu = null;
    private void Awake()
    {
        if(mLevelMenu==null)
        {
            mLevelMenu = this;
        }
        else
        {
            Destroy(mLevelMenu);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
       
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void lv1() 
    {
        SceneManager.LoadScene(1);
        speed = 5;
    }
    public void lv2()
    {
        SceneManager.LoadScene(1);
        speed = 15;
    }
    public void lv3()
    {
        SceneManager.LoadScene(1);
        speed = 30;
    }
}
