using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class carcontroller : MonoBehaviour
{
    public AudioClip myClip;

    AudioSource audioSource;
    public AudioClip clip;
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;
    public bool xinhan = false;
    public bool xinhan1 = false;
    public int score = 100;
    public float forward = 2000f;


    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 60f;
    public float brakeForce = 0f;
    public float carSpeed;
    [Space(20)]
    //[Header("UI")]
    [Space(10)]
    //The following variable lets you to set up a UI text to display the speed of your car.
    public bool useUI = true;
    public Text carSpeedText; // Used to store the UI object that is going to show the speed of the car.
    public Text numberText;
    float number;
    public Rigidbody carRigidbody;
    private void Start()
    {
        if (useUI)
        {
            InvokeRepeating("CarSpeedUI", 0f, 0.1f);
            InvokeRepeating("CarNumberUI", 0f, 1f);
        }
    }
    void Update()
    {
        carSpeed = carRigidbody.velocity.magnitude;
        GetInput();
        UpdateWheels();
        HandleSteering();
        HandleMotor();
        start();
        play();
        onoff();
        Debug.Log(score);
    }
    private void GetInput()
    {
        horizontalInput = SimpleInput.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }
    public void CarSpeedUI()
    {

        if (useUI)
        {
            try
            {
                carSpeedText.text = carSpeed.ToString();
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);
            }
        }

    }
    public void CarNumberUI()
    {
        if (useUI)
        {
            try
            {
                if (Mathf.Abs(carSpeed) == 0)
                    number = 0;
                if (Mathf.Abs(carSpeed) > 0)
                    number = 1;
                if (Mathf.Abs(carSpeed) > 20)
                    number = 2;
                if (Mathf.Abs(carSpeed) > 40)
                    number = 3;
                if (Mathf.Abs(carSpeed) > 60)
                    number = 4;
                if (Mathf.Abs(carSpeed) > 80)
                    number = 5;

                numberText.text = number.ToString();
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);
            }
        }
    }


    public void start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {   
                if (other.gameObject.tag == "flagscore1")
                {
                    if (xinhan == false)
                    {
                        score = score - 5;
                    }
                    if(xinhan == true)
            {
                score = score - 5;
                audioSource.PlayOneShot(clip);
                audioSource.Play();
            }    
                    StartCoroutine(DeleteGameObjectCoroutine(GameObject.Find("Cube12"), 8f));
                }
                if (other.gameObject.tag == "flagscore2")
                {
                    score = score - 5;
                }
                if (other.gameObject.tag == "flagscore3")
                {
                    score = score - 5;       
        }
    }
    private IEnumerator DeleteGameObjectCoroutine(GameObject gameObject, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
    public void play()
    {
        if (xinhan == true)
        {
            PlaySound();
        }
        else
        {
            audioSource.Stop();
        }    
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(myClip);
    }
    public void onoff()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            xinhan = !xinhan;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xinhan1 = !xinhan1;
        }
    }
    public void PlaySoundCoroutine() // Coroutine để phát âm thanh sau 5 giây
    {
        audioSource.PlayOneShot(clip); 
    }   
}
