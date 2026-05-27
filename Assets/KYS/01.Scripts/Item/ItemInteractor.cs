using UnityEngine;
using UnityEngine.InputSystem;

// PlayerArmature에 부착 — 카메라 중앙에서 레이캐스트로 아이템 감지 및 획득 처리
public class ItemInteractor : MonoBehaviour
{
    // 레이캐스트 최대 거리
    [SerializeField] private float rayDistance = 3f;

    // 아이템 레이어 마스크 (Item 레이어만 감지)
    [SerializeField] private LayerMask itemLayerMask;

    // 아이템 설명 UI 컨트롤러
    [SerializeField] private ItemDescriptionUI descriptionUI;

    private Camera _mainCamera;
    private ItemObject _currentTarget;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        DetectItem();

        // 현재 감지된 아이템이 있고 E 키를 누르면 획득
        if (_currentTarget != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryPickUp();
        }
    }

    private void DetectItem()
    {
        // Ray가 시작되는 위치 (카메라 위치)
        Vector3 origin = _mainCamera.transform.position;

        // Ray가 나아가는 방향 (카메라가 바라보는 방향)
        Vector3 direction = _mainCamera.transform.forward;

        // 검사할 최대 거리
        float distance = rayDistance;

        // Ray가 맞은 오브젝트 정보
        RaycastHit hit;

        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out hit, distance, itemLayerMask))
        {
            // hit.collider에서 아이템 확인
            ItemObject item = hit.collider.GetComponent<ItemObject>();

            if (item != null)
            {
                // 새로운 아이템을 바라볼 때만 UI 갱신
                if (item != _currentTarget)
                {
                    _currentTarget = item;
                    descriptionUI.Show(_currentTarget.Data);
                }
                return;
            }
        }

        // 아이템을 바라보지 않으면 UI 숨기기
        if (_currentTarget != null)
        {
            _currentTarget = null;
            descriptionUI.Hide();
        }
    }

    private void TryPickUp()
    {
        if (!_currentTarget.Data.isObtainable)
        {
            return;
        }

        _currentTarget.PickUp();
        _currentTarget = null;
        descriptionUI.Hide();
    }

    private void OnDrawGizmosSelected()
    {
        if (_mainCamera == null) return;

        Vector3 origin = _mainCamera.transform.position;
        Vector3 direction = _mainCamera.transform.forward;
        Ray ray = new Ray(origin, direction);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(ray.origin, ray.direction * rayDistance);
    }
}
