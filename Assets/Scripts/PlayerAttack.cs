using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;

    private bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isAttacking", isAttacking);   //Attack animation. |   -It's working.

    }

    public void Attack(InputAction.CallbackContext context)
    {
        //print(context);

        if(context.performed)
        {
            isAttacking = true;
        }
        if(context.canceled)
        {
            isAttacking = false;
        }

    }

}
