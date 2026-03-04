using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMeleeSwing : MonoBehaviour
{
    private Animator animator; //Animator to turn on animations
    private F_PlayerMovement playerMovement;

    public PlayerWeapon currentWeapon;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<F_PlayerMovement>(); // Getting the Rigidbody component attached to the character
        animator = GetComponent<Animator>(); // Getting the Animator component attached to the character
        currentWeapon = GetComponentInChildren<PlayerWeapon>();
        currentWeapon.MeshCollider.enabled = false;
    }
    private void OnAttack(InputValue input)
    {
        if (animator != null && playerMovement.movementVector == Vector3.zero && canAttack)
        {
            animator.SetTrigger("IsSwinging");
            StartCoroutine(DelayColliderActivation());
            canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(currentWeapon.attackSpeed);
        currentWeapon.MeshCollider.enabled = false;
        canAttack = true;
    }

    private IEnumerator DelayColliderActivation()
    {
        yield return new WaitForSeconds(0.5f);
        currentWeapon.MeshCollider.enabled = true;
    }
}
