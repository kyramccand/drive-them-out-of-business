using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class myPickup : MonoBehaviour {
       public AudioSource pickupSFX;
       public float destroyDelay = 1f;

       private Animator anim;

       void Start() {
            anim = GetComponentInChildren<Animator>();
       }

        // Delay the destruction so the sound has time to play
       public void OnTriggerEnter2D(Collider2D other){
              if (other.gameObject.tag == "Car") {
                    anim.SetTrigger("Touch");
                    pickupSFX.Play();
                    StartCoroutine(hidePickup());
                    StartCoroutine(destroyPickup());
            }
       }

       IEnumerator hidePickup() {
            yield return new WaitForSeconds(0.02f);
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
       }

        // Destruction
       IEnumerator destroyPickup() {
              yield return new WaitForSeconds(destroyDelay);
              Destroy(gameObject);
       }
}