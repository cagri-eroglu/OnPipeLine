using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class application_manager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
