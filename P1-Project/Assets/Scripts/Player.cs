using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int hp = 10;
    int minHp;
    int maxHp;

    Rigidbody rb;

    float height = 1f;

    Scene activeScene;
    int sceneNumber;

    public GameObject UI;

    int trashPickedUp;
    RaycastHit Hit;


    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        sceneNumber = activeScene.buildIndex;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
        if (isDead)
        {
            Restartlvl();
        }

        PickUp();
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

    /// <summary>
    /// The player gets more trash and the trash object is destroyed when pickedup
    /// </summary>
    void TrashPickUp()
    {
        trashPickedUp++;
        Destroy(Hit.transform.gameObject);

        
    }

    /// <summary>
    /// If the player is close to trash it can pick it up
    /// </summary>
    void PickUp()
    {
        float DistanceToTrash = 5f;
        if (Physics.SphereCast(rb.position, height, transform.forward, out Hit, DistanceToTrash))
        {
            Debug.Log("Sees object");
            if (Hit.transform.gameObject.CompareTag("Trash"))
            {
                Debug.Log("Sees trash");
                if (Input.GetKeyDown(KeyCode.E)){
                    TrashPickUp();
                    UI.GetComponent<Points>().SetTrashPickUp(trashPickedUp);
              
                }
            }
        }
    }


}
