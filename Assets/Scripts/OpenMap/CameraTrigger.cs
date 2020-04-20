using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CamerasController.instance.EnableCamera(myCamera);
        }
    }
}