using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZones : MonoBehaviour
{
    //The amount of health of the safezone
    int giveHealth = 1;

    /// <summary>
    /// Checks for colliders entering the trigger
    /// </summary>
    /// <param name="other">the collider of the other gameobject</param>
    private void OnTriggerEnter(Collider other)
    {
        //if a player enters the safezone, it uses the heal method of the player
        //and sets the inSafeZone variable to true
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Heal(giveHealth);
            player.inSafeZone = true;
        }
    }

    /// <summary>
    /// Checks for colliders staying in the trigger
    /// </summary>
    /// <param name="other">the collider of the other gameobject</param>
    private void OnTriggerStay(Collider other)
    {
        //heals the player
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Heal(giveHealth);

        }
    }

    /// <summary>
    /// Checks for colliders exiting the trigger
    /// </summary>
    /// <param name="other">the collider of the other gameobject</param>
    private void OnTriggerExit(Collider other)
    {
        //Stops healing the player, and sets the inSafeZone variable to false
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Heal(0);
            player.inSafeZone = false;
        }
    }
}
