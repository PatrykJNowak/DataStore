namespace UserAuthenticationServices.UseCases.UserAuth.GetAllUser.Dto;

public class UsersList
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
}