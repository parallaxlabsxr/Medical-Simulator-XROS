using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float startDelay = 0; // Delay before the script starts in seconds
        public float duration = 10; // Duration in seconds for which the script should run
        private float distanceTravelled;
        private bool isStarted;

        private void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            Invoke("StartFollowing", startDelay);
            Invoke("DisableScript", startDelay + duration);
        }

        private void Update()
        {
            if (!isStarted || pathCreator == null) return;

            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        private void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void StartFollowing()
        {
            isStarted = true;
        }

        private void DisableScript()
        {
            enabled = false;
        }
    }
}