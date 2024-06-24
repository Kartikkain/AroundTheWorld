using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] float m_Sen;
    [SerializeField] float rotateX = 0f;
    [SerializeField] Animator m_Animator;
    [SerializeField] float speedMultiplier = 1.0f;
    [SerializeField] float currentSpeed = 0.0f;
    private float scrollSensitivity = 0.1f; // Adjust this value to change how scroll affects speed


    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        float DragInput = Input.GetAxis("Mouse X");
        rotateX += DragInput * m_Sen * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, -rotateX, 0);


        currentSpeed += DragInput * scrollSensitivity;
        currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, 1.0f); // Adjust the range as needed

        // Set the animator speed parameter
        //m_Animator.SetFloat("Walking", currentSpeed * speedMultiplier);

        

    }


    

    
}
