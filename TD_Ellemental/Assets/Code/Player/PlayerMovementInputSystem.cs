using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerMovementInputSystem : MonoBehaviour
{
    //[SerializeField] InputControlls m_inputControlls;
    Vector3 m_moveDist = Vector3.zero;



    private void Awake()
    {
        /*m_inputControlls = new InputControlls();
        m_inputControlls.Camera.Move.performed += InputActionContext_Move;//ctx => m_moveDist = new Vector3( ctx.ReadValue<Vector2>();  */
    }

    private void OnEnable()
    {
        //m_inputControlls.Enable();
    }

    private void OnDisable()
    {
       // m_inputControlls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTest()
    {
        Debug.Log("MoveTest");
    }

   /* public void InputActionContext_Move(InputAction.CallbackContext a_context)
    {
        Vector2 inputValue = a_context.ReadValue<Vector2>();
        m_moveDist.x = inputValue.x;
        m_moveDist.z = inputValue.y;
        Debug.Log($"InputActionContext_Move: inputValue.x = {inputValue.x} inputValue.y = {inputValue.y}");
    }*/
}
