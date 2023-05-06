using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private GameObject _coin;
    private bool hasBeenActivated = false;
    private Animator _coinAnimator;

    private void Start()
    {
        _coinAnimator = _coin.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenActivated && other.CompareTag("Player"))
        {
            _coinAnimator.SetTrigger("Destroy");
            particleSystem.Play();
            hasBeenActivated = true;
            Destroy(gameObject, 2f);
        }
    }
}
