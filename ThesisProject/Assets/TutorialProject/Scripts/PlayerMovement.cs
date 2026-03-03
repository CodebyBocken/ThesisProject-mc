using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB;
    private Vector3 movementInput;

    [Header("Movement")]
    private Vector3 movementVector;
    [SerializeField] float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementInput != Vector3.zero)
        {
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
            movementVector.y = 0;
        }

        characterRB.velocity = (movementVector * Time.fixedDeltaTime * movementSpeed);
    }
    private void OnMovement(InputValue input)
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }

    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
    }
}
