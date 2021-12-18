using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerMotor pMotor;

    // Start is called before the first frame update
    void Start()
    {
        pMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = GetInput(); 
        /*if(inputDirection.sqrMagnitude > 0.25f)
        {
            pMotor.RotateChassis (inputDirection);
        }*/
    }

    Vector3 GetInput()
    {
        //Vector3 position = transform.position;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //position.x =  
        return new Vector3(h, v);
    }

    private void FixedUpdate()
    {
        pMotor.MovePlayer(GetInput());
    }
}
