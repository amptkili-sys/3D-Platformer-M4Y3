using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //Переменный скорости
    public float speed = 5f;
    public float runSpeed = 9f;
    float targetMovingSpeed;

    //Переменные для переключения с бега на ходьбу
    public bool canRun = true;
    public bool isRunning;

    //Код левой клавиши Shift
    public KeyCode runningKey = KeyCode.LeftShift;

    //Ссылка на компонент Rigidbody игрока
    private Rigidbody playerRigidbody;

    void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        //проверка, что механика бега активна и зажат левый Shift
        isRunning = canRun && Input.GetKey(runningKey);
        //обновит данные о целевой скорости персонажа
        targetMovingSpeed = isRunning ? runSpeed : speed;

        //обновление скорости саммого персонажа
        playerRigidbody.velocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), playerRigidbody.velocity.y, Input.GetAxis("Vertical") * targetMovingSpeed);

        //вращение персонажа на месте
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (100f * Time.deltaTime), Space.Self);

    }
}
