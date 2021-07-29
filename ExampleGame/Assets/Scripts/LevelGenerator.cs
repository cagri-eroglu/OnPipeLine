using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    #region SerializedField
    [Header("Cylinder Attributes")]
    [Tooltip("Defalut cylinder prefab for instantiate")]
    [SerializeField]
    private GameObject cylinder;

    [Tooltip("Minimum radius for cylinder size")]
    [SerializeField]
    private float minRadius;
    [Tooltip("Maximum radius for cylinder size")]
    [SerializeField]
    private float maxRadius;

    [Header("Enemy Cylinder Attributes")]
    [SerializeField]
    private Color enemy_cylinder;

    
    #endregion
    #region Private Variable
    private GameObject previous_cylinder;
    #endregion
    
    #region Functions
    //çapları birbirine yakın olmasın diye
    private float FindRadius(float minR,float maxR)
    {
        float radius = Random.Range(minR,maxR);
        if (previous_cylinder!=null) //önceden bir silindir oluşmuş olmalı.
            while (Mathf.Abs(radius-previous_cylinder.transform.localScale.x)<0.4f)
            {
                radius = Random.Range(minR, maxR);
            }
        return radius;
    }
    #endregion

    public void spawnCylinder()
    {
        float radius = FindRadius(minRadius, maxRadius);
        float height = Random.Range(2f, 5f);

        //Apply radius and height
        cylinder.transform.localScale = new Vector3(radius, height, radius);

        //first cylinder
        if (previous_cylinder == null)
        {
            previous_cylinder = Instantiate(cylinder, Vector3.zero, Quaternion.identity);

        }
        //all other cylinders
        else
        {

            float spawn_point = previous_cylinder.transform.position.z + cylinder.transform.localScale.y + previous_cylinder.transform.localScale.y; // localescalede y globalde zye tekabül ediyor.               
            previous_cylinder = Instantiate(cylinder, new Vector3(0, 0, spawn_point), Quaternion.identity);

            //Create enemy cylinder
            if (Random.value < 0.1f)
            {
                previous_cylinder.GetComponent<Renderer>().material.color = enemy_cylinder;
                previous_cylinder.tag = "Enemy";
            }

        }
        //Rotate
        previous_cylinder.transform.Rotate(90, 0, 0);
    }
}
 