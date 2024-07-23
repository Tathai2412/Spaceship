using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserScript : MonoBehaviour
{
    public float speed = 5f;

    public float deactive_Timer = 3.5f;
    
    void Start()
    {
        Invoke("DeactiveLaser", deactive_Timer);
    }

    void Update()
    {
        MoveLaser();
    }

    void MoveLaser()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;

        transform.position = temp;
    }

    void DeactiveLaser()
    {
        gameObject.SetActive(false);
    }
}
