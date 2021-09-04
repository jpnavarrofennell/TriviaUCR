using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Pregunta
{
    public string informacionComplementaria;
}
public class PanelComplementario : MonoBehaviour
{
    public GameObject panelInformacionComplementaria;
    public Text informacionComplementaria;
    public Game game;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continuar()
    {
        panelInformacionComplementaria.SetActive(false);
        game.SelecionarPregunta();
    }

    public void Desplegar()
    {
        panelInformacionComplementaria.SetActive(true);
        //Cargar la informacion del banco de preguntas con la informacion complementaria
    }
}
