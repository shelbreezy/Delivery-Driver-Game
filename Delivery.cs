using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
// Putting a tint on the car when a package is picked up (tint will match the color of the package that is picked up)

    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);


// Connected to the destroy delay below
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

SpriteRenderer spriteRenderer;

void Start()
{
    spriteRenderer = GetComponent<SpriteRenderer>();
}


// when running into object such as rocks, houses, obstacles; respond Watch Out!

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Watch out!");
    }

// When the collider2d is triggered, if the package is picked up say so. then, delete the object on the screen. 
//  && !hasPackage requires for only one package to be picked up at a time

        void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Package" && !hasPackage)
              {
                Debug.Log("Package Retrieved!");
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, destroyDelay);
              } 
// if i drive over the mailbox and i have the package, i will say package delivered and i will no longer has the package. 
              if (other.tag == "Mailbox" && hasPackage)
            {
                Debug.Log("Package Delivered!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            } 
        } 
}
