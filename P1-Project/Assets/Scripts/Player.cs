using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{

    //Health properties for the player
   [SerializeField]
    HealthBar healthBar;
    //public int currentLevel = 1;
    int currentHealth;
    int minHealth;
    int maxHealth;

    Rigidbody rb;

    float height = 1f;
    RaycastHit Hit;

    int trashPickedUp;

    //Getting a reference to the current scene
    Scene activeScene;
    //TThe build index of the current scene
    int sceneNumber;


    bool isDead;
    // Start is called before the first frame update
    void Start()
    {

        activeScene = SceneManager.GetActiveScene();
        sceneNumber = activeScene.buildIndex;

        maxHealth = 100;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FaceForward();
        IsDead();
        if (isDead)
        {
            Restartlvl();
        }

        PickUp();

    }


    /// <summary>
    /// If we are moving on the x or z axis, the forward position changes
    /// </summary>
    void FaceForward()
    {
        Vector3 vel = rb.velocity;
        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }
    }
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    void Heal(int healing)
    {
        currentHealth += healing;
        healthBar.SetHealth(currentHealth);
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
//    private void OnCollisionEnter(Collision other)
 //   {
  //      Debug.Log("Collisiondetected");
  //      if (other.gameObject.CompareTag("Enemy"))
    //    {
     //       Debug.Log(currentHealth);
     //       int dmg = other.gameObject.GetComponent<Enemy>().dmg;
      //      TakeDamage(dmg);

     //   }
 //   }

    private void TrashPickUp()
    {
        trashPickedUp++;
        Destroy(Hit.transform.gameObject);
    }

    void PickUp()
    {
        float distanceToTrash = 5f;
        if (Physics.SphereCast(rb.position, height, transform.forward, out Hit, distanceToTrash))
        {
            if (Hit.transform.gameObject.CompareTag("Trash"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TrashPickUp();
                }
            }
        }
    }
}