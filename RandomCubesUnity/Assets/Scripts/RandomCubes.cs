/****
 * Created By: Stu Dent
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawn multiple cubes prefabs into to the scene.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; // Total number of cubes instatied
    
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes




    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instatates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to the number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube instance

        gObj.name = "Cube" + numberOfCubes; //name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); //creates a new random color
        gObj.GetComponent<Renderer>().material.color = randColor; //assigns random color to game object


        gObj.transform.position = Random.insideUnitSphere; //random location inside a spheare radius of 1 out from 0,0,0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>();//list for removed objects

        foreach(GameObject goTemp in gameObjectList){
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; //scale multipled by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if(scale <= 0.1f)

        }//end foreach(GameObject goTemp in gameObjectList)

        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp); //destorys game object

        }//end foreach(GameObject goTemp in removeList)

        Debug.Log(removeList.Count); //debugs the remove list

    }
}
