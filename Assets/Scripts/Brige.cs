using UnityEngine;

public class Brige : MonoBehaviour
{
    [SerializeField] private GameObject _bridge;
    [SerializeField] private GameObject _grip;
    [SerializeField] private GameObject _hint;
    [SerializeField] private GameObject _lignht;
    private Animator _bridgeAnimator;
    private Animator _gripAnimator;
    private bool _isTrigger;

    private void Start()
    {
        _bridgeAnimator = _bridge.GetComponent<Animator>();
        _gripAnimator = _grip.GetComponent<Animator>();
    }

    private void Update()
    {
        BridgeUp();
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            _isTrigger = true;
            _hint.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            _isTrigger = false;
            _hint.SetActive(false);
        }
    }

    private void BridgeUp()
    {
        if (_isTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _gripAnimator.SetTrigger("GripUse");
                _bridgeAnimator.SetTrigger("BrigdeUp");
                _lignht.SetActive(true);
            }
        }



    }
}
