using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 moveDirection;


    void Start()
    {
        Destroy(gameObject, 7f);
    }

    void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * Time.deltaTime;
        }
    }

    public void SetMovementDirection(Vector3 direction)
    {
        moveDirection = direction;
    }
}
