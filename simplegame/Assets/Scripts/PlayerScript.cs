using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float playerSpeed;
    public GameObject projectilePrefab;
    private float x, y, z;

	// Use this for initialization
	void Start () 
    {
        //change player position on start up
        //transform.position = new Vector3(-6, 5, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //amout to move which is not consistant for all device
        //float amoutToMove = Input.GetAxis("Horizontal") * playerSpeed ;
        
        //amout to move which is consistant for all device
        float amoutToMove = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;

        //move the player object
        transform.Translate(Vector3.right * amoutToMove);

        //wrap object boundry and move another side
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        //if you don't want to move then don't change sign for value of x
        if(transform.position.x >= 7.5f)
        {
            x = -7.4f;
        }
        if (transform.position.x <= -7.5f)
        {
            x = 7.4f;
        }
        transform.position = new Vector3(x, y, z);

        //should fire projectile or not
        if (Input.GetKeyDown("space"))
        {
            //fire projectile on fix position
            //Instantiate(projectilePrefab);

            //fire projectile at position of player with no rotation
            Vector3 projectilePosition = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y/2));
            Instantiate(projectilePrefab, projectilePosition, Quaternion.identity);
        }
	}
}
