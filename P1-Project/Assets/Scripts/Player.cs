using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int currentHealth = 10;
    int minHealth;
    int maxHealth = 100;

    Scene activeScene;
    int sceneNumber;


    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        sceneNumber = activeScene.buildIndex;

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
        if (isDead)
        {
            Restartlvl();
        }
    }

    void TakeDamage (int dmg)
    {
        currentHealth -= dmg;
    }

    void IsDead()
    {
        if (currentHealth < minHealth)
        {
            isDead = true;
        }
        else isDead = false;

    }

    void Restartlvl()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collisiondetected");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(currentHealth);
            int dmg = other.gameObject.GetComponent<Enemy>().dmg;
            TakeDamage(dmg);

        }
    }



}
