using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public bool myBool;   
    public AudioClip myClip; 

    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        myBool = GameObject.Find("Player").GetComponent<carcontroller>().xinhan;
        if (myBool==true)
        {
            PlaySound();
        }
        Debug.Log(myBool);
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(myClip);
    }
}
