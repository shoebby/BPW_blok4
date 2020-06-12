using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrayEnListNotes : MonoBehaviour
{
    public GameObject[] gameObjectArray; //array, for multiple objects that are created on awake/start
    public GameObject cube;
    public List<GameObject> gameObjectsList; //

    private Animator[] animators; //specify the component to make an array of that specific component

    public int activeArray;
    public int totalArray;
        
    void Start()
    {
        totalArray = gameObjectArray.Length;

        gameObjectArray = GameObject.FindGameObjectsWithTag("ArrayItem");

        animators = GameObject.FindObjectsOfType<Animator>(); //add all matching components in the scene to the array


        for (int i = 0; i < gameObjectArray.Length; i++) //for loop for arrays
        {

        }

        for (int i = 0; i < animators.Length; i++) //destroy animators
        {
            Destroy(animators[i].gameObject);
        }

        for (int i = 0; i < gameObjectsList.Count; i++) //for loop for lists
        {

        }
    }

    void Update()
    {
        if (activeArray == totalArray)
        {
            //do something when the array maximum is reached
        }
        
        GameObject go = Instantiate(cube, transform.position, transform.rotation);
        gameObjectsList.Add(go); //add (instantiated) object to list during runtime
    }
}
