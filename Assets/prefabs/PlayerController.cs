using UnityEngine;
using UnityEngine.UI;  // ✅ 必须有这个
using UnityEngine.SceneManagement;  // 👈 必须加这个

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private int score = 0;

    private Rigidbody rb;

    public Text scoreText;  // ✅ 是 UnityEngine.UI.Text 类型
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        UpdateScore();
        winText.gameObject.SetActive(false);  // 先隐藏胜利文本
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 10)
        {
            winText.text = "You Win!";
            winText.gameObject.SetActive(true);
        }
    }

    void Update()
{
    // 如果小球掉出地图（Y 轴太低），重启当前场景
    if (transform.position.y < -5f)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
}
