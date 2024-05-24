using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject target;
    public float moveSpeed; 
    private Vector3 targetPosition; 
    public bool isTargeting;

    // Start is called before the first frame update
    void Start()
    {
        isTargeting = true;
        SoundManager.instance.PlayBGM(1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ����� �ִ��� üũ
        if(isTargeting && target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
