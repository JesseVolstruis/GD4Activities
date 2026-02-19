using UnityEngine;
using UnityEngine.InputSystem;
public class Player1 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float jumpStep = 1f;
    [SerializeField]
    float rotateSpeed = 180f;
    Vector2 lookInput;
    Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = lookInput.x * rotateSpeed * Time.deltaTime;
        transform.Rotate(0f, y, 0f, Space.World);

        Vector3 move3 = new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed * Time.deltaTime;
        transform.position += move3;
    }

    public void OnMovement(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        transform.position += Vector3.up * jumpStep;
    }
}
