using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PreguntasImport
{
    public Dificultad[] bancoDePreguntas;
}

public class LoaderJSON : MonoBehaviour
{
    public bool cargarPreguntas = false;
    public string nombreArchivo;
    public Game game;

    // Start is called before the first frame update
    
    void Awake() 
    {
        if (!cargarPreguntas) return;

        //https://answers.unity.com/questions/1533905/reading-json-file-1.html

        // borrar todo el banco de preguntas
        //game.bancoDePreguntas = null;

        // ubicacion del archivo
        string archivoPath = Application.streamingAssetsPath + "/" + nombreArchivo + ".json";

        string jsonString = File.ReadAllText(archivoPath);

        //Debug.Log(jsonString);

        // Serializar el archivo
        var bancoDePreguntasTemp = JsonUtility.FromJson<PreguntasImport>(jsonString).bancoDePreguntas;

        game.bancoDePreguntas = bancoDePreguntasTemp;

        //Debug.Log(game.bancoDePreguntas);

    }
}
