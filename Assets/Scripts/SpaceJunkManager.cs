using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// references prefabs, adds and removes junk objects
public class SpaceJunkManager : MonoBehaviour
{

    public BoxCollider2D [] perimeterContainers;
    public GameObject [] junkPrefabArray;
    public GameObject junkPrefab;
    public int originIndex = 0;
    public int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        // begin looping
        StartCoroutine (JunkCreatorLoop(0.2f));
    }

    IEnumerator JunkCreatorLoop(float wait)
    {
        while (true)
        {
            // pause for 1 sec before adding new space junk
            yield return new WaitForSeconds(wait);
            CreateNewSpaceJunk();
        }
    }

    void CreateNewSpaceJunk()
    {
        if (originIndex == 0){
            targetIndex = 2;
        }
        else if (originIndex == 1){
            targetIndex = 3;
        }
        else if (originIndex == 2){
            targetIndex = 0;
        }
        else{
            targetIndex = 1;
        }

        Vector3 startPos = GetSpawnPosition(perimeterContainers[originIndex]);
        Vector3 targetPos = GetSpawnPosition(perimeterContainers[targetIndex]);

        // get the spawn rotation
        Quaternion spawnRotation = new Quaternion ();
        // no random rotation
        spawnRotation.eulerAngles = new Vector3 (0f, 0f, 0f);

        // choose random space junk from array and assign to junkPrefab object
        int junkIndex = Random.Range(0,4); // adjust based on how many junk prefabs using
        junkPrefab = junkPrefabArray[junkIndex];

        // Instantiate prefab at spawn position
        GameObject spaceJunkObj = (GameObject) Instantiate (junkPrefab, startPos, spawnRotation);

        // reference script
        SpaceJunk junkScript = spaceJunkObj.GetComponent<SpaceJunk> ();
        // call init on script
        junkScript.Init(startPos, targetPos);

        spaceJunkObj.transform.parent = gameObject.transform;

        // originIndex = (originIndex+1) % 4;
        originIndex = Random.Range(0,4); // no longer in clockwise rotation

    }
    Vector3 FindPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y), 0);
    }

    Vector3 GetSpawnPosition(BoxCollider2D collider)
    {
        // get position within collider
        Vector3 spawnPositionRaw = FindPointInBounds(collider.bounds);
        // for testing
        Vector3 spawnPosition = new Vector3 (spawnPositionRaw.x, spawnPositionRaw.y, spawnPositionRaw.z);
        return spawnPosition;
    }
}
