using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Cinemachine.CinemachineBrain brain;
    public float m_speed = 1f;
    private Transform m_cameraTransform;
    private Rigidbody m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical")==0&&Input.GetAxis("Horizontal")==0)
        {
            m_cameraTransform = brain.ActiveVirtualCamera.VirtualCameraGameObject.transform;

        }

        Vector3 f = m_cameraTransform.forward;
        f.y = 0;
        f=f.normalized;

        Vector3 r = m_cameraTransform.right;
        r.y = 0;
        r = r.normalized;

        Vector3 dir = f * Input.GetAxis("Vertical") * m_speed + r * Input.GetAxis("Horizontal") * m_speed;
        dir.y=m_rigidBody.velocity.y;

        m_rigidBody.velocity=dir;
        
    }
}
