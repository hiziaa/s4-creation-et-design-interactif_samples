using System.Collections;
using UnityEngine;
 
public class HitBlock : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private int maxHits = 2;

    private int currentHits = 0;

    private SpriteRenderer sr;
 
    private PlatformEffector2D pe2d;
 
    [SerializeField]
    private GameObject itemPrefabStored;
 
    [SerializeField]
    private bool isHidden = false;
 
    private bool isAnimating = false;
 
    void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        pe2d = GetComponent<PlatformEffector2D>();
 
        if (isHidden)
        {
            sr.enabled = false;
            pe2d.enabled = true;
        }
        else
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
 
        if (contactPoint.normal.y > 0.5f && currentHits < maxHits)
        {
            currentHits = currentHits + 1;
            animator.SetTrigger("Hit");

            if(currentHits == maxHits)
            {
                sr.color = new Color (1f,1f,0.5f);
            }
            sr.enabled = true;
            pe2d.enabled = false;
 
            animator.SetTrigger("Hit");
 
            if (itemPrefabStored != null)
            {
                StartCoroutine(ItemStoredAnimation());
            }
        }
    }
 
    IEnumerator ItemStoredAnimation()
    {
        isAnimating = true;
 
        GameObject itemStored = Instantiate(
                    itemPrefabStored,
                    transform.position,
                    Quaternion.identity
                );
        Collectible itemCollectible = itemStored.GetComponent<Collectible>();
        // Désactive la récupération de l'objet quand il a été touché
        itemCollectible.canBeDestroyedOnContact = false;
        // Méthode custom ajouté à la classe "Transform" qui permet d'animer la position
        // d'un gameobject (durée par défaut 0.125s).
        // Ici on augmente de 50% la position en Y du gameobject
        yield return itemCollectible.transform.MoveBackAndForth(
            itemStored.transform.localPosition + Vector3.up * 1.5f
        );
        // Activation de l'animation
        itemCollectible.Picked();
 
        isAnimating = false;
    }
}
 