using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Quaternion = System.Numerics.Quaternion;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    [SerializeField] private float rollSpeed = 5f;
    
    [SerializeField] private float deactiveTimer = 3.5f;
    
    void Start()
    {
        Invoke(nameof(DeactivateAsteroid), deactiveTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Roll();
    }

    void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= moveSpeed * Time.deltaTime;
        
        transform.position = pos;
    }

    void Roll()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += rollSpeed * Time.deltaTime;
        
        transform.rotation = UnityEngine.Quaternion.Euler(rot);
    }
    
    void DeactivateAsteroid()
    {
        gameObject.SetActive(false);
    }
}
