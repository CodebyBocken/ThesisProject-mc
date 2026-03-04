using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB;
    private Vector3 movementInput;

    [Header("Movement")]
    private Vector3 movementVector;
    [SerializeField] float movementSpeed;

    [SerializeField] private ParticleSystem dustParticles;
    [SerializeField] private Transform dustTransform;

    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        dustParticles.Stop();
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

        HandleDustParticles();
    }
    private void OnMovement(InputValue input)
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }

    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
    }

    void HandleDustParticles()
    {
        if (movementVector.magnitude > 0.1f)
        {
            if (!dustParticles.isPlaying)
            {
                dustParticles.Play();
            }

            if (movementInput.z < 0)
            {
                dustTransform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                dustTransform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            if (dustParticles.isPlaying)
            {
                dustParticles.Stop();
            }
        }
    }
}
