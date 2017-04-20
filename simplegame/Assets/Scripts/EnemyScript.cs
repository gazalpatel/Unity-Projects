using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    #region Fields

    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;
    private float enemy_x, enemy_y, enemy_z;

    #endregion

    #region Properties
    #endregion

    #region Functions
    // Use this for initialization
    void Start()
    {
        setPositionAndSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //amout to move which is consistant for all device
        float amountToMove = currentSpeed * Time.deltaTime;

        //move the enemy
        transform.Translate(Vector3.down * amountToMove);

        //wrap boundry for enemy
        if (transform.position.y < -5f)
        {
            setPositionAndSpeed();
        }  
    }

    // Set Random Position and Speed for Enemy
    public void setPositionAndSpeed()
    {
        //pick random speed
        currentSpeed = Random.RandomRange(minSpeed, maxSpeed);

        //pick random x position
        enemy_x = Random.RandomRange(-6f, 6f);
        enemy_y = 7.0f;
        enemy_z = 0.0f;

        //set position
        transform.position = new Vector3(enemy_x, enemy_y, enemy_z);
    }

  
    #endregion
}
