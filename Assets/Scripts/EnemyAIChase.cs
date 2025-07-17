using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAIChase : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public float distanceBetween;
    private float distance;
    float Xaxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Xaxis = Input.GetAxisRaw("Horizontal") * speed;
        distance = Vector2.Distance(transform.position, Player.position);
        Vector2 direction = Player.position - transform.position;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
        }


        if (Xaxis > 0)
        {
            gameObject.transform.localScale = new Vector3(1.499631f, 1.499631f, 1);
        }
        else if (Xaxis < 0)
        {
            gameObject.transform.localScale = new Vector3(-1.499631f, 1.499631f, 1);
        }

    }
}
