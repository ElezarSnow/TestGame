using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  Rigidbody2D rgbd_2d;
  private Animator animus;
  public int speed = 2;
  private int lastStep = 0;
  //  0 - в первом кадре никто ничего не жал, поэтому ни A ни D не могли быть нажаты
  // -1 - записывается когда последняя клавиша была A
  //  1 - записывается когда последняя клавиша была D

  void Awake()
  {
    rgbd_2d = GetComponent<Rigidbody2D>();
    animus = GetComponent<Animator>();
  }
  void Update()
  {
    rgbd_2d.velocity = new Vector2(
    // V = 60 FPS
    // t = 1s
    // S = 60 px

       Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,  // x
       Input.GetAxisRaw("Vertical")     // y
     );

    if (Input.GetKeyDown(KeyCode.D))
    {
      if (lastStep == -1) this.transform.localScale = new Vector3(1, 1, 1);
      animus.SetBool("isRun", true);
      lastStep = 1;
    }

    if ( Input.GetKey(KeyCode.D) ) Debug.Log(Input.GetAxisRaw("Horizontal") * speed);

    if (Input.GetKeyDown(KeyCode.A))
    {
      if (lastStep == 1) this.transform.localScale = new Vector3(-1, 1, 1);
      animus.SetBool("isRun", true);
      lastStep = -1;
    }

    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) animus.SetBool("isRun", false);
  }
}
