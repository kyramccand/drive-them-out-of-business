using System.Collections;
using UnityEngine;

public class DestroyIceCreamStore : MonoBehaviour
{
    public GameObject breakVFX;
    public float vfxLifetime = 0.5f;
    public string carTag = "Car";

    public float shakeTime = 0.12f;
    public float shakeAmount = 0.06f;

    public AudioSource breakSFX;   // Drag the AudioSource here
    public float destroyDelay = 1f;

    bool destroyed = false;
    Vector3 startPos;
    SpriteRenderer sr;

    void Awake()
    {
        startPos = transform.position;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyed) return;
        if (!other.transform.root.CompareTag(carTag)) return;

        destroyed = true;

        // ✅ Play AudioSource
        if (breakSFX != null)
            breakSFX.Play();

        StartCoroutine(BreakSequence());
        StartCoroutine(HideStore());
        StartCoroutine(DestroyStore());
    }

    IEnumerator BreakSequence()
    {
        // Shake
        float t = 0f;
        while (t < shakeTime)
        {
            t += Time.deltaTime;
            transform.position = startPos + (Vector3)(Random.insideUnitCircle * shakeAmount);
            yield return null;
        }

        transform.position = startPos;

        // ✅ Center effect visually (not collider offset)
        Vector3 centerPoint = (sr != null) ? sr.bounds.center : transform.position;

        if (breakVFX != null)
        {
            GameObject fx = Instantiate(breakVFX, centerPoint, Quaternion.identity);
            Destroy(fx, vfxLifetime);
        }
    }

    IEnumerator HideStore()
    {
        yield return new WaitForSeconds(0.02f);

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        if (sr != null) sr.enabled = false;
    }

    IEnumerator DestroyStore()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}