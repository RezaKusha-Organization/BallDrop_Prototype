using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 500;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float powerupStrength = 15;
    [SerializeField] private GameObject powerupIndicator;
    private CameraRotate _cameraRotate;
    private bool hasPowerup = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraRotate = GameObject.Find("Focal Point").GetComponent<CameraRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(_cameraRotate.transform.forward * _speed * forwardInput * Time.deltaTime);
        powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Powerup")
        {
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            hasPowerup = true;
        }

    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
       
    }
}
