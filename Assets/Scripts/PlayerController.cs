using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 500;
    [SerializeField] private Rigidbody playerRb;
    private CameraRotate _cameraRotate;
    
    
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
    }
}
