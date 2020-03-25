using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform m_followedTransform;
    private Vector3 m_offsetPosition;
    //private Quaternion m_offsetRotation;

    // Start is called before the first frame update
    void Start()
    {
        m_offsetPosition = transform.position - m_followedTransform.position;
        //m_offsetRotation = transform.rotation - m_followedTransform.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_followedTransform.position + m_offsetPosition;
    }
}
