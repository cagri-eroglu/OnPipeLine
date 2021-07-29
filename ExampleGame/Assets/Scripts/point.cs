using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    [SerializeField]
    private Vector3 axis = new Vector3(0, 1, 0);
    [SerializeField]
    private LayerMask player_layer;
    [SerializeField]
    private Color Collectable_color, nonCollectablecolor;
    [SerializeField]
    private AudioClip pickup_sound;

    
    private PlayerManager pm;

    private void Awake()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    private void Update()
    {
        transform.Rotate(axis*Time.deltaTime);

        if (pm.can_collect)
        {
            //COLOR AND ROTATİON SPEED
            axis.y = 270;
            GetComponent<MeshRenderer>().material.color = Collectable_color;
            //  collect point
            bool touchingToPlayer = Physics.CheckSphere(transform.position, 0.2f, player_layer);
            if (touchingToPlayer)
            {
                pm.IncreaseHealth(2.0f);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(pickup_sound,3f); // ses dosyasını bi kere çalıştırıyore.
                Destroy(this.gameObject);
            }
        }
        else
        {
            //COLOR AND ROTATİON SPEED
            axis.y = 45;
            GetComponent<MeshRenderer>().material.color = nonCollectablecolor;
        }
        
    }
}
