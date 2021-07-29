using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Sahneler arası geçiş yapmayı sağlayan kütüphane

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayerAlive = true;
    public static GameManager gm;
    private GameObject player;
    [SerializeField]
    private Transform playerStartPoint;
    [SerializeField]
    private Cameracontrol cc;
    [SerializeField]
    private float difficulty;
    public float distance;
    private void Awake()
    {
        gm = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

        //Load scene
        if (!isPlayerAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        //Check Player Distance
        if (player.gameObject!=null)
        {
            distance = Vector3.Distance(player.transform.position, playerStartPoint.position);
            UIManager.ui_m.setDistanceValue(distance);
        }
        cc.speed += Time.timeSinceLevelLoad / 10000 * difficulty; ;
        cc.speed = Mathf.Clamp(cc.speed, 1, 20);
        
    }

}
