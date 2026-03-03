using System.Collections;
using UnityEngine;


public class PedestrianYell : MonoBehaviour
{
    public string carTag = "Car";
    public AudioSource yellSFX;
    public float destroyDelay = 1f;


    private Animator anim;
    private Collider2D col;
    private SpriteRenderer sr;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (!other.transform.root.CompareTag(carTag)) return;


        if (anim != null) anim.SetTrigger("Touch");


        if (yellSFX != null)
            yellSFX.Play();


        StartCoroutine(HidePedestrian());
        StartCoroutine(DestroyPedestrian());
    }


    IEnumerator HidePedestrian()
    {
        yield return new WaitForSeconds(0.02f);
        if (col != null) col.enabled = false;
        if (sr != null) sr.enabled = false;
    }


    IEnumerator DestroyPedestrian()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}

