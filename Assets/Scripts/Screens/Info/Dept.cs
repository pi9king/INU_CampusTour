using System.Collections;
using System.Collections.Generic;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dept : ScreenBase
{

    public Text title1;
    public Text title2;
    string titletext;
    public Text link;
    public Text info;
    public Image curri;
    public Image curri2;
    public Image curri3;
    public Image curri4;
    public GameObject night;
    public Text[] examresult;

    protected override void OnOpen(ScreenArgs args)
    {
        NameArgs nameArgs = args as NameArgs;
        titletext = nameArgs != null ? nameArgs.Name : string.Empty;
        title1.text = titletext;
        title2.text = titletext;

        switch (titletext)
        {
            //5호관 자연대
            case "수학과":
                link.text = "http://math.inu.ac.kr/";
                info.text = "수학과에서는 수학의 기본원리를 이해하는 창조적 사고를 지닌 전문인 육성을 목표로 대수학, 기하학, 해석학, 위상수학, 확률통계학 등을 다루고 있으며, 컴퓨터와 관련된 수치해석학 등 응용수학을 다루어 현시대에 알맞은 교육을 제공하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/수학과커리큘럼");
                examresult[0].text = "2.42";
                examresult[1].text = "11";
                examresult[2].text = "2.85";
                examresult[3].text = "11";
                examresult[4].text = "2.62";
                examresult[5].text = "4";
                examresult[6].text = "3.47";
                examresult[7].text = "1";
                examresult[8].text = "2.84";
                examresult[9].text = "1";
                examresult[10].text = "79.88";
                examresult[11].text = "16";
                break;
            case "물리학과":
                link.text = "http://physics.inu.ac.kr/";
                info.text = "물리학과에서는 자연계의 기본 원리에 대한 이론과 실험의 교육 및 탐구활동을 통해 자연현상을 이해하고, 응용능력을 지닌 연구 및 교육분야의 전문인력을 양성할 수 있는 체계적 교육 및 연구 프로그램을 제공하고 있다.\n\n" +
                    "아울러 전자공학과, 재료공학과와 연계하여 광전자연계전공 교육과정을 운영하고 있으며, 이들 분야에 대한 다양한 첨단 교육 및 연구활동을 학생들이 직접 참여할 수 있도록 교과과정이 제공되고 있으며, 학생들의 자발적 탐구활동을 적극 지원하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/물리학과커리큘럼");
                examresult[0].text = "3.18";
                examresult[1].text = "3";
                examresult[2].text = "3.03";
                examresult[3].text = "8";
                examresult[4].text = "3.21";
                examresult[5].text = "6";
                examresult[6].text = "4.32";
                examresult[7].text = "2";
                examresult[8].text = "3.11";
                examresult[9].text = "0";
                examresult[10].text = "75.37";
                examresult[11].text = "26";
                break;
            case "화학과":
                link.text = "http://chem.inu.ac.kr/";
                info.text = "화학은 기초과학의 한 분야로서, 오랜 시간에 걸쳐 발견되고 정립되어 온 과학의 기본원리와 이론을 토대로 자연의 제 현상들을 규명하는 학문이다.\n화학은 물리화학, 유기화학, 무기화학, 분석화학 등의 여러 세부 분야들이 서로 밀접하게 연관되어 있어, 이들 세부 분야 전반에 걸친 소양과 이해가 필요한 학문이다. 이러한 학문분야의 특성을 반영하여, 화학과는 다양한 여러 화학 전공 분야들에 대한 교육과 연구를 병행하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/화학과커리큘럼");
                examresult[0].text = "2.42";
                examresult[1].text = "10";
                examresult[2].text = "2.44";
                examresult[3].text = "7";
                examresult[4].text = "2.58";
                examresult[5].text = "0";
                examresult[6].text = "3.14";
                examresult[7].text = "0";
                examresult[8].text = "3.35";
                examresult[9].text = "0";
                examresult[10].text = "79.20";
                examresult[11].text = "31";
                break;
            case "패션산업학과":
                link.text = "http://uifashion.inu.ac.kr/";
                info.text = "패션산업학과는 창의성과 실용성, 국제적 역량을 두루 갖춘 패션 전문인을 양성하는 데에 목적을 두고 있으며 이를 위해 패션산업 전반에 관한 폭 넓은 이론과 실기능력을 습득하게 하고 현장실무 능력을 배양하며 글로벌 패션마켓을 필요한 국제적 감각을 기르는데 역점을 두고 교육과정을 운영하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/패션산업학과커리큘럼");
                examresult[0].text = "2.13";
                examresult[1].text = "4";
                examresult[2].text = "2.68";
                examresult[3].text = "20";
                examresult[4].text = "3.28";
                examresult[5].text = "3";
                examresult[6].text = "3.22";
                examresult[7].text = "2";
                examresult[8].text = "3.04";
                examresult[9].text = "0";
                examresult[10].text = "80.52";
                examresult[11].text = "23";
                break;
            case "해양학과":
                link.text = "http://marine.inu.ac.kr/";
                info.text = "지역 기반 대학 특성화 전략으로 해양학과를 설립하여 국내외 해양 및 환경 관련 기관과의 융합 개방형 시스템을 운영으로 해양과학 분야의 혁신적 지식과 실천적 능력 함양을 통하여 21세기 미래 사회가 요구하는 실력있고, 창의적이며 진취적인 인성을 가진 해양 분야 인재를 육성하고자 하는데 그 목적이 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/해양학과커리큘럼");
                examresult[0].text = "3.20";
                examresult[1].text = "4";
                examresult[2].text = "2.93";
                examresult[3].text = "2";
                examresult[4].text = "3.18";
                examresult[5].text = "4";
                examresult[6].text = "4.03";
                examresult[7].text = "0";
                examresult[8].text = "";
                examresult[9].text = "2";
                examresult[10].text = "74.79";
                examresult[11].text = "11";
                break;
            case "소비자아동학과":
                link.text = "http://ccs.inu.ac.kr/";
                info.text = "소비자아동학과는 소비자학 분야와 아동학 분야의 전문인 양성을 목표로 1980년 10월 가정학과로 출발하였으며\n1999년 11월 생활자원관리학전공으로, 2003년 11월에는 세부 전공분야의 특성을 강조하여 소비자아동학과로 학과 명칭을 변경하여 운영 중에 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/소비자아동학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/소비자아동학과커리큘럼2");
                examresult[0].text = "2.45";
                examresult[1].text = "2";
                examresult[2].text = "2.74";
                examresult[3].text = "14";
                examresult[4].text = "3.78";
                examresult[5].text = "4";
                examresult[6].text = "3.52";
                examresult[7].text = "0";
                examresult[8].text = "3.87";
                examresult[9].text = "0";
                examresult[10].text = "81.17";
                examresult[11].text = "30";
                break;

            //7호관 정보기술대
            case "컴퓨터공학부":
                link.text = "http://cse.inu.ac.kr/";
                info.text = "끊임없이 변화하는 세계의 흐름 속에서 컴퓨터공학부는 정보기술의 이론적인 발전을 선도함은 물론 산업체의 요구에 부응하는 기술개발 인력양성을 목적으로 컴퓨터 하드웨어, 소프트웨어를 포함하여 경영정보시스템, 컴퓨터비젼, 멀티미디어등 여러 응용 분야의 기본이론을 체계적으로 공부하고 있습니다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/컴퓨터공학부커리큘럼");
                night.SetActive(true);
                examresult[0].text = "2.51";
                examresult[1].text = "20";
                examresult[2].text = "2.50";
                examresult[3].text = "18";
                examresult[4].text = "3.02";
                examresult[5].text = "12";
                examresult[6].text = "3.57";
                examresult[7].text = "3";
                examresult[8].text = "3.51";
                examresult[9].text = "0";
                examresult[10].text = "79.46";
                examresult[11].text = "46";
                examresult[12].text = "3.43";
                examresult[13].text = "1";
                examresult[22].text = "71.55";
                examresult[23].text = "16";
                break;
            case "정보통신공학과":
                link.text = "http://ite.inu.ac.kr/";
                info.text = "정보통신공학과는 21세기 정보사회의 근간을 이루는 정보통신 분야를 학습하는 학과이다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/정보통신학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/정보통신학과커리큘럼2");
                examresult[0].text = "3.12";
                examresult[1].text = "6";
                examresult[2].text = "3.36";
                examresult[3].text = "24";
                examresult[4].text = "3.15";
                examresult[5].text = "3";
                examresult[6].text = "3.72";
                examresult[7].text = "1";
                examresult[8].text = "3.13";
                examresult[9].text = "0";
                examresult[10].text = "77.47";
                examresult[11].text = "46";
                break;
            case "임베디드시스템공학과":
                link.text = "http://ese.inu.ac.kr/";
                info.text = "임베디드 기술이란 우리를 둘러싸고 각종 사물에 지능 소프트웨어을 부여하는 기술이다." +
                    "우리 학과에서는 임베디드 시스템을 위한 융합 소프트웨어 설계 및 개발 능력을 갖춘 글로벌 인재양성을 목표로 충분한 이론적 지식과 산업체의 수요 중심의 실무 기술을 융합한 특화된 교육 과정을 운영하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/임베디드커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/임베디드커리큘럼2");
                examresult[0].text = "3.16";
                examresult[1].text = "1";
                examresult[2].text = "3.16";
                examresult[3].text = "7";
                examresult[4].text = "3.17";
                examresult[5].text = "5";
                examresult[6].text = "4.64";
                examresult[7].text = "1";
                examresult[8].text = "4.45";
                examresult[9].text = "1";
                examresult[10].text = "80.87";
                examresult[11].text = "16";
                break;

            //8호관 공과대학;
            case "기계로봇공학과":
                link.text = "http://me.inu.ac.kr/";
                info.text = "기계로봇공학은 기본역학, 공업역학, 고체역학, 유체역학, 열역학과를 이를 응용한 설계, 생산 및 로봇공학분야 응용의 전 과정에 이르는 광범위한 분야를 다루는 창의적인 종합 예술적 학문이다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/기계로봇공학과커리큘럼");
                night.SetActive(true);
                examresult[0].text = "2.18";
                examresult[1].text = "33";
                examresult[2].text = "2.44";
                examresult[3].text = "26";
                examresult[4].text = "2.45";
                examresult[5].text = "13";
                examresult[6].text = "3.03";
                examresult[7].text = "0";
                examresult[8].text = "3.41";
                examresult[9].text = "0";
                examresult[10].text = "79.30";
                examresult[11].text = "34";
                examresult[12].text = "3.33";
                examresult[13].text = "0";
                examresult[22].text = "71.37";
                examresult[23].text = "13";
                break;
            case "자동차공학":
                link.text = "http://ve.inu.ac.kr";
                info.text = "자동차공학전공은 자동차의 설계 및 제조와 관련한 이론 및 기술을 연구하는 응용공학으로서의 동역학 및 진동, 고체역학, 열유체역학, 제어및 계측, 트라이볼로지로 영역이 나뉘어지며 자동차 정비기사, 자동차 검사기사 등의 자격증을 취득할 수 있고 자동차 및 기타 차량의 설계제조분야, 자동차관련공사공단 등으로 진출 할 수 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/자동차공학커리큘럼");
                examresult[0].text = "2.18";
                examresult[1].text = "33";
                examresult[2].text = "2.44";
                examresult[3].text = "26";
                examresult[4].text = "2.45";
                examresult[5].text = "13";
                examresult[6].text = "3.03";
                examresult[7].text = "0";
                examresult[8].text = "3.41";
                examresult[9].text = "0";
                examresult[10].text = "79.30";
                examresult[11].text = "34";
                break;
            case "메카트로닉스공학":
                link.text = "http://meca.inu.ac.kr/";
                info.text = "메카트로닉스 기술 제품들은 기계공학이라는 기반기술에 전기전자기술과 컴퓨터를 이용한 정보처리 기술을 접목시켜 탄생시킨 걸작품들이다. 본 학과에서는 이러한 분야의 기본기술들을 습득하여 필요에 따라 활용할 수 있도록 함으로써, 메카트로닉스 기술제품들을 설계, 제작, 운전보수할 수 있는 엔지니어를 양성한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/메카트로닉스커리큘럼");
                examresult[0].text = "2.57";
                examresult[1].text = "3";
                examresult[2].text = "2.62";
                examresult[3].text = "5";
                examresult[4].text = "3.06";
                examresult[5].text = "0";
                examresult[6].text = "3.67";
                examresult[7].text = "3";
                examresult[8].text = "3.37";
                examresult[9].text = "0";
                examresult[10].text = "77.63";
                examresult[11].text = "17";
                break;
            case "전기공학과":
                link.text = "http://elec.inu.ac.kr/";
                info.text = "전기공학은 국가산업과 국민복지의 원동력인 “전기에너지”에 관련된 모든 분야와 정보기술, 가전, 제조업 분야 등의 기반기술을 담당하는 학문분야로서 어느 시대에서나 산업, 문화, 예술에서 첨단 기술에 이르기까지 실로 지대한 영향을 미치게 된다. 본 전기공학과는 이러한 사회적 명제 구현을 지향목표로 삼아, 국가 산업 발전과 국민 복지 향상에 봉사할 미래 첨단사회의 신기술인의 배출을 최우선의 목표로 정하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/전기공학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/전기공학과커리큘럼2");
                examresult[0].text = "2.71";
                examresult[1].text = "13";
                examresult[2].text = "2.69";
                examresult[3].text = "25";
                examresult[4].text = "2.97";
                examresult[5].text = "8";
                examresult[6].text = "3.50";
                examresult[7].text = "1";
                examresult[8].text = "3.53";
                examresult[9].text = "1";
                examresult[10].text = "77.38";
                examresult[11].text = "18";
                break;
            case "전자공학과":
                link.text = "http://ee.inu.ac.kr/";
                info.text = "인천대학교 전자공학과는 1979년 인천대학교 개교 당시 설립된 학과로 그 동안 많은 졸업생을 배출하면서 꾸준히 성장해 왔습니다.\n\n1994년 인천대학의 시립화와 더불어 전자공학과는 우수교원 초빙과 우수학생 유치 등 명문 학과로의 발전을 위한 발판을 마련하였습니다.\n\n그 후 전문 전자공학인력 양성과 지역사회 봉사 및 발전에 이바지하면서 꾸준히 발전해 왔습니다. \n\n2006년도에는 정보통신부지원 IT분야 교육경쟁력강화사업(NEXT) 유치했으며, 대학교육협의회에서 주관하는 2006년도 학문분야 평가에서 최우수 학과로 선정되는 등 국내 명문 학과로 도약을 하였습니다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/전자공학과커리큘럼");
                night.SetActive(true);
                examresult[0].text = "2.45";
                examresult[1].text = "25";
                examresult[2].text = "2.58";
                examresult[3].text = "25";
                examresult[4].text = "2.97";
                examresult[5].text = "13";
                examresult[6].text = "2.90";
                examresult[7].text = "2";
                examresult[8].text = "3.52";
                examresult[9].text = "0";
                examresult[10].text = "79.35";
                examresult[11].text = "18";
                examresult[12].text = "3.79";
                examresult[13].text = "7";
                examresult[22].text = "70.72";
                examresult[23].text = "10";

                break;
            case "산업경영공학과":
                link.text = "http://ime.inu.ac.kr/";
                info.text = "산업경영공학은 기업시스템이 고도화 복잡화되어 가는 추세에서 인간, 재료, 설비로 구성된 종합적인 시스템을 설계 · 개선 · 설치 운영하는 분야에 대해 공학적인 분석과 설계의 원리 및 방법의 전문적인 지식과 기술을 결합하여 시스템에서 얻어지는 결과를 파악하고 예측하며 평가할 수 있는 능력을 갖추어 시스템 Output 의 최적화를 목표로 하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/산업경영커리큘럼");
                night.SetActive(true);
                examresult[0].text = "2.88";
                examresult[1].text = "12";
                examresult[2].text = "2.73";
                examresult[3].text = "4";
                examresult[4].text = "3.18";
                examresult[5].text = "4";
                examresult[6].text = "3.74";
                examresult[7].text = "1";
                examresult[8].text = "3.85";
                examresult[9].text = "0";
                examresult[10].text = "77.52";
                examresult[11].text = "8";
                examresult[12].text = "3.52";
                examresult[13].text = "1";
                examresult[22].text = "70.05";
                examresult[23].text = "11";
                break;
            case "신소재공학과":
                link.text = "http://mse.inu.ac.kr/";
                info.text = "신소재공학과의 교육은 공학 재료의 전반에 대하여 물리ㆍ화학의 기초 이론을 바탕으로 하여 재료의 특성을 이해, 규명하고 우수하고 새로운 물성과 특성을 갖는 물질 및 효과적인 제조방법을 연구하는 것에 목적을 두고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/신소재공학커리큘럼");
                examresult[0].text = "2.10";
                examresult[1].text = "8";
                examresult[2].text = "2.47";
                examresult[3].text = "8";
                examresult[4].text = "2.76";
                examresult[5].text = "10";
                examresult[6].text = "3.03";
                examresult[7].text = "3";
                examresult[8].text = "3.05";
                examresult[9].text = "2";
                examresult[10].text = "78.34";
                examresult[11].text = "8";
                break;
            case "안전공학과":
                link.text = "http://safety.inu.ac.kr/";
                info.text = "안전공학(Safety Engineering)은 다양하고 대형화 되어가고 있는 각종 산업재해에 대비할 수 있는 학재적인 종합공학을 바탕으로 유해 작업 환경 요인 및 위험에 대한 분석ㆍ평가능력을 배양하고 공학적인 재해방지ㆍ예방 대책을 제시할 수 있는 전문적인 안전ㆍ보건 기술 인력의 양성과 더불어 지식기반 사회를 선도 할 수 있는 유능하고 창의적이며 자주적, 민주적 인격을 갖춘 지도적 인재를 양성하여 지역 사회 발전 및 안전의 선도를 목적으로 하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/안전공학과커리큘럼");
                examresult[0].text = "2.48";
                examresult[1].text = "2";
                examresult[2].text = "2.85";
                examresult[3].text = "2";
                examresult[4].text = "3.07";
                examresult[5].text = "5";
                examresult[6].text = "4.64";
                examresult[7].text = "2";
                examresult[8].text = "3.44";
                examresult[9].text = "1";
                examresult[10].text = "77.01";
                examresult[11].text = "8";
                break;
            case "에너지화학공학과":
                link.text = "http://echeme.inu.ac.kr/";
                info.text = "세기내 화석에너지의 고갈이 예상되는 상황에서 신·재생에너지의 개발은 인류생존의 문제와 직결되는 범세계적 문제로 부각되고 있다. \n차세대 신 에너지원으로 주목받고 있는 수소에너지, 태양열, 연료전지, 바이오에너지 등을 포함한 신·재생에너지의 이용을 위한 핵심요소 기술개발과 새로운 개념의 기술 인력이 절실히 요구되고 있지만, 기존학과 중심의 교육과정으로는 이러한 수요를 충족시키지 못하고 있다. 에너지화학공학과는 차세대 에너지 신기술 산업을 담당할 창의적인 인력 양성을 그 목적으로 하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/에너지화학공학과커리큘럼");
                examresult[0].text = "2.00";
                examresult[1].text = "4";
                examresult[2].text = "2.06";
                examresult[3].text = "11";
                examresult[4].text = "2.37";
                examresult[5].text = "5";
                examresult[6].text = "2.69";
                examresult[7].text = "1";
                examresult[8].text = "2.47";
                examresult[9].text = "0";
                examresult[10].text = "80.58";
                examresult[11].text = "14";
                break;

            //사회과학대학
            case "사회복지학과":
                link.text = "http://socialwelfare.inu.ac.kr/ ";
                info.text = "사회복지는 사회구성원들이 기본적인 욕구를 충족시킬 수 있도록 지원하고 사회문제를 해결하는 조직화된 사회적 활동의 총체로, 사회복지학은 개인, 가족, 집단,지역사회, 국가차원의 복지문제를 이해하고 그 해결방법을 연구하고 실천하는 응용학문이다. \n\n" +
                    "인천대학교 사회복지학과는 지역사회 구성원의 기본적인 욕구를 해결하고 사회문제를 해결할 수 있는 사회복지 전문 인력을 양성함으로써 복지사회 건설에 기여하려는 교육목표를 가지고 있다. 이를 위해 학생들이 사회복지의 이론과 실천을 겸비할 수 있도록 사회복지의 기본 철학, 정책,행정, 서비스에 대한 지식을 습득하고 사회현상 및 제반 사회문제에 대한 비판적인 시각을 키울 수 있는 다양한 교육 프로그램을 제공하고 있다. 또한, 다양한 사회복지 현장을 방문하여 견학하고 관심분야를 발굴하여 현장경험을 쌓을 기회를 제공하고 있다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/사회복지학과커리큘럼");
                examresult[0].text = "1.58";
                examresult[1].text = "2";
                examresult[2].text = "2.42";
                examresult[3].text = "11";
                examresult[4].text = "2.73";
                examresult[5].text = "0";
                examresult[6].text = "3.64";
                examresult[7].text = "1";
                examresult[8].text = "0";
                examresult[9].text = "0";
                examresult[10].text = "79.88";
                examresult[11].text = "12";
                break;
            case "신문방송학과":
                link.text = "http://newdays.inu.ac.kr/";
                info.text = "신문방송학 교육은 현대 사회를 유지하기 위한 핵심적인 요소인 제반 커뮤니케이션 현상들에 대한 학습과 연구를 통하여 전문 관련 분야에 종사할 인재를 배양하는데 목적이 있다.\n\n"+
                    "이와 관련하여, 신문방송학과에서는 모든 커뮤니케이션의 기본인 인간 커뮤니케이션을 비롯하여 신문과 방송, 광고, 홍보, 영화, 뉴미디어 등을 포함하는 매스 커뮤니케이션, 그리고 영상문화를 포함한 대중문화 분야에 이르기까지 다양한 영역의 전문가 배출에 필요한 이론 및 실무에 관하여 공부한다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/신문방송학과커리큘럼");
                examresult[0].text = "2.05";
                examresult[1].text = "7";
                examresult[2].text = "1.86";
                examresult[3].text = "9";
                examresult[4].text = "2.47";
                examresult[5].text = "0";
                examresult[6].text = "2.68";
                examresult[7].text = "0";
                examresult[8].text = "2.69";
                examresult[9].text = "0";
                examresult[10].text = "84.97";
                examresult[11].text = "4";
                break;
            case "문헌정보학과":
                link.text = "http://lis.inu.ac.kr/";
                info.text = "문헌정보학과는 2010년 통합 인천대학교에서 신설된 학과이다. 문헌정보학은 수많은 정보와 지식 가운데 최적의 것을 선택하고 수집하여, 이를 체계적으로 정리하여 편리하게 이용하기 위한 수단과 방법을 구명하고, 이를 실제 적용하기 위한 학문으로 전통적인 도서관학분야와 컴퓨터와 더불어 발전한 정보학분야가 통합 발전한 것이다.\n\n"+
                    "문헌정보학과 학생들은 자료조직, 도서관경영, 정보학, 정보봉사 및 서지학 등의 필요한 교과과정을 이수하여, 문헌정보학 분야에서 책임 있는 업무를 이행하는데 요구되는 충분한 지식과 숙련된 기술을 갖추게 된다. 졸업 후에는 국 공립도서관, 초ㆍ중등학교 도서관, 대학도서관, 각종 기업체 연구소, 언론기관 등의 기술정보실 및 DB개발관련 분야에서 정보전문가로서 활동하게 된다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/문헌정보학과커리큘럼");
                examresult[0].text = "2.13";
                examresult[1].text = "9";
                examresult[2].text = "1.83";
                examresult[3].text = "2";
                examresult[4].text = "2.53";
                examresult[5].text = "2";
                examresult[6].text = "3.36";
                examresult[7].text = "1";
                examresult[8].text = "3.06";
                examresult[9].text = "0";
                examresult[10].text = "81.29";
                examresult[11].text = "10";
                break;
            case "창의인재개발학과":
                link.text = "http://hrd.inu.ac.kr/";
                info.text = "인천대학교 창의인재개발학과는 21세기 지식기반사회에서 부가가치 창출의 핵심자원으로 평가되고 있는 창의적 인재를 양성하는 기업교육 전문가, 즉 HRD(Human Resource Development) 전문가를 배출하기 위한 목적으로 전국 최초로 대학 학부과정에 신설되었다.\n\n"+
                    "우수한 인적자원 확보가 기업은 물론 국가의 혁신과 발전을 위한 핵심요소가 부각되고 있는 현대사회에서 창의적 인재 양성은 기업과 국가의 생존과 직결된 문제라 할 수 있으며, 창의인재개발학과는 이러한 시대적 흐름에 발맞추어 기업 및 조직에서 창의성, 창조적 상상력, 창의적 문제해결력을 갖춘 인재를 선발, 교육, 활용할 수 있는 기업교육, HRD 전문가를 배출하는 것을 궁극적 목적으로 하고 있다. 이같은 HRD 전문가로서의 자질과 소양을 갖출 수 있도록 하기 위해, 창의인재개발학과에서는 창의성에 기초하여 창의적 기업교육론, 인적자원개발론, 교수학습전략 및 교수설계방법론, 리더쉽, 커뮤니케이션 및 상담, 첨단 테크놀로지와 HRD, 학습조직과 조직문화 혁신 등 HRD와 관련된 다양한 교육 프로그램을 제공하고 있다.\n\n"+
                    "아울러 기업에서 이루어지고 있는 인적자원개발과 관련된 각종 활동들에 대한 현장 실습 및 실무경험을 다양하게 제공함으로써, 이론과 실행능력을 함께 겸비한 전국 최고의 우수한 HRD 전문가 양성을 지향하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/창의인재개발학과커리큘럼");
                examresult[0].text = "2.41";
                examresult[1].text = "4";
                examresult[2].text = "2.58";
                examresult[3].text = "7";
                examresult[4].text = "3.11";
                examresult[5].text = "1";
                examresult[6].text = "3.37";
                examresult[7].text = "0";
                examresult[8].text = "2.68";
                examresult[9].text = "0";
                examresult[10].text = "82.73";
                examresult[11].text = "5";
                break;

            //글로벌법정경대학
            case "법학부":
                link.text = "http://law.inu.ac.kr/";
                info.text = "법과대학의 교육목표는 인천대학교 특성화 전략에 맞춤 더 법학교육을 이론법학교육 중심에서 실질법학교육 중심으로 전환하여\n" +
                    "\n전문법조인 양성\n\n" +
                    "직역별 법률전문가 양성\n\n" +
                    "동북아중심시대를 대비한 법률전문가 양성" +
                    "을 목표로 하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/법학부커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/법학부커리큘럼2");
                curri3.sprite = Resources.Load<Sprite>("Dept_curriculum/법학부커리큘럼3");
                curri4.sprite = Resources.Load<Sprite>("Dept_curriculum/법학부커리큘럼4");
                examresult[0].text = "2.29";
                examresult[1].text = "14";
                examresult[2].text = "2.11";
                examresult[3].text = "13";
                examresult[4].text = "2.83";
                examresult[5].text = "5";
                examresult[6].text = "3.09";
                examresult[7].text = "3";
                examresult[8].text = "4.02";
                examresult[9].text = "0";
                examresult[10].text = "82.90";
                examresult[11].text = "47";
                break;
            case "행정학과":
                link.text = "http://uipa.inu.ac.kr/";
                info.text = "행정학과는 공직이나 공기업을 관리하는 데에서 비롯되는 조직 내부의 문제뿐만 아니라 공무원이나 공기업 직원이 시민사회와의 관계 속에서 공공의 문제를 어떻게 풀어나갈 것인지에 대해 학습하고 연구한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/행정학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/행정학과커리큘럼2");
                examresult[0].text = "1.88";
                examresult[1].text = "8";
                examresult[2].text = "3.06";
                examresult[3].text = "11";
                examresult[4].text = "2.69";
                examresult[5].text = "7";
                examresult[6].text = "2.76";
                examresult[7].text = "0";
                examresult[8].text = "3.72";
                examresult[9].text = "1";
                examresult[10].text = "82.22";
                examresult[11].text = "51";
                break;
            case "정치외교학과":
                link.text = "http://politics.inu.ac.kr/";
                info.text = "정치외교학이 국가 “안”과 국가 “밖”에서 일어나는 정치현상을 탐구하여 인류의 평하와 번영에 기여하는 것을 목적으로 하는 학문이므로\n우리대학 정치외교학과는 민주시민사회를 이끌어갈 창의적이고 자주적이며 민주적인 지도자와 동북아지역 전문가를 양성하는데 중점을 두고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/정치외교학과커리큘럼");
                examresult[0].text = "2.10";
                examresult[1].text = "4";
                examresult[2].text = "2.01";
                examresult[3].text = "2";
                examresult[4].text = "2.85";
                examresult[5].text = "7";
                examresult[6].text = "2.88";
                examresult[7].text = "1";
                examresult[8].text = "4.74";
                examresult[9].text = "2";
                examresult[10].text = "83.05";
                examresult[11].text = "28";
                break;
            case "경제학과":
                link.text = "http://econ.inu.ac.kr/";
                info.text = "인천대학교 경제학과는 한국 근대화와 현대화에 없어서는 안 될 인재를 수업이 배출하는 등 한국 경제학 연구의 총본산임을 자부하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/경제학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/경제학과커리큘럼2");
                night.SetActive(true);
                examresult[0].text = "2.54";
                examresult[1].text = "5";
                examresult[2].text = "3.14";
                examresult[3].text = "13";
                examresult[4].text = "2.95";
                examresult[5].text = "9";
                examresult[6].text = "2.43";
                examresult[7].text = "4";
                examresult[8].text = "3.27";
                examresult[9].text = "0";
                examresult[10].text = "83.21";
                examresult[11].text = "41";
                examresult[12].text = "3.16";
                examresult[13].text = "2";
                examresult[22].text = "76.36";
                examresult[23].text = "10";
                break;
            case "무역학부":
                link.text = "http://trade.inu.ac.kr/";
                info.text = "1979년 설립 이후 경상대학 무역학과로 1990년대 후반까지 편제되어 오다가 학문의 특성 및 사회적 흐름에 따라 1학년의 경우 경상학부제로 입학하여 2학년 진학 시 경영, 무역학과로 분과되는 학부 모집제로 전환하였다.\n" +
                    "또한 2006년에는 대학의 특성화 사업 및 전공부문 강화를 위하여 소속 단과대학을 경상대학에서 동북아경제통상대학 경제무역계열 무역학 전공으로 변경하여 현재에 이르고 있으며, 2010년부터는 무역학부로 모집단위를 변경하여 운영하고있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/무역학부커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/무역학부커리큘럼2");
                curri3.sprite = Resources.Load<Sprite>("Dept_curriculum/무역학부커리큘럼3");
                night.SetActive(true);
                examresult[0].text = "2.13";
                examresult[1].text = "10";
                examresult[2].text = "1.96";
                examresult[3].text = "21";
                examresult[4].text = "2.47";
                examresult[5].text = "4";
                examresult[6].text = "3.68";
                examresult[7].text = "0";
                examresult[8].text = "3.02";
                examresult[9].text = "1";
                examresult[10].text = "84.07";
                examresult[11].text = "58";
                examresult[12].text = "3.04";
                examresult[13].text = "4";
                examresult[22].text = "76.79";
                examresult[23].text = "10";
                break;

            //동북아국제통상
            case "동북아통상전공":
                link.text = "http://sonas.inu.ac.kr/";
                info.text = "동북아국제통상학부는 광범위하고 심층적인 시점에서 동북아를 둘러싼 세계 통상환경과 이에 대한 동북아 각국들의 통상현실 및 통상정책 등을 학습하고, 미래의 유능한 동북아통상전문가를 양성하는 것을 그 목표로 삼고 있습니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/동북아국제통상전공커리큘럼");
                examresult[0].text = "1.51";
                examresult[1].text = "7";
                examresult[4].text = "1.82";
                examresult[5].text = "1";
                examresult[10].text = "91.01";
                examresult[11].text = "34";
                break;
            case "한국통상전공":
                link.text = "http://sonas.inu.ac.kr/";
                info.text = "동북아국제통상학부는 광범위하고 심층적인 시점에서 동북아를 둘러싼 세계 통상환경과 이에 대한 동북아 각국들의 통상현실 및 통상정책 등을 학습하고, 미래의 유능한 동북아통상전문가를 양성하는 것을 그 목표로 삼고 있습니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/동북아국제통상전공커리큘럼");
                examresult[0].text = "1.51";
                examresult[1].text = "7";
                examresult[4].text = "1.82";
                examresult[5].text = "1";
                examresult[10].text = "91.01";
                examresult[11].text = "34";
                break;

            //경영대학
            case "경영학부":
                link.text = "http://management.inu.ac.kr/";
                info.text = "경영학부는 국제화시대에서 기업이 필요로 하는 미래경영자 양성을 목표로 하고 있으며 학생들이 재학기간 중 각 조직의 목표달성을 위한 전략, 마케팅, 인사, 재무관리, 회계, 생산관리, MIS 등을 이해하고 실제 조직에 응용할 수 있도록 교육한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/경영학부커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/경영학부커리큘럼2");
                examresult[0].text = "2.41";
                examresult[1].text = "22";
                examresult[2].text = "2.54";
                examresult[3].text = "39";
                examresult[4].text = "2.62";
                examresult[5].text = "13";
                examresult[6].text = "3.43";
                examresult[7].text = "2";
                examresult[8].text = "3.99";
                examresult[9].text = "0";
                examresult[10].text = "83.76";
                examresult[11].text = "65";
                break;
            case "세무회계학과":
                link.text = "http://tax.inu.ac.kr/";
                info.text = "세무회계학과는 세무 및 회계 분야의 전문가를 양성하고 기업과 세무행정 분야에 필요한 유능한 인재의 양성을 목표로 설치되었다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/세무회계학과커리큘럼");
                examresult[0].text = "2.17";
                examresult[1].text = "1";
                examresult[2].text = "2.48";
                examresult[3].text = "5";
                examresult[4].text = "2.69";
                examresult[5].text = "3";
                examresult[6].text = "2.59";
                examresult[7].text = "3";
                examresult[8].text = "1.50";
                examresult[9].text = "0";
                examresult[10].text = "86.10";
                examresult[11].text = "4";
                break;

            //인문대학
            case "국어국문학과":
                link.text = "http://korean.inu.ac.kr/";
                info.text = "국어국문학과는 인천대학이 공과대학에서 종합대학으로 전환한 1980년 10월 2일에 학과 설치인가를 받아 이듬해인 1981년 첫 입학생을 받았다. 그 후 현재까지 약 800여명의 졸업생을 배출 했으며 2012년 현재 120여명의 학생이 재학 중이다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/국어국문학과커리큘럼");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/국어국문학과커리큘럼2");
                examresult[0].text = "2.59";
                examresult[1].text = "9";
                examresult[2].text = "2.01";
                examresult[3].text = "4";
                examresult[4].text = "2.52";
                examresult[5].text = "1";
                examresult[6].text = "3.05";
                examresult[7].text = "0";
                examresult[8].text = "2.44";
                examresult[9].text = "1";
                examresult[10].text = "82.85";
                examresult[11].text = "5";
                break;
            case "영어영문학과":
                link.text = "http://korean.inu.ac.kr/";
                info.text = "인천대학교 영어영문학과는 인문학적 소양과 고급 영어 구사 능력 배양이라는 교육 목표의 실현을 통해 전 세계 국가들과의 교류, 협력을 증진할 수 있는 인재를 양성하고 있습니다. 또한 송도국제도시 유일의 거점 국립법인대학 영어영문학과의 위상과 지리적 특성을 최대한 활용하여 다양한 국제기구 관련 기관 및 기업들과의 교류와 현장 학습 기회를 통해 학생들이 자신의 꿈을 이루어 갈 수 있도록 돕고 있습니다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/영어영문학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/영어영문학과커리큘럼2");
                examresult[0].text = "2.05";
                examresult[1].text = "13";
                examresult[2].text = "3.61";
                examresult[3].text = "11";
                examresult[4].text = "3.17";
                examresult[5].text = "12";
                examresult[6].text = "3.43";
                examresult[7].text = "2";
                examresult[8].text = "3.33";
                examresult[9].text = "0";
                examresult[10].text = "83.21";
                examresult[11].text = "24";
                break;
            case "독어독문학과":
                link.text = "http://german.inu.ac.kr/";
                info.text = "독어독문학과의 교육목표는 독일어에 대한 실용적 언어능력과 독일문학에 대한 지식을 습득하여 학문적 기초를 확립하고 독일문화와 독일지역학을 비롯한 유럽문화지역 전반(정치, 경제, 사회 분야 등)에 대한 이해능력의 심화를 통해 전문지식과 실용성을 갖춘 독일어권 및 유럽지역 문화전문가를 양성하는 것이다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/독어독문학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/독어독문학과커리큘럼2");
                examresult[0].text = "2.33";
                examresult[1].text = "0";
                examresult[2].text = "2.60";
                examresult[3].text = "12";
                examresult[4].text = "4.50";
                examresult[5].text = "5";
                examresult[6].text = "3.00";
                examresult[7].text = "0";
                examresult[8].text = "4.78";
                examresult[9].text = "1";
                examresult[10].text = "81.88";
                examresult[11].text = "5";
                break;
            case "불어불문학과":
                link.text = "http://uifrance.inu.ac.kr/";
                info.text = "1-2학년에서는 개괄적인 문화적 이해와 함께 모든 사회활동에 기본인 언어교육 특히 말하기와 듣기가 중점적으로 이루어집니다. \n\n3-4학년은 언어 능력을 심화하는 한편 문학과 언어학을 포함한 프랑스의 다양한 문화와 지역관련 지식을 함양합니다. \n\n또한 경제에 관심에 있는 학생들에게는 프랑스를 중심으로 유럽의 통상에 대해 공부 할 수 있도록 연계전공으로 유럽 통상학이 마련되어 있습니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/불어불문학과커리큘럼");
                examresult[0].text = "3.24";
                examresult[1].text = "7";
                examresult[2].text = "2.37";
                examresult[3].text = "13";
                examresult[4].text = "3.48";
                examresult[5].text = "2";
                examresult[6].text = "4.34";
                examresult[7].text = "1";
                examresult[8].text = "3.62";
                examresult[9].text = "0";
                examresult[10].text = "81.79";
                examresult[11].text = "14";
                break;
            case "일어일문학과":
                link.text = "http://uijapan.inu.ac.kr/";
                info.text = "일어일문학과는 1980년 10월 2일 학과 설치인가를 받아 이듬해인 1981년 3월 12일 첫 입학생으로 40명을 선발하였다. \n일어일문학과의 교육 및 연구영역은 크게 일본어학과 일본문학 그리고 일본역사ㆍ문화로 나뉜다. \n일본어를 바탕으로 일본어학과 일본문학 그리고 일본문화와 지역학에 이르기까지 폭넓은 학문 영역을 연구함으로써 글로벌시대에 걸맞는 유능한 인재를 양성하는 것에 목적을 두고 있다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/일어일문학과커리큘럼");
                examresult[0].text = "2.46";
                examresult[1].text = "1";
                examresult[2].text = "2.18";
                examresult[3].text = "16";
                examresult[4].text = "3.26";
                examresult[5].text = "4";
                examresult[6].text = "3.98";
                examresult[7].text = "1";
                examresult[8].text = "4.92";
                examresult[9].text = "0";
                examresult[10].text = "81.08";
                examresult[11].text = "16";
                break;
            case "중어중국학과":
                link.text = "http://uichina.inu.ac.kr/";
                info.text = "2002학년도에 신설된 본 학과는 언어와 역사, 철학, 문화, 사회, 정치, 경제 등 중국의 제반 영역에 대한 체계적인 교육을 통하여 중국 전문가를 양성하는데 그 목적을 두고 있다. 특히 중국사회의 심층을 형성하는 문화 전반에 대한 이해에 교육의 중심을 둔다." +
                    "또한 본 학과는 중국과 가장 가깝고 교류가 많은 인천광역시에 중국에 대한 본격적인 연구를 촉발시키고 활성화 시키는 촉매제가 될 수 있도록 하며, 동북아 통상대학 중국통상 전공 등 관련 전공과 더불어 중국에 대한 폭넓은 정보를 제공함으로써 국가와 지역사회의 발전에 기여하고자 한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/중어중국학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/중어중국학과커리큘럼2");
                examresult[0].text = "2.33";
                examresult[1].text = "8";
                examresult[2].text = "2.13";
                examresult[3].text = "12";
                examresult[4].text = "3.05";
                examresult[5].text = "6";
                examresult[6].text = "6.29";
                examresult[7].text = "1";
                examresult[8].text = "3.11";
                examresult[9].text = "0";
                examresult[10].text = "82.40";
                examresult[11].text = "11";
                break;

            //예술체육대학
            case "한국화전공":
                link.text = "http://finearts.inu.ac.kr/";
                info.text = "조형예술학부는 인천대학이 공과대학에서 단과대학으로 전환한 1980년 10월 2일에 학과 설치인가를 받아 이듬해인 1981년 미술학과(한국화, 서양화, 디자인 3개 전공)로 첫 입학생들을 받으며 출발하였다.\n2010년 인천전문대학과 통합하면서 조형예술학부로 개편되어 한국화전공, 서양화전공으로 구성되었다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/한국,서양화전공커리큘럼");
                examresult[0].text = "3.77";
                examresult[1].text = "2";
                examresult[10].text = "67.85";
                examresult[11].text = "3";
                break;
            case "서양화전공":
                link.text = "http://finearts.inu.ac.kr/";
                info.text = "조형예술학부는 인천대학이 공과대학에서 단과대학으로 전환한 1980년 10월 2일에 학과 설치인가를 받아 이듬해인 1981년 미술학과(한국화, 서양화, 디자인 3개 전공)로 첫 입학생들을 받으며 출발하였다.\n2010년 인천전문대학과 통합하면서 조형예술학부로 개편되어 한국화전공, 서양화전공으로 구성되었다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/한국,서양화전공커리큘럼");
                examresult[0].text = "3.54";
                examresult[1].text = "1";
                examresult[10].text = "68.82";
                examresult[11].text = "5";
                break;
            case "디자인학부":
                link.text = "http://design.inu.ac.kr/";
                info.text = "본 디자인학부에서는 21세기 지식정보사회가 요구하는 새로운 디자인문화 창출을 위해 다양한 학제운영을 통하여 균형있는 통합교육을 실시함으로써, 디자인에 관련 된 제반 문제를 합리적으로 해결하고, 유연하고 폭넓은 개인의 디자인적 사고방식을 고취시켜 미래지향적 디자인가치와 비젼을 제시할 수 있는 창의적 디자인 인재양성을 교육목표로 하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/디자인학부커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/디자인학부커리큘럼2");
                examresult[0].text = "2.47";
                examresult[1].text = "6";
                examresult[2].text = "2.41";
                examresult[3].text = "7";
                examresult[10].text = "75.54";
                examresult[11].text = "11";
                break;
            case "공연예술학과":
                link.text = "http://uipa10.inu.ac.kr/";
                info.text = "공연예술학과는 2010년 우리대학의 신설학과로 공연문화를 이끌어갈 창조적인 예술인 양성을 목적으로 한다." +
                    "21세기 현대 사회에 있어 중요한 화두가 된 문화예술을 위해 연기와 무용을 중심으로 한 공연예술을 선도 할 창의적인 인재의 육성으로 한국을 대표하는 예술인은 물론 창조적인 작품 활동을 할 수 있는 전문예술인의 육성으로 한국공연예술의 세계화를 위한 교육에 역점을 둔다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/공연예술학과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/공연예술학과커리큘럼2");
                examresult[0].text = "4.02";
                examresult[1].text = "7";
                examresult[10].text = "48.70";
                examresult[11].text = "3";
                break;
            case "체육학부":
                link.text = "http://inupe.inu.ac.kr/";
                info.text = "본 학과는 스포츠 산업에서 핵심적인 역할을 수행할 전문 인력으로서 의료기관, 대형스포츠센터 또는 이와 유관 기관에서 운동검사, 운동프로그램계획, 운동지도 등을 통하여 성인질환의 예방과 치료에 관한 업무를 수행하는 임상운동전문가(Clinical Exercise Professionals), 스포츠경기 현장에서 운동 상해 예방과 처치 그리고 재활을 담당하며, 이를 통해 선수들의 운동수행 능력을 극대화하는 업무를 수행하는 건강체력전문가(Health and Fitness Professionals), 그리고 스포츠조직을 효과적으로 경영하기 위한 경영전략의 수립, 인사, 마케팅, 재무, 고객관리를 계획 및 실행하는 업무를 수행하는 스포츠 경영 전문가(Sport Management Professionals)양성을 위해 설립, 운영되고 있습니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/체육학부커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/체육학부커리큘럼2");
                examresult[10].text = "67.22";
                examresult[11].text = "8";
                break;
            case "운동건강학부":
                link.text = "http://uiex.inu.ac.kr/";
                info.text = "운동건강학부의 설립취지는 스포츠산업시대에 걸 맞은 전문임상운동사, 건강체력전문가를 배양하는데 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/운동건강학부커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/운동건강학부커리큘럼2");
                examresult[10].text = "66.04";
                examresult[11].text = "6";
                break;

            //도시과학대학
            case "도시행정학과":
                link.text = "http://urban.inu.ac.kr/";
                info.text = "도시행정학과는 도시를 관리하고 경영하는 도시행정인으로서 종합적 사고력과 창조적 능력을 지닌 전문가를 양성하기 위한 실천적인 지식과 소양을 함양시키는 것을 교육방향으로 합니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/도시행정학과커리큘럼");
                examresult[0].text = "2.43";
                examresult[1].text = "0";
                examresult[2].text = "1.95";
                examresult[3].text = "5";
                examresult[4].text = "2.81";
                examresult[5].text = "1";
                examresult[6].text = "3.10";
                examresult[7].text = "0";
                examresult[8].text = "3.32";
                examresult[9].text = "0";
                examresult[10].text = "82.84";
                examresult[11].text = "39";
                break;
            case "건설환경공학":
                link.text = "http://civil.inu.ac.kr/";
                info.text = "건설환경공학은 대자연을 사랑하고 사회기반시설을 다스려 삶의 질을 향상 시키는 학문이다. 즉, 인류에게 주어진 자연환경을 보존하고 개발하여 인류에게 최대한의 편의를 제공하기 위한 제반시설과 방법에 대하여 연구하는 학문이다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/건설환경공학커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/건설환경공학커리큘럼2");
                examresult[0].text = "2.86";
                examresult[1].text = "9";
                examresult[2].text = "3.41";
                examresult[3].text = "5";
                examresult[4].text = "3.23";
                examresult[5].text = "2";
                examresult[6].text = "3.27";
                examresult[7].text = "2";
                examresult[8].text = "4.06";
                examresult[9].text = "0";
                examresult[10].text = "74.88";
                examresult[11].text = "28";
                break;
            case "환경공학":
                link.text = "http://et.inu.ac.kr/";
                info.text = "환경산업은 21세기 '황금알 낳는 시장'이며 유망산업이다. 환경공학전공에서는 지속가능한 개발을 위한 환경경영, 청정생산·자원순환·환경에너지·생태복원 등 녹색산업을 비롯하여 산업화, 도시화 과정에서 발생한 자연생태계 훼손, 각종 환경오염 문제와 지구온난화,기후변화, 오존층파괴, 산성비 등 지구환경문제의 해결방안에 관하여 연구하고 학습한다. 자연환경 및 생활환경의 복원, 오염물질 처리, 기후변화대응 등을 통하여 삶의 질 향상과 쾌적한 자연환경 보전의 추구를 목적으로 한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/환경공학커리큘럼");
                examresult[0].text = "2.86";
                examresult[1].text = "9";
                examresult[2].text = "3.41";
                examresult[3].text = "5";
                examresult[4].text = "3.23";
                examresult[5].text = "2";
                examresult[6].text = "3.27";
                examresult[7].text = "2";
                examresult[8].text = "4.06";
                examresult[9].text = "0";
                examresult[10].text = "74.88";
                examresult[11].text = "28";
                break;
            case "도시공학과":
                link.text = "http://inu.ac.kr/user/ucv";
                info.text = "인천대학교 도시공학과는 다양한 도시문제를 해결하고 인간중심적인 21세기 미래도시를 연구하는 분야로서 공학적인 접근방법(토지이용, 도시공간구조, 첨단교통, 도시생태, 친수하천, 녹색도시환경 등)과 인문ㆍ사회과학적인 접근방법(통계인구학, 활동메커니즘, 사회생태, 도시문화, 지리, 거버넌스 등)을 연계함으로써 도시를 종합적이고 체계적으로 연구하는 분야이다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/도시공학과커리큘럼");
                examresult[0].text = "3.18";
                examresult[1].text = "6";
                examresult[2].text = "3.27";
                examresult[3].text = "11";
                examresult[4].text = "3.83";
                examresult[5].text = "0";
                examresult[6].text = "4.62";
                examresult[7].text = "0";
                examresult[8].text = "3.66";
                examresult[9].text = "1";
                examresult[10].text = "75.10";
                examresult[11].text = "22";
                break;
            case "도시건축학":
                link.text = "http://archi.inu.ac.kr/";
                info.text = "도시건축학전공은 건축학교육인증을 기반으로 국제적 기준의 교육 및 연구를 통해 건축가로서의 자질을 향상하고, 공간에 대한 다양한 분석을 기초로 ‘실무형 인재 교육’과 '녹색건축도시 창조’를 목표로 특성화 교육 및 연구를 선도하고 있습니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/도시건축학커리큘럼");
                examresult[0].text = "2.77";
                examresult[1].text = "14";
                examresult[2].text = "3.39";
                examresult[3].text = "8";
                examresult[4].text = "3.61";
                examresult[5].text = "10";
                examresult[6].text = "5.26";
                examresult[7].text = "3";
                examresult[8].text = "4.41";
                examresult[9].text = "0";
                examresult[10].text = "75.55";
                examresult[11].text = "34";
                break;
            case "건축공학":
                link.text = "http://archi.inu.ac.kr/";
                info.text = "건축공학 전공은 도시건축학부의 3개 심화전공 가운데 건축분야의 공학기술을 중점적으로 교육하고 있으며, 건축구조, 건축재료, 구조역학, 철근콘크리트공학, 강구조학, 건축환경, 건축설비, 건설사업관리, 건축시공학 등의 전문분야를 포함한다. 건축공학전공의 교육목표는 건축공학 및 관련 전문분야의 교육과 연구를 통하여 건축기술자로서의 자질을 향상하고, 졸업 후 산업체와 연구소 등에서 단기간에 현업에 적응할 수 있는 실무지향형 인재를 양성하는 데에 있다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/건축공학커리큘럼");
                examresult[0].text = "2.77";
                examresult[1].text = "14";
                examresult[2].text = "3.39";
                examresult[3].text = "8";
                examresult[4].text = "3.61";
                examresult[5].text = "10";
                examresult[6].text = "5.26";
                examresult[7].text = "3";
                examresult[8].text = "4.41";
                examresult[9].text = "0";
                examresult[10].text = "75.55";
                examresult[11].text = "34";
                break;

            //생명공학부
            case "생명과학":
                link.text = "http://life.inu.ac.kr/";
                info.text = "생명과학전공은 생명 현상의 다양한 수준, 즉 분자, 세포, 조직, 기관, 개체, 개체군 등으로 발전하는 체계적 현상의 작동 메커니즘과 기능에 대한 이론과 원리를 터득하고 능동적인 응용과 창의적인 연구능력을 지닌 선도적 연구 및 기술 인력을 양성한다. 특히 생물자원의 경제적 가치와 중요성이 국가 경쟁력이 되는 시대이다. 이에 미생물, 균류, 식물, 동물 등 개체 중심의 교육활동 프로그램에 대한 투자와 연구를 최근 증가시키고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/생명과학전공커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/생명과학전공커리큘럼2");
                examresult[0].text = "2.44";
                examresult[1].text = "8";
                examresult[2].text = "2.58";
                examresult[3].text = "8";
                examresult[4].text = "3.17";
                examresult[5].text = "9";
                examresult[6].text = "3.97";
                examresult[7].text = "3";
                examresult[8].text = "3.14";
                examresult[9].text = "0";
                examresult[10].text = "77.44";
                examresult[11].text = "17";
                break;
            case "분자의생명":
                link.text = "http://life.inu.ac.kr/";
                info.text = "분자의생명전공은 과학적 사고력과 독창적인 탐구력을 길러주고 기초의과학의 학문발전에 기여할 과학자를 발굴 양성 한다. 나아가 합리적인 사고력을 갖고 과학적 생활을 영위하며 의학 분야에서 지도적 역할을 수행할 수 있는 훌륭한 소양을 지닌 인력을 양성한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/분자의생명커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/분자의생명커리큘럼2");
                examresult[0].text = "2.44";
                examresult[1].text = "8";
                examresult[2].text = "2.58";
                examresult[3].text = "8";
                examresult[4].text = "3.17";
                examresult[5].text = "9";
                examresult[6].text = "3.97";
                examresult[7].text = "3";
                examresult[8].text = "3.14";
                examresult[9].text = "0";
                examresult[10].text = "77.44";
                examresult[11].text = "17";
                break;
            case "생명공학":
                link.text = "http://bioeng.inu.ac.kr/";
                info.text = "생명공학은 생명과학적 기초지식을 기반으로 생명소재를 공학적으로 응용하는 학문분야로 생물, 물리, 화학 및 공학적 개념을 기반으로 한다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/생명공학전공커리큘럼");
                examresult[0].text = "2.13";
                examresult[1].text = "14";
                examresult[2].text = "2.31";
                examresult[3].text = "12";
                examresult[4].text = "3.17";
                examresult[5].text = "8";
                examresult[6].text = "3.31";
                examresult[7].text = "0";
                examresult[8].text = "2.80";
                examresult[9].text = "0";
                examresult[10].text = "78.00";
                examresult[11].text = "21";
                break;
            case "나노바이오":
                link.text = "http://bioeng.inu.ac.kr/";
                info.text = "생명공학은 생명과학적 기초지식을 기반으로 생명소재를 공학적으로 응용하는 학문분야로 생물, 물리, 화학 및 공학적 개념을 기반으로 한다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/나노바이오전공커리큘럼");
                examresult[0].text = "2.13";
                examresult[1].text = "14";
                examresult[2].text = "2.31";
                examresult[3].text = "12";
                examresult[4].text = "3.17";
                examresult[5].text = "8";
                examresult[6].text = "3.31";
                examresult[7].text = "0";
                examresult[8].text = "2.80";
                examresult[9].text = "0";
                examresult[10].text = "78.00";
                examresult[11].text = "21";
                break;

            //사범대학
            case "국어교육과":
                link.text = "http://edukorean.inu.ac.kr/";
                info.text = "본 학과는 국민정신의 기본이 되는 국어를 효율적으로 교육할 수 있는 교육자로서의 인성을 갖추고 국어교육에 필요한 이론과 실용적 지식을 지닌 유능한 국어교사와 국어교육 전문가 양성을 목표로 우리말과 글에 대한 올바른 이해를 통해 국어교사에게 필요한 전문 지식을 체계적으로 습득하고, 지식 정보화 사회에 부응하는 국어 교수 능력 배양에 힘을 기울이고 있으며 이러한 인재를 양성하기 위해 국어교육, 국어학, 고전문학, 현대문학 분야에 걸쳐 다양하고 깊이 있는 교육과정을 운영하고 있다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/국어교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/국어교육과커리큘럼2");
                examresult[2].text = "1.47";
                examresult[3].text = "6";
                examresult[4].text = "1.77";
                examresult[5].text = "1";
                examresult[10].text = "87.53";
                examresult[11].text = "12";
                break;
            case "영어교육과":
                link.text = "http://eduenglish.inu.ac.kr/";
                info.text = "인천대학교 영어교육과는 학생 개개인의 잠재적 능력을 최대한 발휘하여 참신하고 능력 있는 영어교사를 양성할 수 있는 최적의 교육환경과 교육과정, 교수진을 갖추고 2011년 첫 출범하였습니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/영어교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/영어교육과커리큘럼2");
                examresult[2].text = "1.47";
                examresult[3].text = "1";
                examresult[4].text = "1.92";
                examresult[5].text = "2";
                examresult[10].text = "87.08";
                examresult[11].text = "17";
                break;
            case "일어교육과":
                link.text = "http://edujapanese.inu.ac.kr/";
                info.text = "인천대학교 사범대학 일어교육과는 교직관이 투철하고 우수한 중등교사 양성을 목표로 하고 있습니다.\n\n 또한 세계화, 정보화, 다문화 시대를 맞이하여 우수한 일본어 능력과 더불어 인성, 덕성 등을 고루 갖춘 일본어 교육 및 일본지역 전문가를 양성하여 사회의 발전에 기여하고자 합니다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/일어교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/일어교육과커리큘럼2");
                examresult[2].text = "2.11";
                examresult[3].text = "1";
                examresult[4].text = "3.18";
                examresult[5].text = "0";
                examresult[10].text = "82.38";
                examresult[11].text = "11";
                break;
            case "수학교육과":
                link.text = "http://edumath.inu.ac.kr/";
                info.text = "수학은 논리적인 사고와 추리력 및 추상적인 개념을 이해할 수 있는 능력을 요구하는 학문이다. 수학교육과는 이러한 적성을 가진 학생으로서 수학교사의 사명감과 자질을 갖추고 투철한 책임의식으로 맡은바 학업에 충실한 학생들에게 적합한 학과이다.  ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/수학교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/수학교육과커리큘럼2");
                examresult[2].text = "1.77";
                examresult[3].text = "4";
                examresult[4].text = "1.95";
                examresult[5].text = "6";
                examresult[10].text = "89.93";
                examresult[11].text = "6";
                break;
            case "체육교육과":
                link.text = "http://eduphysical.inu.ac.kr/";
                info.text = "인천대학교 체육교육과는 교육현장에서 중추적 역할을 수행할 수 있는 전문 인재 양성을 목적으로 한다. \n\n체육교육과에서는 다양한 실기뿐만 아니라 체육교사가 알아야 할 체육이론 및 교육과 건강관련 지식을 중심으로 교육과정을 편성, 운영함으로써 시대적 요구에 부응하는 지도자를 양성한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/체육교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/체육교육과커리큘럼2");
                examresult[0].text = "2.32";
                examresult[1].text = "1";
                examresult[10].text = "84.40";
                examresult[11].text = "3";
                break;
            case "유아교육과":
                link.text = "http://ece.inu.ac.kr/";
                info.text = "인천대학교 유아교육과는 서울ㆍ경인권에 소재한 국공립대학 중 유일하게 설치되어 있는 학과로써 유아교육의 이론 탐구와 교육 및 보육현장에서의 실습을 통하여 이론과 실제를 겸비한 유능한 유아교육 전문가를 양성하는데 목적이 있다. \n\n따라서 이 목적을 이루고자 유아교육의 학문적 이론들과 교육실제를 통합하여 교육과정이 구성되어 있다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/유아교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/유아교육과커리큘럼2");
                examresult[2].text = "2.18";
                examresult[3].text = "7";
                examresult[4].text = "2.34";
                examresult[5].text = "3";
                examresult[10].text = "85.16";
                examresult[11].text = "6";
                break;
            case "역사교육과":
                link.text = "http://eduhistory.inu.ac.kr/";
                info.text = "역사교육과는 인천시에 소재한 국․공립대학 중 유일하게 설치되어 있는 학과로서 2010년 인천대학교가 통합 인천대학교로 새롭게 출범하면서 교육과학기술부에서 학과 설치인가를 받아 2011년 첫 입학생을 받았다. ";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/역사교육과커리큘럼");
                examresult[2].text = "1.52";
                examresult[3].text = "7";
                examresult[4].text = "1.89";
                examresult[5].text = "0";
                examresult[10].text = "88.66";
                examresult[11].text = "2";
                break;
            case "윤리교육과":
                link.text = "http://eduethics.inu.ac.kr/";
                info.text = "윤리교육과는 동서양의 철학과 윤리학, 응용윤리 및 도덕윤리교육의 이론과 실제에 대해 배운다.\n\n사회ㆍ윤리관의 혼란 및 남북사회의 분단이라는 현실에 직면해 있는 한국사회, 그리고 전세계적으로 환경파괴의 심각한 위기에 직면해 있는 상황에서,\n\n이러한 위기 상황을 극복할 수 있는 새로운 가치관 형성의 기초가 되는 도덕성의 함양과 실천적 태도의 확립을 위한 도덕 이론 체계의 정립과 윤리적 실천 능력을 배양함으로써 우리 사회를 이끌어 갈 윤리적 지도자를 양성함과 더불어 학교 현장에서 청소년을 지도할 수 있는 유능한 교사의 양성을 목표로 한다.";
                curri.sprite = Resources.Load<Sprite>("Dept_curriculum/윤리교육과커리큘럼1");
                curri2.sprite = Resources.Load<Sprite>("Dept_curriculum/윤리교육과커리큘럼2");
                examresult[3].text = "1";
                examresult[4].text = "2.22";
                examresult[5].text = "0";
                examresult[10].text = "86.13";
                examresult[11].text = "1";
                break;

        }
    }

    public void LinkBtn()
    {
        Application.OpenURL(link.text);
    }

    public void ExitBtn()
    {
        Close();
    }
    public void Exit2Btn()
    {
        Close();
    }
    public void Exit3Btn()
    {
        Close();
    }
    public void Exit4Btn()
    {
        Close();
    }
}
