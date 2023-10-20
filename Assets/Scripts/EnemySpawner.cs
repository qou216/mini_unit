using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies; //프리팹 저장용 변수 
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {   
       startEnemyRoutine();
    }
    
    void startEnemyRoutine(){
        //코루틴 : 메소드 (원하는 만큼 시간을 정해줄수 있다. 몇초 기다렸다가 해주는 메소드)
        StartCoroutine("EnemyRoutine");//코루틴 시작하기 위한 것 startcoroutine ("메소드 이름 적기")
        //몇초 기다리더라도 다른 동작 수행 가능 - 코루틴
    }
    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(3f);
        float moveSpeed = 5f;
        //3초 정도 기다렸다가 실행
        int spawnCount = 0 ;
        int enemiyIndex = 0 ;

        while(true){
            foreach(float posX in arrPosX){ 
                SpawnEnemy(posX, enemiyIndex, moveSpeed);
            }

            spawnCount++;
            if(spawnCount % 10 == 0){
                enemiyIndex += 1;
                moveSpeed += 2; // 속도가 점점 빨라지도록
            }

            yield return new WaitForSeconds(spawnInterval);        
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed){
        Vector3 spawPos = new Vector3(posX,transform.position.y,transform.position.z);
        
        if (UnityEngine.Random.Range(0,5) == 0){
            index += 1;
        }
        {

        }
        if (index >= enemies.Length){
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index],spawPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
