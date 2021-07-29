using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Constants
    private const float size_scaler = 0.28f;
    private const float checker_radius = 0.13f;
    private const float offset = 0.2f;
    #endregion
    #region SerializedFields
    [SerializeField]
    private Vector3 default_size = new Vector3(1, 1, 1);
    [SerializeField]
    private LayerMask cylinder_layer;
    [SerializeField]
    private AudioClip clip_sound,death_sound;

   
    
    public bool can_collect = false;

    public float health = 10.0f;
    #endregion
    #region Unity
    private void Update()
    {
        //Define cylinder
        Transform cylinder = Physics.OverlapSphere(transform.position,checker_radius, cylinder_layer)[0].transform;  //çarpığı nesnenin lokasyonuna eriştik yani bool olmaktan çıktı.;
        float cylinder_radius = cylinder.localScale.x * size_scaler;// ölçüleri dengelemek için size_scaler ile çarptık blenderınkiyle unityde aynı değil çünkü ölçüler.

        if (health<=0)
        {
            Death();
        }

        // Check for situations
        if (cylinder_radius>transform.localScale.y)
        {
            Death();    
        }

        if (cylinder.CompareTag("Enemy"))
        {
            if (cylinder_radius+offset>transform.localScale.y)
            {
                Death();
            }
        }

        // Check can_collect
        if (cylinder_radius + offset > transform.localScale.y)
        {
            can_collect = true;
        }
        else
        {
            can_collect = false;
        }


        ChangeRingRadius(cylinder_radius);
        HealthCounter();
        
    }
    #endregion
    #region Functions
    private void Death()
    {
        //Stop Camera contorleeer
        if (Camera.main != null)
        {
            Camera.main.GetComponent<Cameracontrol>().enabled = false;
        }
        //Open GameOverUI
        UIManager.ui_m.OpenGameOverUI();

        //player alive boolean
        GameManager.gm.isPlayerAlive = false;

        //play death sound effect;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(death_sound);

        // save high score
        if (GameManager.gm.distance > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", GameManager.gm.distance);

        }

        // set high score text
        UIManager.ui_m.Sethighscoretext();

        //Destroy gameobject !!!!!!!
        Destroy(this.gameObject);

    }
    private void ChangeRingRadius(float cylinder_radius)
    {


        if (Input.GetMouseButton(0))
        {
            // play sound effect
            Camera.main.GetComponent<AudioSource>().PlayOneShot(clip_sound, 0.1f);
        }
        // when touched to screen
        if (Input.GetMouseButton(0))
        {
            // set size of the ring
            Vector3 target_vector = new Vector3(default_size.x, cylinder_radius, cylinder_radius);
            transform.localScale = Vector3.Slerp(transform.localScale, target_vector, 0.5f);


        }
         
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, default_size, 0.5f);
        }

    }

    private void HealthCounter()
    {
        health = Mathf.Clamp(health,-1f, 10.0f);
        if(health>=0)
        {           
            health -= Time.deltaTime;
            UIManager.ui_m.setPlayerHealth(health);
        }
       
    }

    public void IncreaseHealth(float value)
    {
        health += value;
    }

    #endregion
}
