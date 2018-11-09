using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {
    public int force;
    Touch[] pulsaciones;
    Touch pulsacion;
    Vector2 posicionInicial;
    Vector2 posicionFinal;
	void Update () {
        pulsaciones = Input.touches;
        //Si no hay pulsaciones no seguimos
        if (pulsaciones.Length==0) {
            return;
        }
        //Recojo la pulsación
        pulsacion = pulsaciones[0];

        //Evaluar las pulsaciones
        switch (pulsacion.phase) {
            case (TouchPhase.Began):
                ComenzarToque();
                break;
            case (TouchPhase.Moved):
                MoverToque();
                break;
            case (TouchPhase.Ended):
                FinalizarToque();
                break;
            case (TouchPhase.Canceled):
                //CancelarToque();
                break;
            case (TouchPhase.Stationary):
                //PausarToque();
                break;
            default:
                //EjecutarAccionPorDefectoToque();
                break;
        }
	}
    void ComenzarToque() {
        //Obtenemos el vector de posición en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
        posicionInicial = posicionConvertida;
    }
    void MoverToque() {
        //Obtenemos el vector de posición en el mundo del juego
        Vector2 posicionConvertida = getWorldPosition(pulsacion);
        //Asignamos la nueva posición
        transform.position = posicionConvertida;
    }
    void FinalizarToque() {
        //Asignamos la nueva posición
        posicionFinal = getWorldPosition(pulsacion);
        //Calculamos direccion
        Vector2 direccion = (posicionInicial - posicionFinal).normalized;
        //Ponemos el rigidbody2d en modo kinematic
        GetComponent<Rigidbody2D>().isKinematic = false;
        //Le damos un empujon
        GetComponent<Rigidbody2D>().AddRelativeForce(direccion * force);
    }
    private Vector2 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }
    /*
    private Vector3 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector3(_t.position.x, _t.position.y, 0));
    }
    */
}
