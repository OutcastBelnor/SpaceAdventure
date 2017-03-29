using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject [] SpawnPrefabs;

    [SerializeField]
    private GameObject PlayerPrefab;

    [SerializeField]
    private Arena Arena;

    [SerializeField]
    private float TimeBetweenSpawns;

    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject escapeMenu;
    [SerializeField]
    private GameObject gameOverMenu;

    private List<GameObject> mObjects;
    private GameObject mPlayer;
    private float mNextSpawn;

    void Awake()
    {
        mPlayer = Instantiate(PlayerPrefab);
        mPlayer.transform.parent = transform;
    }

    void Start()
    {
        Arena.Calculate();
        Time.timeScale = 1;
    }

    void Update()
    {
        if (mPlayer != null)
        {
            mNextSpawn -= Time.deltaTime;
            if (mNextSpawn <= 0.0f)
            {
                if (mObjects == null)
                {
                    mObjects = new List<GameObject>();
                }

                int indexToSpawn = Random.Range(0, SpawnPrefabs.Length);
                GameObject spawnObject = SpawnPrefabs[indexToSpawn];
                GameObject spawnedInstance = Instantiate(spawnObject);
                spawnedInstance.transform.parent = transform;
                mObjects.Add(spawnedInstance);
                mNextSpawn = TimeBetweenSpawns;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    gameUI.SetActive(true);
                    escapeMenu.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    gameUI.SetActive(false);
                    escapeMenu.SetActive(true);
                }
            }
        }
        else
        {
            EndGame();
        }
    }

    private void BeginNewGame()
    {
        if (mObjects != null)
        {
            for (int count = 0; count < mObjects.Count; ++count)
            {
                Destroy(mObjects[count]);
            }
            mObjects.Clear();
        }

        mPlayer.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        mNextSpawn = TimeBetweenSpawns;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        gameUI.SetActive(false);
        gameOverMenu.SetActive(true);
    }
}
