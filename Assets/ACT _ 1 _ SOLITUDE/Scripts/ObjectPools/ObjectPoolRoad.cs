using System.Runtime.CompilerServices;
using NUnit.Framework;  
using UnityEngine;

public class ObjectPoolRoad : MonoBehaviour
{


    [Header("Movement Settings")]
    public float scrollSpeed = 10f;
    public float segmentLength = 20f;
    public int totalSegments = 5;

    private float recycleThreshold;
    private float resetOffset;

    private void Start()
    {
        //z position where the piece is fully offscreen
        recycleThreshold = Camera.main.transform.position.z - (segmentLength * 1.5f);

        //total distance to snap back in line again
        resetOffset = segmentLength * totalSegments;
    }

    private void Update()
    {
        //move  back to the bottom of the screen
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime, Space.World);

        //once it passes the bottom threshold it needs to come back
        //if it meets a certain point, go back

        if (transform.position.z < recycleThreshold)
        {
            transform.position += new Vector3(0, 0, resetOffset);
        }

    }


}
//{

//    [SerializeField] private bool _addToDontDestroyOnLoad = false;

//    private GameObject _emptyHolder;

//    private static GameObject _road;

//    private static Dictionary<GameObject, ObjectPool<GameObject>> _objectPools;
//    private static Dictionary<GameObject, GameObject> _cloneToPrefabMap;

//    public enum PoolType
//    {
//        GameObject
//    }
//    public static PoolType PoolingType;

//    private void Awake()
//    {
//        _objectPools = new Dictionary<GameObject, ObjectPool<GameObject>>();
//        _cloneToPrefabMap = new Dictionary<GameObject, GameObject>();

//        SetupEmpties();
//    }

//    private void SetupEmpties()
//    {
//        _emptyHolder = new GameObject("Object Pools");

//        if (_addToDontDestroyOnLoad)
//            DontDestroyOnLoad(_emptyHolder.transform.root),

//    }

//    private static void CreatePool(GameObject prefab, Vector3 pos, Quaternion rot, PoolType poolType = PoolType.GameObject)
//    {
//        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
//            createFunc: () => CreateObject(prefab, pos, rot, poolType),
//            actionOnGet: OnGetObject,
//            actionOnRelease: OnReleaseObject,
//            actionOnDestroy: OnDestroyObject
//            );

//        _objectPools.Add(prefab, pool);

//    }

//    private static GameObject CreateObject(GameObject prefab, Vector3 pos, Quaternion rot, PoolType pooltype = PoolType.GameObject)
//    {
//        prefab.SetActive(false);

//        // --------------------------------- LOOK THIS UP -----------------------------------------------
//        GameObject obj = Instantiate(prefab, pos, rot);
//        //WHY instantiate if obj pooling is meant to be a solution to NOT instantiate
//        //-------------------------------------------------------------------------------------------
//        prefab.SetActive(true);

//        //I have one road, MAYBE DELETE THIS LATER
//        GameObject parentObject = SetParentObject(poolType);
//        obj.transform.SetParent(parentObject.transform);

//        return obj;

//    }

//    private static void OnGetObject(GameObject obj)
//    {
//        //rotation / other logic for when obj is present
//    }

//    private static void OnReleaseObject(GameObject obj)
//    {
//        //obj is back in the pool so needs to be deactivated
//        obj.SetActive(false);

//    }//do i really need something active and inactie when the road is only as many pieces are the camera can actually see?
//    // if minimizing having wasteful stuff that doesn't need to be there, then this doesn't need to be there??????

//    private static void OnDestroyObject(GameObject obj)
//    {
//        if(_cloneToPrefabMap.ContainsKey(obj))
//        {
//            _cloneToPrefabMap.Remove(obj);
//        }
        

//    }

//    private static GameObject SetParentObject(PoolType poolType)
//    {
//        switch (poolType)
//        {
//            case PoolType.GameObject:

//                return _gameObjectsEmpty;

//            default: 
//                return null;
//        }
//    }

//    private static T SpawnObject<T>(GameObject objectToSpawn, Vector3 spawnPos, Quaternion spawnRotation, PoolType poolType = PoolType.GameObject) where T : Object
//    {
//        if (!_objectPools.ContainsKey(objectToSpawn))
//        {
//            CreatePool(objectToSpawn, spawnPos, spawnRotation, poolType);
//        }

//        //this is what checks pool, and reactivates. 
//        //but if there's nothing in the pool, it will instantiate one to use
//        GameObject obj = _objectPools[objectToSpawn].Get();
//    }

//}
