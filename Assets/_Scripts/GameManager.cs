using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StateMachine _stateMachine;
    public PutadaBase nORMAL;
    public PutadaBase[] _putadas;
    public float locura;

    public List<GameObject> heads;
    public List<GameObject> hair;
    public List<GameObject> eyes;
    public List<GameObject> skin;
    public List<Material> skinMat;
    public List<Material> hairMat;
    public List<Material> eyesMat;

    public Transform client;
    public Animator clientAnimator;

    bool nextClient = false;
    Coroutine coroutine;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        if (nextClient)
        {
            RandomHead();
            coroutine = StartCoroutine(NextClient());

            nextClient = false;
        }

        if (Input.GetKeyDown(KeyCode.P)) { 
            if (coroutine != null) { StopCoroutine(coroutine); }
            nextClient = true; 
        }
    }

    public IEnumerator CallPutada(float NivelLocura, float temp)
    {
        locura = NivelLocura;
        int num = Random.Range(0, _putadas.Length);
        _stateMachine.ChangeState(_putadas[num]);
        yield return new WaitForSeconds(temp);
        _stateMachine.ChangeState(nORMAL);
    }


    public void RandomHead() {
        int randomHead = Random.Range(0, heads.Count);

        foreach (GameObject head in heads)
        {
            if (heads[randomHead] == head) { head.SetActive(true); }
            else { head.SetActive(false); }
        }

        int randomSkin = Random.Range(0, skinMat.Count);
        foreach (GameObject skin in skin)
        {
            skin.GetComponent<MeshRenderer>().material = skinMat[randomSkin]; 
        }

        int randomEyes = Random.Range(0, eyesMat.Count);
        foreach (GameObject eyes in eyes)
        {
            eyes.GetComponent<MeshRenderer>().materials[1] = eyesMat[randomEyes];
        }
        
        int randomHair = Random.Range(0, hairMat.Count);
        foreach (GameObject hair in hair) {
            hair.GetComponent<MeshRenderer>().material = hairMat[randomHair];
        }
    }

    IEnumerator NextClient()
    {
        clientAnimator.SetInteger("state", 1);
        yield return new WaitForSeconds(1);
        clientAnimator.SetInteger("state", 2);
        yield return new WaitForSeconds(1);
        clientAnimator.SetInteger("state", 3);
    }
}
