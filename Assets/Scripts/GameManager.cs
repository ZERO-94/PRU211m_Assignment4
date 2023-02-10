using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private TextMeshProUGUI gameStatus;
    [SerializeField]
    private TextMeshProUGUI goal;
    public float cameraSpeed = 0.05f;
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (((PlayerMovement)player.GetComponent(typeof(PlayerMovement))).isDead)
        {
            canvas.enabled = true;
            CameraMovement camMovement = (CameraMovement)Camera.main.GetComponent(typeof(CameraMovement));
            camMovement.IsMoving = false;
            gameStatus.text = "Lose";
        }

        if (((PlayerMovement)player.GetComponent(typeof(PlayerMovement))).isWin)
        {   
            canvas.enabled = true;
            CameraMovement camMovement = (CameraMovement)Camera.main.GetComponent(typeof(CameraMovement));
            camMovement.IsMoving = false;
            gameStatus.text = "Win";
        }
    }
}
