using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    [SerializeField]
    GameObject cleanCoral;
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

    bool showRepairText = false;
    public int coralsCleansed;

    bool showUnstuckText = false;

    bool showInformText = false;
    public int fishInformed;

    //Getting a reference to the current scene
    Scene activeScene;
    //The build index of the current scene
    int sceneNumber;

    //is true if the player is in a safezone else false
    public bool inSafeZone = false;

    //true if the player's health reaches 0 else false
    bool isDead;



    void Start()
    {
        FindObjectOfType<AudioManager>().Play("UnderWater");
        activeScene = SceneManager.GetActiveScene();
        sceneNumber = activeScene.buildIndex;
        maxHealth = 500;
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
        if (currentHealth < minHealth)
        {
            return true;
        }
        else return false;

    }

    /// <summary>
    /// Go til gameover scene
    /// </summary>
    void Restartlvl()
    {
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    /// increases the trashPickedUp variable, destorys the gameobject and displays the amount of trash picked up
    /// </summary>
    private void TrashPickUp()
    {
        trashPickedUp++;
        Destroy(Hit.transform.gameObject);
        FindObjectOfType<AudioManager>().Play("Trash");
    }

    private void CleanseCorals()
    {
        coralsCleansed++;
        Vector3 pos = Hit.transform.position;
        Quaternion quaternion = Hit.transform.rotation;
        GameObject coral = Hit.transform.gameObject;
        Destroy(coral);
        Instantiate(cleanCoral, pos, quaternion);
    }

    /// <summary>
    /// checks if a gameobject with the tag "Trash" is close to you, and in front of you,
    /// if the r key is pressed the TrashPickedUp method runs
    /// </summary>
    void PickUp()
    {
        float distanceToHit = 5f;
        if (Physics.SphereCast(rb.position, height, transform.forward, out Hit, distanceToHit))
        {
            if (Hit.transform.gameObject.CompareTag("Trash"))
            {
                showTrashText = true;

                if (Input.GetKeyDown(KeyCode.R))
                {
                    TrashPickUp();
                }
            }  else if (Hit.transform.gameObject.CompareTag("Coral"))
            {
                showRepairText = true;

                if (Input.GetKeyDown(KeyCode.R))
                {
                    CleanseCorals();
                }
            } else if (Hit.transform.gameObject.CompareTag("SafeFish"))
            {
                if (Hit.transform.GetComponent<FishFollow>().stuckInTrash == true)
                {
                    showUnstuckText = true;
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Hit.transform.GetComponent<FishFollow>().stuckInTrash = false;
                    }
                }   
            }
            else if (Hit.transform.gameObject.CompareTag("Inform"))
            {
                if(Hit.transform.GetComponent<InformFish>().beingInformed == false)
                {
                        showInformText = true;
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Inform();
                    }
                }
            }
        }
        else
        {
            showTrashText = false;
            showRepairText = false;
            showUnstuckText = false;
            showInformText = false;
        }

    }

    private void Inform()
    {
        fishInformed++;
        Hit.transform.GetComponent<InformFish>().beingInformed = true;
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
                 Screen.height / 2, 200, 100), "Tryk R for at samle affald op!");
        }

        if (showRepairText)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75,
                 Screen.height / 2, 200, 100), "Tryk R to for at reparere korallen!");
        }

        if (showUnstuckText)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75,
                 Screen.height / 2, 200, 100), "Tryk R for at redde Bobbles!");
        }
        if (showInformText)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75,
                 Screen.height / 2, 200, 100), "Tryk R for at informere andre!");
        }
    }
}