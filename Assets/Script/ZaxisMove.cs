using UnityEngine;

public class ZaxisMove : MonoBehaviour
{
    //5�� �̵��� ���ǵ尡 ������ �̵��ϰ� ������� ������Ʈ(z�� �̵�)

    public float Speed = 3.0f;
    public float Timer = 5.0f;

    private void Update()
    {
        ZMove();
    }

    public void ZMove()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);

        Timer -= Time.deltaTime;
        {
            if(Timer < 0)
            {
                Destroy(gameObject);            }
        }
    }
}
