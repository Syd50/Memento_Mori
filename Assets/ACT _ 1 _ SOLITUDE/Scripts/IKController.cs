using UnityEngine;

public class IKController : MonoBehaviour
{

    private Animator animator;

    //pedals
    public Transform leftFootTarget;
    public Transform rightFootTarget;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    //built in unity function
    private void OnAnimatorIK(int layerIndex)
    {
        if (animator == null) return;

        //Left food
        if (leftFootTarget != null)
        {
            //weight to 1 , that means 100% glued to the target
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);

            //match the target position and rotation
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootTarget.rotation);
        }

        //Right Foot

        if (rightFootTarget != null)
        {
            //weight to 1 , that means 100% glued to the target
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);

            //match the target position and rotation
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootTarget.position);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootTarget.rotation);

        }
    }
}
