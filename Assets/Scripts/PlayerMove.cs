using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  Vector2 v_pos;
  Rigidbody2D rgbd_2d;
  private Animator animus;
  public float speed = 5;
  private int lastStep = 0;
  //  0 - в первом кадре никто ничего не жал, поэтому ни A ни D не могли быть нажаты
  // -1 - записывается когда последняя клавиша была A
  //  1 - записывается когда последняя клавиша была D

  void Awake()
  {
    v_pos = new Vector2();
    rgbd_2d = GetComponent<Rigidbody2D>();
    animus = GetComponent<Animator>();
  }
  void Update()
  {
    v_pos.x = Input.GetAxisRaw("Horizontal") * speed;
    v_pos.y = Input.GetAxisRaw("Vertical") * speed;
    rgbd_2d.velocity = v_pos;

    if (Input.GetKeyDown(KeyCode.D))
    {
      if (lastStep == -1) this.transform.localScale = new Vector3(1, 1, 1);
      animus.SetBool("isRun", true);
      lastStep = 1;
    }

    if (Input.GetKeyDown(KeyCode.A))
    {
      if (lastStep == 1) this.transform.localScale = new Vector3(-1, 1, 1);
      animus.SetBool("isRun", true);
      lastStep = -1;
    }

    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) animus.SetBool("isRun", false);
  }
}
