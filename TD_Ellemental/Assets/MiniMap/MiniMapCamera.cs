using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform m_target;
    //private float m_initialY;

    // Start is called before the first frame update
    void Start()
    {
       // m_player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_target)
        {
            Vector3 newPosition = m_target.transform.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }

        //roatteion of camera same as player rotation but it is not needed for me.
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, m_player.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
