using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private CharacterController controller;
    private float yaw = 0f;
    private float pitch = 0f;
    
    public float Speed = 5f;
    public float viewSpeedH = 2f;
    public float viewSpeedV = 2f;

    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = 0f;
        // check for "jump/crouch"
        if (Input.GetButton("Jump"))
        {
            vertical = 1f;
        }else if (Input.GetButton("Crouch"))
        {
            vertical = -1f;
        }
        // Todo: Break vertical movement out from horizontal movement
        Vector3 move =  new Vector3(Input.GetAxis("Horizontal"), vertical, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        move = move * Speed;
        controller.Move(move * Time.deltaTime * Speed);
        
        // Mouse Look Controls
        yaw += viewSpeedH * Input.GetAxis("Mouse X");
        pitch -= viewSpeedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("Hit Interactable!");
                    interactable.Interact();
                }
            }
        }*/
    }
}
