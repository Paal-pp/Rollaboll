using UnityEngine;
using UnityEngine.UI;  // ✅ 必须有这个
using UnityEngine.SceneManagement;  // 👈 必须加这个

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private int score = 0;
    public int winCount = 10;    // 总目标数量（拾取物体）
    public GameObject winPanel; 
    private Rigidbody rb;

    public Text scoreText;  // ✅ 是 UnityEngine.UI.Text 类型


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        UpdateScore();
        winPanel.SetActive(false);  // 初始隐藏
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
            winPanel.SetActive(true);  // 胜利时显示面板
        }
    }

    void Update()
{
    // 如果小球掉出地图（Y 轴太低），重启当前场景
if (transform.position.y < -5f)  // 根据你地图高度设定，比如掉出地板
    {
        // 重置位置与速度
        transform.position = new Vector3(0, 1, 0);  // 回到地图中央
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
}
