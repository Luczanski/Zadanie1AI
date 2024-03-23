using System.Collections;
using UnityEngine;

public class Parabole : MonoBehaviour
{
    public Vector3 target;
    public float speed = 1.0f;
    public float height = 1f;
    
    public void SetTargetAndStartFlying(Vector3 targetPos)
    {
        target = targetPos;
        speed += (Vector3.Distance(transform.position, target)/5);
        StartCoroutine(SheelFly());
    }
    
    private IEnumerator SheelFly()
    {

        Vector3 startPosition = transform.position;

        float distance = Vector3.Distance(startPosition, target);
        height *= distance;

        
        float a = 0f;
        float b = speed / distance;

        bool isfly = true;

        while (isfly)
        {
            a = Mathf.Min(a + Time.deltaTime * b, 1.0f);

            float parabola = 1.0f - 4.0f * (a - 0.5f) * (a - 0.5f);

            Vector3 nextPos = Vector3.Lerp(startPosition, target, a);
            nextPos.y += parabola * height;

            transform.LookAt(nextPos, transform.forward);
            transform.position = nextPos;

            if (a == 1.0f)
            {
                isfly = false;
            }


            yield return null;
        }

        Destroy(gameObject);
    }
}
