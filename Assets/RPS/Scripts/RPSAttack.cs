using System.Collections;
using System.Linq;
using UnityEngine;

public class RPSAttack : MonoBehaviour
{
    // TODO: Dodìlat particle system a aplikovat na hráèe i enemy
    // Pozn. Particles se emittují zde scriptem (burst)

    [SerializeField]
    private float minInterval;

    [SerializeField]
    private float maxInterval;

    private RPSSymbol mySymbol;
    private ParticleSystem attackParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackParticles = GetComponentInChildren<ParticleSystem>();
        mySymbol = GetComponent<RPSSymbol>();
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
            Attack();
        }
    }

    private void Attack()
    {
        DoAnimation();
        DoDamage();
    }

    private void DoDamage()
    {
        var cols = Physics.OverlapSphere(transform.position, 1f);
        var symbols = cols.Select(col => col.GetComponentInParent<RPSSymbol>());
        symbols.ToList().RemoveAll(symbol => symbol == null);

        foreach(var symbol in symbols)
        {
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(symbol.CurrentSymbol);
            if(wouldWin.HasValue && wouldWin.Value)
            {
                Debug.Log($"{symbol.name} died!");
                Destroy(symbol.gameObject);
            }
        }

    }

    private void DoAnimation()
    {
        attackParticles.Emit(50);
    }
}
