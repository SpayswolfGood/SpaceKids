using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadObjact : MonoBehaviour
{
    [SerializeField]
    private string tagOgact;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == tagOgact)
        {
            Destroy(gameObject);
        }

    }
}
