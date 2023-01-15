using Controllers.Pool;
using DG.Tweening;
using Managers;
using Signals;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;
        [FormerlySerializedAs("xptiblesCountText")] [FormerlySerializedAs("bonusText")] [SerializeField] private TextMeshPro xptiblesValueText;
        
        #endregion

        #region Private Variables

        private float xptibles = 1;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StageArea"))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                DOVirtual.DelayedCall(3, () =>
                {
                    var result = other.transform.parent.GetComponentInChildren<PoolController>()
                        .TakeStageResult(manager.StageValue);
                    if (result)
                    {
                        CoreGameSignals.Instance.onStageAreaSuccessful?.Invoke(manager.StageValue);
                        InputSignals.Instance.onEnableInput?.Invoke();
                    }
                    else CoreGameSignals.Instance.onLevelFailed?.Invoke();
                });
                return;
            }

            if (other.CompareTag("Finish"))
            {
                CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }

            if (other.CompareTag("MiniGame"))
            {
                CoreGameSignals.Instance.onMinigameAreaEntered?.Invoke();
            }

            if (other.CompareTag("Xptibles"))
            {
                IncreaseXptiblesValue();
                Destroy(other.gameObject);
                CoreGameSignals.Instance.onXptibleClaimed?.Invoke();
            }
        }

        internal void IncreaseXptiblesValue()
        {
            xptibles++;
            SetBonusValue();
        }

        internal void ResetBonusValue()
        {
            xptibles = 1;
            SetBonusValue();
        }

        private void SetBonusValue()
        {
            xptiblesValueText.text = xptibles + "Xptibles";
        }

        internal void ShowUpBonusText()
        {
            xptiblesValueText.DOFade(1, 0f).SetEase(Ease.Flash).OnComplete(() => xptiblesValueText.DOFade(0, 0).SetDelay(.65f));
            xptiblesValueText.rectTransform.DOAnchorPosY(.85f, .65f).SetRelative(true).SetEase(Ease.OutBounce).OnComplete(() =>
                xptiblesValueText.rectTransform.DOAnchorPosY(-.85f, .65f).SetRelative(true));
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var transform1 = manager.transform;
            var position = transform1.position;
            Gizmos.DrawSphere(new Vector3(position.x, position.y - 1.2f, position.z + 1f), 1.65f);
        }

        internal void OnReset()
        {
        }
    }
}