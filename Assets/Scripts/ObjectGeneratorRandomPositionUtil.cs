using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneratorRandomPositionUtil : MonoBehaviour
{
    //objectPrefab que vai ser gerado em uma posição aleátoria
    public GameObject objectPrefab;

    //radius será o raio que definimos para o circulo onde irá spawnar o object prefab
    public float radius = 0.2f;

    //Metodo obterá uma posição aleátoria
    protected Vector2 GetRandomPosition()
    {
        //Retorna um ponto aleátorio dentro do círculo multiplicado pelo radius somado com o vetor de trasnformação de posição que é a posição do gerador de objetos
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }

    //Metodo para gerar uma rotação aleátoria para a explosão
    protected Quaternion Random2DRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public void CreteObject()
    {
        Vector2 position = GetRandomPosition();
        GameObject impactObject = GetObject();
        impactObject.transform.position = position;
        impactObject.transform.rotation = Random2DRotation();
    }

    protected virtual GameObject GetObject()
    {
        return Instantiate(objectPrefab);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
