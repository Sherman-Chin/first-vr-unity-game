using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 5f;
    public float m_TurnSpeed = 360f;

    private Vector3 m_Rotation = new Vector3();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Moving the player

        //Returns a decimal value between -1 & 1. -1 means backward, 1 means forward.
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        //Move in the direction of the player is facing. We need to use moveSpeed and Time.deltaTime because
        //we want each users to move at the same speed. This gives movement/second rather than movement/frame
        Vector3 moveDirection = transform.forward * m_Speed * vInput * Time.deltaTime;

        //This moves in the left and right direction
        moveDirection += transform.right * m_Speed * 0.5f * hInput * Time.deltaTime;

        //Check for sprint input
        if (Input.GetKey(KeyCode.LeftShift)) {
            moveDirection = moveDirection * 1.5f;
        }

        //Get the character controller component attached to the object attached to this script. Then, apply movement. 
        GetComponent<CharacterController>().Move(moveDirection);

        //This is the same as moving the character, but it can move into any position (into walls)
        //transform.position += moveDirection;

        //Rotating the player
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        m_Rotation.x -= mouseY * m_TurnSpeed * Time.deltaTime;
        //Clamp 'x' (Up/Down) rotation between 2 values. If they exceed the limit, set it to the limit;
        //We don't want the player to go up and down over a certain limit because it is weird.
        m_Rotation.x = Mathf.Clamp(m_Rotation.x, -40f, 40f);
        m_Rotation.y += mouseX * m_TurnSpeed * Time.deltaTime;
        m_Rotation.z = 0f;

        transform.rotation = Quaternion.Euler(m_Rotation);


    }
}
