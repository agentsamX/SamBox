using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPriority : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
           transform.GetChild(i).gameObject.GetComponent<CinemachineVirtualCamera>().Priority = (int)-Vector3.Magnitude(player.transform.position-transform.GetChild(i).position);
        }
    }
}
