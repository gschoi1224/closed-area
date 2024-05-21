using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightController : MonoBehaviour
{
    private PlayerMove Player; 
    private Vector2 vector;
    private Quaternion rotation; 
    void Start()
    {
        Player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
        vector.Set(Player.animator.GetFloat("DirX"), Player.animator.GetFloat("DirY"));
        if (vector.x == 1f)
        {
            
            rotation = Quaternion.Euler(0, 0, -90);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(0.5f, 1f, 0f);

        }
        else if (vector.x == -1f)
        {
            rotation = Quaternion.Euler(0, 0, 90);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(-0.5f, 1f, 0f);
        }
        else if (vector.y == 1f)
        {
            rotation = Quaternion.Euler(0, 0, 0);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(-0.45f, 0.87f, 0f);
        }
        else if (vector.y == -1f)
        {
            rotation = Quaternion.Euler(0, 0, 180);
            this.transform.rotation = rotation;
            this.transform.localPosition = new Vector3(-0.36f, 1.015f, 0f);
        }
        
    }
}
