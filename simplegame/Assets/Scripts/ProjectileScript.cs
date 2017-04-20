using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{

    public float projectileSpeed;
    private Transform myTransform;

	// Use this for initialization
	void Start () 
    {
        //saves cycle for checking transform object in memory all time
        //specially for iphone devices
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
    {

        //amout to move which is consistant for all device
        float amoutToMove = projectileSpeed * Time.deltaTime;

        //move projectile up without input from player4
        transform.Translate(Vector3.up * amoutToMove);

        //wrap upper boundry for projectile
        if (myTransform.position.y > 6.2f)
        {
            Destroy(gameObject);
        }


        /* this works same as above wraping method
           
         * 
            if (gameObject.transform.position.y > 6.2f)
            {
                Destroy(this.gameObject);
            }
         * or
         * if (transform.position.y > 6.2f)
            {
                Destroy(gameObject);
            }
         * 
         */
    }

    //calls when collider other enters the trigger
    void OnTriggerEnter(Collider otherObject)
    {
        //Debug.Log("We hit : " + otherObject.name);
       
        //destroy enemy object do not delete only collider object
        if (otherObject.tag == "enemy")
        {
            //destroy our single object whole
            //Destroy(otherObject.gameObject);
            //enemy at similar position every time
            //otherObject.transform.position = new Vector3 (otherObject.transform.position.x,7.0f,otherObject.transform.position.z);

            //intialize our otherobject as EnemyScript to call method of enemy for setting random position and speed
            EnemyScript enemyOb = (EnemyScript) otherObject.gameObject.GetComponent("EnemyScript");
            enemyOb.setPositionAndSpeed();

            //destroy projectile which has collided
            Destroy(this.gameObject);
        }
    }
}
