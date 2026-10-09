using System.Collections;
using System.Collections.Generic;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

public class Build1 : ScreenBase
{
    public Text title1;
    public Text title2;
    public Text present;
    public Text edugoal;
    string title;

    // Use this for initialization
    //스크립트 실행시 각 오브젝트에 Inven에서 불러온 값에 알맞는 정보 할당
    protected override void OnOpen(ScreenArgs args)
    {
        NameArgs nameArgs = args as NameArgs;
        title = nameArgs != null ? nameArgs.Name : string.Empty;
        title1.text = title;
        title2.text = title;

        switch (title)
        {
            //1호관
            case "대학본부":
                present.text = "총장실, 입학관리과, 대외협력홍보팀등 학교의 행정적인 일을 처리하는 부서 및 사람들이 모여있다.";
                edugoal.text = "‘시간에서 미래, 공간에서 세계’라는 키워드를 갖고 인천대학교를 세계 속의 중심대학으로 만든다.\n\n" +
                    "미래를 내다보며 바이오 3개, 공학 1개, 인문사회 1개 분야를 각각의 봉우리로 만들어, 인천대학교를 이끌어나갈 다섯 개의 봉우리에 집중투자 할 것이다.";
                break;
            //12호관
            case "컨벤션센터":
                present.text = "대규모 계단식 강의실, 중 소규모 세미나실 등 총 35실을 배치하였고 캠퍼스 중앙 배치의 접근성으로 긴밀한 인적교류가 가능하다.";
                edugoal.text = "컨벤션센터에서는 대학의 지성인들이 교양을 쌓을 수 있는 수업을 진행하고 있다.";
                break;
            //22호관
            case "학군단":
                present.text = "ROTC(Reserve Officers’ Training Corps)는 대학 재학생 가운데 우수 학생들을 선발하여 군사교육을 실시하고 졸업과 동시에 장교로 임관시켜 군(軍)의 초급 지휘자 및 전역 후 예비군 지휘자로 활용하기 위한 제도로서 미국에서 처음 도입하였다.";
                edugoal.text = "문무를 겸비한 학군사관후보생 양성을 목표로 한다.\n" +
                    " 1학년 사전선발 + 2학년 정시선발을 통해 학군사관후보생을 모집한다.";
                break;
            //오류발생
            default:
                present.text = "정보 불러오기에 실패하였습니다.\\n\n 다시 시도해 주세요.";
                edugoal.text = "";
                break;
        }
    }

    public void ExitBtn()
    {
        Close();
    }
}