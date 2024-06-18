using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem particleThrust;
    [SerializeField] ParticleSystem particleThrustL;
    [SerializeField] ParticleSystem particleThrustR;

    Rigidbody rb;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();   
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(thrustSpeed * Vector3.up * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!particleThrust.isPlaying)
            {
                particleThrust.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            // if (particleThrust.isPlaying)
            // {
            //     particleThrust.Stop();
            // }
        }
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationSpeed);
            if (!particleThrustR.isPlaying)
            {
                particleThrustR.Play();
            }
        }
        else 
        {
            if (particleThrustR.isPlaying)
            {
                particleThrustR.Stop();
            }
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationSpeed);
            if (!particleThrustL.isPlaying)
            {
                particleThrustL.Play();
            }
        }
        else 
        {
            if (particleThrustL.isPlaying)
            {
                particleThrustL.Stop();
            }
        }
    }

    private void ApplyRotation(float rotationValue) 
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
