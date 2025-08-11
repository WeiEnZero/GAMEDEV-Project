using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIChase : MonoBehaviour
{
    Transform Player;
    public float speed = 2f;
    private Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            FindPlayer(); // Try to find player if its not lost (e.g. respawned into the game)
            return;       // Skip moving if no player found
        }

        if (!Player.gameObject.activeInHierarchy)
        {
            Player = null; // The Player wil be set to Null if the player object is disabled, destroyed or missing in the game world.
            return;
        }

        // Determines the distance and direction between the Player and the Enemy Object by subtracting the coordinates.
        Vector2 direction = Player.position - transform.position;

        // Calculates the amount of speed and uses MoveTowrds using the coordinates of the enemy and Player to make the enemy move towards the player according to that speed.
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

        // Changes the direction of the Sprite between left and right using the direction variable's x coordinate and uses Vector 3 to change the Sprite's direction acoording to Local Scale.
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
    }

        private void FindPlayer()
        {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");  // Finds the GameObject containing the "Player" Tag.
        if (playerObj != null)  // If condition is used to determine if the PlayerObject is active or null in the game world, it will be assigned the transform component of the object to find the coordinates of the player if the Player Object is not null.
        {
            Player = playerObj.transform;
        }
        else
        {
            Player = null;
        }
    } 
}


