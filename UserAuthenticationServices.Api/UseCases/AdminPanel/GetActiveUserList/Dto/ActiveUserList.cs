namespace UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList.Dto;

public class ActiveUserList
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserSurName { get; set; }
    public Guid UserSessionId{ get; set; }
    public DateTime SessionFinishAt { get; set; }
    public string UserLevel { get; set; }
}