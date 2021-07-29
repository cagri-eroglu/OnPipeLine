using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
    public float speed = 1.0f;
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime, Space.World); // space world yaptık çünkü z eksenini GLOBAL EKSENDE tanımlamak istiyoruz. (Vector3.forward da diyebilirdik)
    }
}
