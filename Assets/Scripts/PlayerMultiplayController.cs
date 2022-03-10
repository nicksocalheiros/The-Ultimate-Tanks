using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMultiplayController : MonoBehaviour
{
    public float playerSpeed = 5f;

    Rigidbody2D rigiBD2d;
    PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        rigiBD2d = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            PlayerMover();
            PlayerTurn();
        }
    }

    void PlayerMover()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        rigiBD2d.velocity = new Vector2(x, y);
    }

    void PlayerTurn()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
