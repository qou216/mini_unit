using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
        //Destroy 메소드 :예약 삭제 / 뭐를 삭제할건지, 1초 뒤에(딜레이)
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed*Time.deltaTime ;
    }
}
