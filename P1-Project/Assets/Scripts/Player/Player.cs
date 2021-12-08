using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
   //Health properties for the player
   [SerializeField]
    HealthBar healthBar;
    int currentHealth;
    int minHealth;
    int maxHealth;

    //reference to the rigidbody of this gameobject
    Rigidbody rb;

    //Reference to the resources
   [SerializeField]
    Resources resource;

    //information for the raycast
    float height = 1f;
    RaycastHit Hit;

    //properties for trash
    bool showTrashText = false;
    public int trashPickedUp;

    //Getting a reference to the current scene
    Scene activeScene;
    //The build index of the current scene
    int sceneNumber;

    //is true if the player is in a safezone else false
    public bool inSafeZone = false;

    //true if the player's health reaches 0 else false
    bool isDead;
    // Start is called before the first frame update

    void Start()
    {

        activeScene = SceneManager.GetActiveScene();
        sceneNumber = activeScene.buildIndex;
        resource.SetTrashCollectedText(trashPickedUp);
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            Restartlvl();
        }
      PickUp();

    }

    /// <summary>
    /// Decreases the health property of the player and updates the healthbar 
    /// </summary>
    /// <param name="dmg"> The amount of damage the health decreases by</param>
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    /// <summary>
    /// Increases the health property and updates the healthbar
    /// </summary>
    /// <param name="healing">The amount of health the health increases by</param>
    public void Heal(int healing)
    {
        currentHealth += healing;
        healthBar.SetHealth(currentHealth);
    }

    /// <summary>
    /// True if current health is less than the minimum amount of health
    /// </summary>
    bool IsDead()
    {
        if (currentHealth <= minHealth)
        {
            return true;
        }
        else return false;

    }

    /// <summary>
    /// Loads the current scene again
    /// </summary>
    void Restartlvl()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    /// <summary>
    /// increases the trashPickedUp variable, destorys the gameobject and displays the amount of trash picked up
    /// </summary>
    private void TrashPickUp()
    {
        trashPickedUp++;
        Destroy(Hit.transform.gameObject);
        resource.SetTrashCollectedText(trashPickedUp);
    }

    /// <summary>
    /// checks if a gameobject with the tag "Trash" is close to you, and in front of you,
    /// if the r key is pressed the TrashPickedUp method runs
    /// </summary>
    void PickUp()
    {
        float distanceToTrash = 5f;
        if (Physics.SphereCast(rb.position, height, transform.forward, out Hit, distanceToTrash))
        {
            if (Hit.transform.gameObject.CompareTag("Trash"))
            { 
                showTrashText = true;
            
                if (Input.GetKeyDown(KeyCode.R))
                {
                    TrashPickUp();
                }
            }

        }
        else showTrashText = false;
    }


    /// <summary>
    /// Shows text on screen
    /// </summary>
    private void OnGUI()
    {
        //if showTrashText is true, a GUI.Label appears  on screen showing which button to
        //press to pickup trash
        if (showTrashText)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75,
                 Screen.height / 2, 200, 100), "Press R to pick up trash!");
        }
    }
}