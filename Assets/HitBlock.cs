using UnityEngine;
 
public class HitBlock : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
 
    private PlatformEffector2D pe2d;
 
    [SerializeField]
    private GameObject itemPrefabStored;
 
    [SerializeField]
    private bool isHidden = false;
 
    void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        pe2d = GetComponent<PlatformEffector2D>();
 
        if (isHidden)
        {
            sr.enabled = false;
            pe2d.enabled = true;
        } else
        {
            sr.enabled = true;
            pe2d.enabled = false;
        }
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
            sr.enabled = true;
            pe2d.enabled = false;
 
            animator.SetTrigger("Hit");
 
            if (itemPrefabStored != null)
            {
                GameObject itemStored = Instantiate(
                    itemPrefabStored,
                    transform.position,
                    Quaternion.identity
                );
                Collectible itemCollectible = itemStored.GetComponent<Collectible>();
                //Activation de l'animation
                itemCollectible.Picked();

            }
        }
    }
}
 