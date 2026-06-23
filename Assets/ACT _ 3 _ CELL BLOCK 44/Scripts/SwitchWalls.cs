using System.Collections.Generic;
using UnityEngine;

public class SwitchWalls : MonoBehaviour
{

    [System.Serializable]
    public class WallPair
    {
        public string wallName;
        public GameObject solidMesh;
        public GameObject holeMesh;
    }

    [Header("Assign Side Walls Only")]
    [Tooltip("front, back, left, right")]
    public List<WallPair> sideWalls = new List<WallPair>();

    [Header("Timing Settings")]
    public float activeHoleDuration = 3f;

    private int currentActiveHoleIndex = -1;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //all solid ones are visible, the hole ones should not be
        ResetAllWalls();

        //pick first random wall
        PickRandomHoleWall();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // has 3  seconds passed
        if (timer >= activeHoleDuration)
        {
            timer = 0f;
            PickRandomHoleWall();
        }
    }

    void PickRandomHoleWall()
    {
        //go back to being a solid wall, before picking anew one with a hole in it
        ResetAllWalls();

        if (sideWalls.Count == 0) return;

        //pick random index from 4 side walls
        int nextHoleIndex = Random.Range(0, sideWalls.Count);

        //-----------FIX: Wall just stays the same, porbably just picks the same one again
        //prevent same wall from picking itself twice

        if (sideWalls.Count > 1)
        {
            while (nextHoleIndex == currentActiveHoleIndex)
            {
                nextHoleIndex = Random.Range(0, sideWalls.Count);
            }
        }

        currentActiveHoleIndex = nextHoleIndex;
        // swap
        sideWalls[currentActiveHoleIndex].solidMesh.SetActive(false);
        sideWalls[currentActiveHoleIndex].holeMesh.SetActive(true);

    }

    void ResetAllWalls()
    {
        foreach (var wall in sideWalls)
        {
            wall.solidMesh.SetActive(true);
            wall.holeMesh.SetActive(false);
        }
    }

}
