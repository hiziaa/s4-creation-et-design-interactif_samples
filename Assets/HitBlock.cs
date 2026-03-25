using UnityEngine;
 
public class HitBlock : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
 
        ContactPoint2D contactPoint = collision.GetContact(0);
 
        if (contactPoint.normal.y > 0.5f)
        {
            animator.SetTrigger("Hit");
        }
    }
}
 
 