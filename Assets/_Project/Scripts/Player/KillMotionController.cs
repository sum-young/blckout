using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillMotionController : MonoBehaviour
{
    public static KillMotionController instance;

    [Header("연결할 UI")]
    public GameObject killMotionPanel; // 반투명 배경 패널 전체
    public Animator killAnimator;      // KillMotion_Image에 달린 애니메이터

    private void Awake()
    {
        instance = this;
        // 시작할 때는 무조건 꺼두기
        if (killMotionPanel != null) killMotionPanel.SetActive(false);
    }

    public void ShowKillMotion()
    {
        killMotionPanel.SetActive(true);
        StartCoroutine(PlayAndHideRoutine());
    }

    private IEnumerator PlayAndHideRoutine()
    {
        // 킬 애니메이션 재생 시작!
        killAnimator.SetTrigger("PlayKill");

        // 유니티가 'Kill_Action' 상태로 완전히 넘어갈 때까지 무한 대기
        while (!killAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kill_Action"))
        {
            yield return null;
        }

        // 킬 애니메이션의 길이 가져오기
        float animLength = killAnimator.GetCurrentAnimatorStateInfo(0).length;

        // 알아낸 길이만큼 기다리기
        yield return new WaitForSeconds(animLength);

        // 애니메이션이 끝나는 순간 정확히 UI 끄기
        killMotionPanel.SetActive(false);
    }
}