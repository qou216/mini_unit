using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

    public void SetMoveSpeed(float moveSpeed){
        this.moveSpeed = moveSpeed;// 인자와 변수 값이 이름이 같아서 this를 씀.
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y < minY){
           Destroy(gameObject);
        }
    }
}
