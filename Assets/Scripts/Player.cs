using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // private 은 조절 못하나 SerializeField 를 사용하면 유니티 창에서 나타남으로 값 변경 가능!
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;
    //프리팹 필요할때마다 그때그때만들어서 사용하게 해줌. prefabs 에 weapon 있음. 프리팹 담을 변수.
    [SerializeField]
    private Transform shootTransform;
    // 위치 회전 값 바로 쓸수 있음. 
    [SerializeField]
    private float shootInterval = 0.05f;//float 은 더 정확하게 하기 위해 f를 붙여주면 좋다!
    private float lastshotTime = 0f;

    

    // Update is called once per frame
    void Update()
    {   // 키보드로 조절(상, 하, 좌, 우)
        // float horizontalInput = Input.GetAxisRaw("Horizontal");//좌우 (키보드) 대소문자 주의!
        // //float verticalInput = Input.GetAxisRaw("Vertical");//상하 (키보드)
        // Vector3 moveto = new Vector3(horizontalInput,0f,0f);  // (x,y,z 값)
        // transform.position += moveto * moveSpeed * Time.deltaTime;

    //좌우로만 움직이게 하는 경우
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime,0,0);
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position -= moveTo;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += moveTo;
        }

        Shoot();
    }
    void Shoot(){//메소드 void => 반환값 없이 동작 끝나는 메소드 
        if(Time.time - lastshotTime >shootInterval){
            //Time.time => 게임이 시작된 이후로 현재까지 흐른 시간 - 지금 시간 > 0.05 이면
            Instantiate(weapon,shootTransform.position,Quaternion.identity);
            //어떤 오브젝트인지, 발사되는 위치값, Quaternion 회전 없이 
            lastshotTime = Time.time;
        }
    }
}
