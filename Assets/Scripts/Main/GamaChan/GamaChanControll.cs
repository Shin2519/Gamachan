using UnityEngine;

public class GamaChanControll : MonoBehaviour
{
    [SerializeField]
    UI Gama;

    [SerializeField] MouseInputProvider Input;
    
    [SerializeField] ProbabilityManager probability = new();

    DragOperation drag;

    [SerializeField] float ShakeCharge;

    [SerializeField] float MoneyTimer;

    [SerializeField] LayerMask gamalayer;

    [SerializeField] Vector2 MinPos;

    [SerializeField] Vector2 MaxPos;

    [SerializeField] SpriteRenderer GamachanRenderer;

    public float shakecharge
    {
        get => ShakeCharge;

        set
        {
            ShakeCharge = Mathf.Clamp(value,0,100);
        }
    }

    public Sprite p_GamachanRenderer { set => GamachanRenderer.sprite = value; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GamachanRenderer.sprite = Gama.Kindofemotion[0];
        drag = new DragOperation(MinPos,MaxPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLoopManagement.Instance._Gamestate!=StateMashine.GameState.GamaSakePhase)return;
        HandleDrag();
        shakecharge -= 2;
    }
    void HandleDrag()
    {
        if (Input.IsPressed && !drag.IsActive)
        {
            TryGrab();
        }
        else if (!Input.IsPressed && drag.IsActive)
        {
            drag.End();
            shakecharge = 0;
        }
        
        if (drag.IsActive)
        {
            MoneyTimer -= Time.deltaTime;
            shakecharge += drag.UpdatePosition(Input.GetWorldPosition(), Time.deltaTime, shakecharge);
            if (MoneyTimer<=0)
            {
                MoneyTimer = 0.2f;
                
                probability.KindofMoney(shakecharge);
            }
        }
    }

    private void TryGrab()
    {
        Vector3 MouceWorldPos = Input.GetWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(MouceWorldPos, Vector3.zero, Mathf.Infinity, gamalayer);
        if (hit.collider == null) return;
        drag.Begin(hit.collider.transform, MouceWorldPos);
    }

    public void SpriteChange(StateMashine.GamaState l_gamastate,Statestate.Grade l_grade)
    {
        switch (l_gamastate)
        {
            case StateMashine.GamaState.Nomal:
                Grade_SpriteChange_Normal(l_grade);
                break;
            case StateMashine.GamaState.Gold:
                Grade_SpriteChange_Gold(l_grade);
                break;
        }
    }
    /// <summary>
    /// 通常時のがまちゃんの評価の時の表情差分
    /// </summary>
    /// <param name="l_grade"></param>
    void Grade_SpriteChange_Normal(Statestate.Grade l_grade)
    {
        switch (l_grade)
        {
            case Statestate.Grade.Perfect:
                break;
            case Statestate.Grade.Great:
                break;
            case Statestate.Grade.Good:
                break;
            case Statestate.Grade.Bad:
                break;
            case Statestate.Grade.Miss:
                break;
        }
    }
    /// <summary>
    /// ゲージがたまった時のがまちゃんの評価の時の表情差分
    /// </summary>
    /// <param name="l_grade"></param>
    void Grade_SpriteChange_Gold(Statestate.Grade l_grade)
    {
        switch (l_grade)
        {
            case Statestate.Grade.Perfect:
                break;
            case Statestate.Grade.Great:
                break;
            case Statestate.Grade.Good:
                break;
            case Statestate.Grade.Bad:
                break;
            case Statestate.Grade.Miss:
                break;
        }
    }
}
