using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField]
    [Tooltip("発生させるエフェクト")]
    private ParticleSystem particle;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            ParticleSystem newParticle = Instantiate(particle);

            newParticle.transform.position = this.transform.position;

            newParticle.Play();

            Destroy(newParticle.gameObject, 5f);
        }
    }
}
