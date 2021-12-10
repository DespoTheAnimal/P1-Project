using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMines : MonoBehaviour
{

    Player player;

    int dmg = 250;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
        }
    }
}
