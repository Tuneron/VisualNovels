using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DustAnimation : MonoBehaviour
{
    public Image[] LayerPoint;
    public Sprite[] particles;
    public Canvas canvas;
    public Camera cam;

    public float quantitativeCoef;
    public float scaleCoef;
    public float speed;

    private Image[] lowLayerParticles;
    private Image[] medLayerParticlesFirst;
    private Image[] medLayerParticlesSecond;
    private Image[] highLayerParticles;

    private float x;
    private float y;

    void Start()
    {
        lowLayerParticles = GenerateDust(0, scaleCoef, 8, quantitativeCoef);
        lowLayerParticles[lowLayerParticles.Length - 1] = LayerPoint[0];

        medLayerParticlesFirst = GenerateDust(1, scaleCoef, 8, quantitativeCoef);
        medLayerParticlesFirst[medLayerParticlesFirst.Length - 1] = LayerPoint[1];

        medLayerParticlesSecond = GenerateDust(2, scaleCoef, 8, quantitativeCoef);
        medLayerParticlesSecond[medLayerParticlesSecond.Length - 1] = LayerPoint[2];

        highLayerParticles = GenerateDust(3, scaleCoef, 8, quantitativeCoef);
        highLayerParticles[highLayerParticles.Length - 1] = LayerPoint[3];

        for (int i = 0; i < lowLayerParticles.Length; i++)
        {
            Random.InitState(i * System.DateTime.Now.Millisecond);
            lowLayerParticles[i].GetComponent<Box>().moveVector = new Vector2((Random.Range(0f, 1f) * Random.Range(0, 2) > 0 ? -1 : 1) / speed, (Random.Range(0f, 2f) * Random.Range(0, 2) > 0 ? -1 : 1) / speed);
        }

    }


    void Update()
    {
        
        for (int i = 0; i < lowLayerParticles.Length; i++)
        {
            Thread.Sleep(1);
            Random.InitState(System.DateTime.Now.Millisecond);

            if (Random.Range(0, 500) < 5)
            {
                NewSeed();
                lowLayerParticles[i].GetComponent<Box>().moveVector = new Vector2((x * Random.Range(0, 2) > 0 ? -1 : 1) / speed, (y * Random.Range(0, 2) > 0 ? -1 : 1) / speed);
                lowLayerParticles[i].transform.Translate(lowLayerParticles[i].GetComponent<Box>().moveVector);

                NewSeed();
                medLayerParticlesFirst[i].GetComponent<Box>().moveVector = new Vector2((x * Random.Range(0, 2) > 0 ? -1 : 1) / speed, (y * Random.Range(0, 2) > 0 ? -1 : 1) / speed);
                medLayerParticlesFirst[i].transform.Translate(medLayerParticlesFirst[i].GetComponent<Box>().moveVector);

                NewSeed();
                medLayerParticlesSecond[i].GetComponent<Box>().moveVector = new Vector2((x * Random.Range(0, 2) > 0 ? -1 : 1) / speed, (y * Random.Range(0, 2) > 0 ? -1 : 1) / speed);
                medLayerParticlesSecond[i].transform.Translate(medLayerParticlesSecond[i].GetComponent<Box>().moveVector);

                NewSeed();
                highLayerParticles[i].GetComponent<Box>().moveVector = new Vector2((x * Random.Range(0, 2) > 0 ? -1 : 1) / speed, (y * Random.Range(0, 2) > 0 ? -1 : 1) / speed);
                highLayerParticles[i].transform.Translate(highLayerParticles[i].GetComponent<Box>().moveVector);
            }
            else
            {
                lowLayerParticles[i].transform.Translate(lowLayerParticles[i].GetComponent<Box>().moveVector);
                medLayerParticlesFirst[i].transform.Translate(medLayerParticlesFirst[i].GetComponent<Box>().moveVector);
                medLayerParticlesSecond[i].transform.Translate(medLayerParticlesSecond[i].GetComponent<Box>().moveVector);
                highLayerParticles[i].transform.Translate(highLayerParticles[i].GetComponent<Box>().moveVector);
            }
        }
    }

    private void NewSeed()
    {
        Thread.Sleep(1);
        Random.InitState(System.DateTime.Now.Millisecond);
        x = Random.Range(0f, 1f);

        Thread.Sleep(1);
        Random.InitState(System.DateTime.Now.Millisecond);
        y = Random.Range(0f, 1f);
    }

    private Image[] GenerateDust(int layer, float scale, float quantity, float quantityCoef)
    {
        Image[] array = new Image[(int)(quantity * quantityCoef) + 1];

        float xRand = 0;
        float yRand = 0;

        for(int i = 0; i < array.Length; i ++)
        {
            Thread.Sleep(1);
            Random.InitState(System.DateTime.Now.Millisecond);
            xRand = Random.value;

            Thread.Sleep(1);
            Random.InitState(System.DateTime.Now.Millisecond);
            yRand = Random.value;

            Thread.Sleep(1);
            Random.InitState(System.DateTime.Now.Millisecond);

            array[i] = Instantiate(LayerPoint[layer]);
            array[i].transform.SetParent(canvas.transform);
            array[i].gameObject.transform.position = new Vector3(Random.Range(-13, 13) * xRand, Random.Range(-7, 7) * yRand, 0);
            array[i].rectTransform.localScale = new Vector3(scale, scale, scale);
        }

        return array;
    }

}
