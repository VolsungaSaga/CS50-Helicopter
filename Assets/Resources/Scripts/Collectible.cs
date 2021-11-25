using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    //How many coins is this worth?
    public int Worth;
    //How fast does it rotate around the y-axis?
    public float RotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         // despawn coin if it goes past the left edge of the screen
		if (transform.position.x < -25) {
			Destroy(gameObject);
		}
		else {

			// ensure coin moves at the same rate as the skyscrapers do
			transform.Translate(-SkyscraperSpawner.speed * Time.deltaTime, 0, 0, Space.World);
		}

		// infinitely rotate this coin about the Y axis in world space
		transform.Rotate(0, RotationSpeed, 0, Space.World);
    }


    void OnTriggerEnter(Collider other){
        other.transform.parent.gameObject.GetComponent<HeliController>().PickupCollectible(gameObject);

        Destroy(gameObject);
    }
}
