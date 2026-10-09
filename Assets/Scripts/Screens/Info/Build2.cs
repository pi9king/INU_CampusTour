using System.Collections;
using System.Collections.Generic;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

public class Build2 : ScreenBase
{
    public Text title1;
    public Text title2;
    public Text present;
    string title;

    protected override void OnOpen(ScreenArgs args)
    {
        NameArgs nameArgs = args as NameArgs;
        title = nameArgs != null ? nameArgs.Name : string.Empty;
        title1.text = title;
        title2.text = title;

        switch (title)
        {
            //2호관
            case "교수회관":
                present.text = "교직원 식당, 레스토랑을 운영하고 다목적실, 세미나실, 대회의실, 테라스 시설 등이 있다.";
                break;
            //3호관
            case "홍보관":
                present.text = "대학의 역사와 비전을 관람할 수 있고 캠퍼스투어등을 진행할 때 사용된다.\n\n" +
                    "※ 홍보대사\n국립 인천대학교의 홍보대사인 ‘드림이’는 국립 인천대의 꿈과 희망을 드리는 사람들이라는 뜻을 가지고 있으며 2002년 4월 15명의 인천대학교 재학생들로 출발하였습니다.\n" +
                    "학교 방문객들에게 국립 인천대학교의 미래와 아름다움을 알려드리는 캠퍼스 투어 진행, 각종 대외적 입시 행사와  교내 행사의 지원, 온라인 대학 홍보 등 활발한 활동을 펼치고 있습니다.";
                break;
            //4호관
            case "BM컨텐츠관":
                present.text = "";
                break;
            //6호관
            case "학산도서관":
                present.text = "총 120만권의 다양한 주제별 장서를 보유하고 있고 1800여개의 열람석, 1000석의 자유열람석을 가지고 있다.";
                break;
            //9호관
            case "공동실험실습관":
                present.text = "";
                break;
            //10호관
            case "게스트하우스":
                present.text = "국제적 수준의 객식(총30실)과 레스토랑을 운영하고 있다. \n\n국내외 학술교류를 위한 주거 공간이고 연못의 수변공간을 최대한 살린 휴식공간이다.";
                break;
            //11호관
            case "복지회관":
                present.text = "다각형 유리로 이루어진 독특한 외관과 조립식 인공암벽이 설치되어 있으며 \n\n서점, 은행, 사진관등 편의시설들이 입주하고 있다." +
                    "학생식당(700석)과 다목적 공연장(286석)을 보유하고 있다.";
                break;
            //17호관
            case "학생회관":
                present.text = "학생회관은 음식점과 학생편의시설들이 있으며 대학교의 동아리실이 있다.";
                break;
            //18호관
            case "생활원":
                present.text = "13층 규모의 3개동이 있고 총 965명의 학생을 수용하고 있으며 식당, 휴게실, 세탁실등 학생 편의시설이 운영되고 있다.";
                break;
            //20호관
            case "스포츠센터":
                present.text = "스포츠센터에는 수영장, 스쿼스장, 무도장, 헬스장, 에어로빅실 등이 설치되어 있고, 40타석의 골프연습장, 실내퍼팅장, 실내골프장을 운영하고 있다.";
                break;
            //21호관
            case "체육관":
                present.text = "학생들의 체력증진을 위해 1층에는 메인플로어, 운동장비창고가 있고 2층에는 관람석이 있다.";
                break;
            //23호관
            case "강당 및 공연장":
                present.text = "1000석 규모의 강당과 500석 규모의 공연장, 대학과 지역사회가 공유하는 문화적 중심 시설이고 화합을 상징하는 원형을 모티브로 건물을 설계하였다.";
                break;
            //24호관
            case "전망타워":
                present.text = "송도시대를 맞이한 인천대학교의 랜드마크이며 대학캠퍼스 전경 및 인천대교 조망이 보인다." +
                    "안내데스크 및 글로벌 카페를 운영하고 있다.";
                break;
            //25호관
            case "어린이집":
                present.text = "2013년 3월부터『인천대학교 연수구립 해둥실어린이집』을 위탁 운영 중에 있다.";
                break;
            case "제2공동실험실습관":
                present.text = "";
                break;
            default:
                present.text = "정보 불러오기에 실패하였습니다. 다시 시도해주세요.";
                break;
        }
    }

    public void ExitBtn()
    {
        Close();
    }
}