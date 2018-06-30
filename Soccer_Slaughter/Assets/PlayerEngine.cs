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

    private float _powerRate;

	void Start () {
        _powerRate = 100;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    void Update()
    {
        //////////////////////////////////////////////////////////////////

        // I. Character movements + exhaustion handlings.
        if (!(Input.GetKey(KeyCode.LeftShift)) && _powerRate <= 100)
        {
            if (_powerRate == 0)
                _powerRate++;

            _powerRate = _powerRate * 1.007f;
        }

        if (Input.GetKey(_inputFront) && Input.GetKey(KeyCode.LeftShift) && _powerRate > 0)
        {
            transform.Translate(0, 0, _sprintSpeed * Time.deltaTime);
            _powerRate = _powerRate * 0.0005f;
        }

        if (Input.GetKey(_inputFront))
        {
            transform.Translate(0, 0, _trotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(_inputFront) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            transform.Translate(0, 0, _trotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(_inputBack))
            transform.Translate(0, 0, -(_trotSpeed / 2) * Time.deltaTime);

        if (Input.GetKey(_inputLeft))
            transform.Rotate(0, -_turnSpeed * Time.deltaTime, 0);

        if (Input.GetKey(_inputRight))
            transform.Rotate(0, _turnSpeed * Time.deltaTime, 0);

        //////////////////////////////////////////////////////////////////

        // II. [...]
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "user_agent")
        {
            DrawBack(col);
        }
    }
    
    void DrawBack(Collision col)
    {
        //col.transform.Translate(Vector3.forward * -1 * Time.deltaTime * 50);
        col.gameObject.GetComponent<Rigidbody>().AddForce(col.gameObject.GetComponent<Rigidbody>().position - transform.position * 3, ForceMode.VelocityChange);

    }
}
