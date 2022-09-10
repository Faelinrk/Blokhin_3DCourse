using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private bool ikActive = false;
    [SerializeField] private Transform rightHandObj = null;
    [SerializeField] private Transform leftHandObj = null;
    [SerializeField] private Transform lookObj = null;
    private const string IkLayerName = "IKLayer";
    private int ikLayerIndex;
    private float rightHandMovement;
    private float leftHandMovement;
    private float headMovement;
    [SerializeField] private float lerpPower = .1f;
    [SerializeField] private float leftHandDist = 2f;
    [SerializeField] private float rightHandDist = 2f;
    [SerializeField] private float headDist = 2f;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ikLayerIndex = animator.GetLayerIndex(IkLayerName);
        rightHandMovement = 0;
        leftHandMovement = 0;
        headMovement = 0;
    }

    void OnAnimatorIK()
    {
        if (animator)
        {
            if (ikActive)
            {
                headMovement = PinHead(lookObj, headMovement,headDist);
                leftHandMovement = PinHand(AvatarIKGoal.RightHand,rightHandObj, leftHandMovement,leftHandDist);
                rightHandMovement = PinHand(AvatarIKGoal.LeftHand,leftHandObj, rightHandMovement,rightHandDist);
            }
            else
            {
                UnpinHand(AvatarIKGoal.RightHand);
                UnpinHand(AvatarIKGoal.LeftHand);
                UnpinHead();
            }
        }
    }



    private float PinHead(Transform lookToObject, float currentLerp, float dist)
    {
        if (lookToObject != null)
        {
            if (Vector3.Distance(transform.position, lookToObject.position) <= dist)
            {
                currentLerp = Mathf.Lerp(currentLerp, 1, lerpPower);
                animator.SetLookAtWeight(currentLerp);
                animator.SetLookAtPosition(lookToObject.position);
                return currentLerp;
            }
            else
            {
                UnpinHead();
            }
        }
        return 0;
    }
    private float PinHand(AvatarIKGoal part,Transform handObject,float currentLerp,float dist)
    {
        if (handObject != null  )
        {
            if (Vector3.Distance(transform.position, handObject.position) <= dist)
            {
                currentLerp = Mathf.Lerp(currentLerp, animator.GetLayerWeight(ikLayerIndex), lerpPower);
                animator.SetIKPositionWeight(part, currentLerp);
                animator.SetIKRotationWeight(part, currentLerp);
                animator.SetIKPosition(part, handObject.position);
                animator.SetIKRotation(part, handObject.rotation);
                return currentLerp;
            }
            else UnpinHand(part);
        }
        return 0;
    }

    private float UnpinHand(AvatarIKGoal part)
    {
        animator.SetIKPositionWeight(part, 0);
        animator.SetIKRotationWeight(part, 0);
        animator.SetIKPositionWeight(part, 0);
        animator.SetIKRotationWeight(part, 0);
        return 0;
    }
    private void UnpinHead()
    {
        animator.SetLookAtWeight(0);
    }
}
