using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance = null;
    public static Player Instance => instance;

    [Header("Префабы")]
    public GameObject PlatformPrefab;
    public GameObject[] CubePrefabs;
    public GameObject ActivCube;
    [Header("Состояния и машина состояний")]
    public StateMachine MovementSM;
    public StandingState Standing;
    public FlyState Fly;
    public SwingState Swing;
    public CreateState Create;
    public TransitionState Transition;
    [Header("Игровые объекты")]
    public GameObject GameBlock;
    public GameObject LastBlock;
    public GameObject Platform;
    [Header("Прочие переменные")]
    public bool isBlock = false;
    public bool isPlatformDown = false;
    public bool isLastBlock = false;
    public float maxXDistance;

    private int iMax = 8;
    

    public void CreateBlock()
    {
        GameBlock = Instantiate(ActivCube, new Vector3(Random.Range(250,267), 400f, 22.5f), transform.rotation);
    }

    public void ChangeCube()
    {
        ActivCube = CubePrefabs[Random.Range(0, 2)];
    }
    public void CreatePlatform()
    {
        Platform = Instantiate(PlatformPrefab, new Vector3(259, 355, 22.5f), transform.rotation);
    }


    public IEnumerator PlatformDown()
    {

            for (int i = 0; i < iMax; i++)
            {
                if(Platform != null)
                {
                    Platform.transform.Translate(new Vector3(0, -0.95f, 0));
                    yield return new WaitForSeconds(0.05f);
                }
                
            }
            

    }
    

    #region MonoBehaviour
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        MovementSM = new StateMachine();

        Standing = new StandingState(this, MovementSM);
        Fly = new FlyState(this, MovementSM);
        Swing = new SwingState(this, MovementSM);
        Create = new CreateState(this, MovementSM);
        Transition = new TransitionState(this, MovementSM);

        ActivCube = CubePrefabs[0];
        MovementSM.Initialize(Create);
        

        Platform = GameObject.FindGameObjectWithTag("Platform");
        LastBlock = Platform;
    }

    private void Update()
    {
        MovementSM.CurrentState.LogicUpdate();

        MovementSM.CurrentState.HandleInput();
    }

    private void FixedUpdate()
    {
        MovementSM.CurrentState.PhysicsUpdate();
    }
    #endregion
}
