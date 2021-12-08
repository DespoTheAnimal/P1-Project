using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fish;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject fish4;
    public GameObject fish5;

    List<GameObject> instantiationList = new List<GameObject>();

    Vector3 min;
    Vector3 max;

    float _xAxis;
    float _yAxis;
    float _zAxis;

    private Vector3 _randomPosition;

    GameObject instantiateOBJ;



    // Start is called before the first frame update
    void Start()
    {
        SetRange();
    }

    // Update is called once per frame
    void Update()
    {
        SetPostion();
        randomfish();
       

    }

    private void LateUpdate()
    {
        InstantiateObject();
    }
    /// <summary>
    /// sets a _randomposition between the min and max values
    /// </summary>
    void SetPostion()
    {
        _xAxis = (Random.Range(min.x, max.x));
        _yAxis = (Random.Range(min.y, max.y));
        _zAxis = (Random.Range(min.z, max.z));

        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
  
    }

    /// <summary>
    /// sets the min and max values
    /// </summary>
    void SetRange()
    {
        min = new Vector3(165, 20, 230);

        max = new Vector3(168, 90, 232);
    }

    /// <summary>
    /// checks if a new gameobject can instantiate
    /// </summary>
    /// <returns></returns>
    bool canInstantiate()
    {
        if (instantiationList.Count < 1000)
        {
            return true;
        }
        else return false; 
    }

    /// <summary>
    /// spawns a random gameobject depending on the value
    /// </summary>
    void randomfish()
    {
        int rnd = Random.Range(0, 5);

        switch (rnd)
        {
            case 0:
                instantiateOBJ = fish;
                break;
            case 1:
                instantiateOBJ = fish2;
                break;
            case 2:
                instantiateOBJ = fish3;
                break;
            case 3:
                instantiateOBJ = fish4;
                break;
            case 4:
                instantiateOBJ = fish5;
                break;
            default:
                break;
        }
        
    }
    
    private void InstantiateObject()
    {
        if (canInstantiate())
        {
            instantiateOBJ.tag = "friendlyFish";
            Instantiate(instantiateOBJ, _randomPosition, Quaternion.identity);
            instantiationList.Add(instantiateOBJ);
        }
    }
}
