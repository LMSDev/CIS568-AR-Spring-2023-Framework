namespace MyFirstARGame
{
    using Photon.Pun;
    using UnityEngine;

    /// <summary>
    /// This class is responsible for controlling the TrackedImage prefab. The prefab gets instantiated by <see cref="SharedSpaceManager"/>
    /// when the phone is tracking an image.
    /// </summary>
    public class TrackedImageController : MonoBehaviourPun
    {
        /// <summary>
        /// Updates the scale of the reference image target object on the PC scene to reflect the tracked dimensions.
        /// </summary>
        /// <param name="realScale">The real world scale.</param>
        [PunRPC]
        public void UpdateScale(Vector3 realScale)
        {
            // In our PC scene, we have an ImageTarget object that we can update with the observerd real word size and then disable us.
            // It might still be desirable to keep this GameObject around, especially when troubleshooting image tracking related issues.
            // But you could also remove it entirely and just send the tracked data to the PC instead of instantiating a GameObject.
            var dummyImageTarget = GameObject.Find("ImageTarget");
            if (dummyImageTarget != null)
            {
                dummyImageTarget.transform.localScale = realScale;
                this.gameObject.SetActive(false);
            }
        }
    }
}
