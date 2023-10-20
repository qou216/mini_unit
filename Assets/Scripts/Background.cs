using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        //30프레임 60프레임 지원 성능 상관 없이 할 수 있게 하는 거 : Time.deltaTime
        if (transform.position.y < -10) {
            transform.position += new Vector3(0,10*2f,0);

        }
    }
}
