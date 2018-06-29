using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    public float _trotSpeed;
    public float _sprintSpeed;
    public float _turnSpeed;

    public KeyCode _inputFront;
    public KeyCode _inputBack;
    public KeyCode _inputLeft;
    public KeyCode _inputRight;

	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    void Update()
    {
        if (Input.GetKey(_inputFront))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                transform.Translate(0, 0, _sprintSpeed * Time.deltaTime);
            else
                transform.Translate(0, 0, _trotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(_inputBack))
            transform.Translate(0, 0, -(_trotSpeed / 2) * Time.deltaTime);

        if (Input.GetKey(_inputLeft))
            transform.Rotate(0, -_turnSpeed * Time.deltaTime, 0);

        if (Input.GetKey(_inputRight))
            transform.Rotate(0, _turnSpeed * Time.deltaTime, 0);
    }
}
