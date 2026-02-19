using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    [Header("Actions")]
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;

    [Header("Players")]
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    [SerializeField] private float speed = 5f;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Rigidbody rb2;
    [SerializeField]
    float jumpHeight = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        p1Move.action.Enable();
        p2Move.action.Enable();
    }

    private void OnDisable()
    {
        p1Move.action.Disable();
        p2Move.action.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();
        var m2 = p2Move.action.ReadValue<Vector2>();

        if (p1) p1.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;
        if (p2) p2.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;


    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    public void OnJump2(InputAction.CallbackContext ctx)
    {
        rb2.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
