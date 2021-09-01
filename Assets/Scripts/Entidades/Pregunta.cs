using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public partial class Pregunta
{
    public string enunciado;
    public Respuesta[] respuestas;
    public int respuestaCorrecta;
}
