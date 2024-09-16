
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public enum GROUP_TYPE { NORMAL, CHASER, SLOW, HIGH, ADV }

    public GROUP_TYPE group_type;
    public GROUP_TYPE group_type_next;

    public GameObject mobgroup;
    public Item[] enemyPrefabs;       // The enemy prefab to instantiate.
    public float spawnRate = 1.2f;         // Rate at which enemies will spawn.
    [SerializeField]
    private float nextSpawnTime = 0f;    // To control the timing of the spawns.

    public float gameWorldWidth = 20f;   // Width of the game world.
    public float gameWorldHeight = 10f;  // Height of the game world.
    [SerializeField] Player player;

    public float fLeveling = 0;
    public void Start()
    {


        mobwaveStart();
        //        if (null == player)    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PLallrumble>();

        fLeveling = 0;
    }

    public void mobwaveStart()
    {
        this.group_type = GROUP_TYPE.NORMAL;
        this.group_type_next = GROUP_TYPE.NORMAL;

    }

    // public void FixedUpdate() {   this.mobAppearControl(); }        
    public float fGametime = 0f;
    public float fMobSpawnDelay = 3;

    public float Spawn_HorizontalLeft = -8;
    public float Spawn_HorizontalRight = 8;
    public float Spawn_VerticalBottom = 0; //Spawn_15VerticalBottom
    public float Spawn_VerticalTop = 16.5f; //Spawn_15VerticalTop


    Vector2[] spawnPoints0 = new Vector2[4];
    Vector2[] spawnPoints1;

    public void Update()
    {
        fGametime = Time.time;

        if (fGametime >= nextSpawnTime)
        {
            spawnPoints0 = new Vector2[4];

            spawnPoints0[0] = new Vector2(Spawn_HorizontalLeft, Random.Range(Spawn_VerticalBottom, Spawn_VerticalTop) + this.transform.position.y);
            spawnPoints0[1] = new Vector2(Spawn_HorizontalRight, Random.Range(Spawn_VerticalBottom, Spawn_VerticalTop) + this.transform.position.y);
            spawnPoints0[2] = new Vector2(Random.Range(Spawn_HorizontalLeft, Spawn_HorizontalRight) + this.transform.position.x, Spawn_VerticalTop);
            spawnPoints0[3] = new Vector2(Random.Range(Spawn_HorizontalLeft, Spawn_HorizontalRight) + this.transform.position.x, Spawn_VerticalBottom);

            Vector2 lv1spawnPosition = spawnPoints0[Random.Range(0, spawnPoints0.Length)];


            // ... 기존의 코드 ...

            if (fGametime < 10f) // 처음 10초 동안
            {
                // footman 생성
                Instantiate(enemyPrefabs[0], lv1spawnPosition, Quaternion.identity);
            }
            else if (fGametime > 10f && fGametime < 40.0f) // 10초가 지난 후와 40초 사이에  
            {
                // wingman을 Boundary의 맨 아래 좌우에서 생성
                float boundaryBottomY = Spawn_VerticalBottom; // "Boundary"의 맨 아래 y 좌표를 적절히 설정해야 합니다.
                float playerY = player.transform.position.y; // ballrumble의 현재 y 좌표
                Vector2 wingmanSpawnPosition = new Vector2(
                    Random.value > 0.5f ? Spawn_HorizontalLeft : Random.Range(Spawn_HorizontalLeft, Spawn_HorizontalRight),
                    Mathf.Min(boundaryBottomY, playerY + Random.Range(1.9f, 5.1f))
                );
                Instantiate(enemyPrefabs[1], wingmanSpawnPosition, Quaternion.identity); // enemyPrefabs[1]이 wingman이라고 가정합니다.
            }
            else
            { }

            nextSpawnTime = fGametime + 1f / spawnRate;
        }
    }

}

