namespace CampusTour.UI
{
    /// <summary>씬이 아닌 오버레이(메뉴 패널, 이미지 확대 등)를 화면 스택에 올리기 위한 인터페이스.</summary>
    public interface IClosable
    {
        void Close();
    }
}
