using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    public enum AvailabilityState
    {
        Free,
        Unavailable,
        Occupied,

        Count
    }

    [SerializeField] 

    protected AvailabilityState m_availability = AvailabilityState.Free;
    public AvailabilityState Availability
    {
        get { return m_availability; }
        set { m_availability = value; }
    }
    [SerializeField] Gradient m_availabilityColors;

    /*[SerializeField] List<Color> m_availabilityColor = new List<Color>(Availability.Count);

    [SerializeField] Color m_freeColor;
    [SerializeField] Color m_UnavailableColor;
    [SerializeField] Color m_freeColor;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
