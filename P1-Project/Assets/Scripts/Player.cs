using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int hp = 10;
    int minHp;
    int maxHp;

    Scene activeScene;
    int sceneNumber;

    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        sceneNumber = activeScene.buildIndex;
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
        hp -= dmg;
    }

    void IsDead()
    {
        if (hp < minHp)
        {
            isDead = true;
        } else isDead = false;

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
            Debug.Log(hp);
            int dmg = other.gameObject.GetComponent<Enemy>().dmg;
            TakeDamage(dmg);

        }
    }



}
