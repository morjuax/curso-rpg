using System;
using UnityEngine;

public class PersonajeVida: VidaBase
{
    public static Action EventoPersonajeDerratado;
    public bool Derrotado { get; private set; }
    public bool puedeSerCurado => Salud < saludMax;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if (Derrotado)
        {
            return;
        }

        if (puedeSerCurado)
        {
            Salud += cantidad;
            if (Salud > saludMax)
            {
                Salud = saludMax;
            }
            ActualizarBarraVida(Salud, saludMax);
        }
    }

    protected override void PersonajeDerratado()
    {
        _boxCollider2D.enabled = false;
        Derrotado = true;
        EventoPersonajeDerratado?.Invoke();
    }

    public void RestaurarPersonaje()
    {
        _boxCollider2D.enabled = true;
        Derrotado = false;
        Salud = saludInicial;
        ActualizarBarraVida(Salud, saludInicial);
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}