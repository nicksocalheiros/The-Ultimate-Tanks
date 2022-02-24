using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiplayController : MonoBehaviour
{
    public float playerSpeed = 5f;

    Rigidbody2D rigiBD2d;

    // Start is called before the first frame update
    void Start()
    {
        rigiBD2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMover();
    }

    void PlayerMover()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        rigiBD2d.velocity = new Vector2(x, y);
    }   
}
