using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;

    [SerializeField] private Slider slider;
    private float tiempoActual;

    private bool tiempoActivado = false;

    private void Start()
    {
        tiempoActual = tiempoMaximo; // Initialize tiempoActual
        ActivarTemporizador();
    }

    private void Update()
    {
        if (tiempoActivado)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;

        }

        if (tiempoActual <= 0)
        {
            Debug.Log("Derrota");
            tiempoActivado = false;
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
       tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true); // Activate the timer
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);

    }
}