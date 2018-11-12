using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaScript : MonoBehaviour {
    public GameObject prefabPuntuacion;
    private bool estaIntacta = true;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (estaIntacta && collision.gameObject.name == "Pajarraco") {
            GameObject puntuacion = Instantiate(prefabPuntuacion, this.transform.position, Quaternion.identity);
            estaIntacta = false;
        }
    }
}
