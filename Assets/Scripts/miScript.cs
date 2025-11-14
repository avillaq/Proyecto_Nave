using UnityEngine;

public class miScript : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audioSource;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcesarInput();
    }
    void ProcesarInput()
    {
        Propulsion();
        Rotacion();
    }

    void Propulsion()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Propulsion activada");
            rigidbody.freezeRotation = true;
            rigidbody.AddRelativeForce(Vector3.up * 10);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }
        rigidbody.freezeRotation = false;
    }

    void Rotacion()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //print("Movimiento a la derecha");
            // transform.Rotate(Vector3.back);
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 0.6f;
            transform.rotation = rotarDerecha;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //print("Movimiento a la izquierda");
            // transform.Rotate(Vector3.forward);
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.z += Time.deltaTime * 0.6f;
            transform.rotation = rotarIzquierda;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colision segura...");
                break;
            case "Combustible":
                print("Combustible...");
                break;
            default:
                print("Muerto !!");
                break;
        }
    }

}
