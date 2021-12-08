using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalZones : MonoBehaviour
{
    //The amount of health of the safezone
    int dmg = 1;

    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    /// <summary>
    /// Checks for colliders entering the trigger
    /// </summary>
    /// <param name="other">the collider of the other gameobject</param>
    private void OnTriggerEnter(Collider other)
    {
        //if a player enters the chemicalZones, it uses the TakeDamage method of the player
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
        }
    }

    /// <summary>
    /// Checks for colliders staying in the trigger
    /// </summary>
    /// <param name="other">the collider of the other gameobject</param>
    private void OnTriggerStay(Collider other)
    {
        //does damage to the player
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
        }
    }
}