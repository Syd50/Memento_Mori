using UnityEngine;

public class IKController : MonoBehaviour
{

    private Animator animator;

    //spine3, head do nothing to affect what the pelvis is misaligning
    //rotate pelvis, get rid of other targets

    //Spine 3
    //public Transform spine3Target;
    ////head target
    //public Transform headTarget;

    //pelvis
    public Transform pelvisTarget;

    //pedals
    public Transform leftFootTarget;
    public Transform rightFootTarget;

    public Transform leftHandTarget;
    public Transform rightHandTarget;

    public Transform leftElbowHint;
    public Transform rightElbowHint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    //built in unity function
    private void OnAnimatorIK(int layerIndex)
    {
        if (animator == null) return;

        //spine3
        //if(spine3Target != null)
        //{
        //    //cant  use  Avartar IK goal - doesnt work 
        //    //dont think unity includes the chest for ik goal
        //    //direclty control humanoid bones (set bone local rotation)
        //    animator.SetBoneLocalRotation(HumanBodyBones.Chest, spine3Target.localRotation);
        //}

        ////head target
        //if (headTarget != null)
        //{
        //    animator.SetLookAtWeight(1f, 0f, 1f, 0f, 0.5f);
        //    animator.SetLookAtPosition(headTarget.position);
        //}


        //pelvis - cant find a unity ref for this
        //if target?
        if (pelvisTarget != null)
        {
            //weight 100% locked
            //animator.bodyPositionWeight = 1f;
            //animator.bodyRotationWeight = 1f;

            //match targets
            animator.bodyPosition = pelvisTarget.position; 
            animator.bodyRotation = pelvisTarget.rotation;

            //unity docs - animator is taking most of control 
            //need to forcce this script + my actual game obj to transform when i change rotation

            transform.rotation = pelvisTarget.rotation;
        }

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

        //left hand

        if(leftHandTarget != null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
        }

        //right hand


        if (rightHandTarget != null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
        }

        //arms bend weird
        //add targets for elbows? Bring them a bit more forward and rotate them nicer

        // left elbow - hint
        if (leftElbowHint != null)
        {
            animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1f);
            animator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowHint.position);
        }

        //right elbow - hint

        if (rightElbowHint != null)
        {
            animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1f);
            animator.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowHint.position);
        }
    }
}
