using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Vampirism : MonoBehaviour
{
    private const float AbilityAreaRadius = 2f;
    private const float CastDistance = 10f;
    private const float OneSecond = 1f;

    private const string EnemyLayer = "Enemy";

    [SerializeField] private int _abilityDuration;
    [SerializeField] private float _lifeStealValue;

    [SerializeField] private VampiricButton _button;

    private bool _isEnemyInArea;

    private Player _player;
    private Transform _transform;

    private void OnEnable()
    {
        _button.Clicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _button.Clicked -= OnButtonClicked;
    }

    private void Start()
    {
        _transform = transform;
        _player = GetComponent<Player>();
    }

    private void OnButtonClicked()
    {
        RaycastHit2D hit = TryGetHitInAbilityArea();

        if (hit)
        {
            _isEnemyInArea = true;
            StartCoroutine(CastVampirism(hit));
        }
    }

    private IEnumerator CastVampirism(RaycastHit2D hit)
    {
        int timerCount = _abilityDuration;

        Enemy enemy = hit.transform.GetComponent<Enemy>();
        WaitForSecondsRealtime waitingTime = new WaitForSecondsRealtime(OneSecond);

        _button.Disable();

        while (timerCount > 0)
        {
            _button.SetTimerNumber(timerCount);

            if (_isEnemyInArea && TryGetHitInAbilityArea() == hit)
            {
                enemy.TakeDamage(_lifeStealValue);
                _player.TakeHeal(_lifeStealValue);
            }
            else
            {
                _isEnemyInArea = false;
            }

            yield return waitingTime;

            timerCount--;
        }

        _button.Enable();
    }

    private RaycastHit2D TryGetHitInAbilityArea()
    {
        return Physics2D.CircleCast(_transform.position, AbilityAreaRadius, Vector2.zero,
            CastDistance, LayerMask.GetMask(EnemyLayer));
    }
}