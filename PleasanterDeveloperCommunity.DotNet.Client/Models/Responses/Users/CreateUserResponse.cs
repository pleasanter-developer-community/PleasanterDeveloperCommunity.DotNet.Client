namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

public class CreateUserResponse : ApiResponse<CreateUserData>;

public class CreateUserData
{
    public long Id { get; set; }
}
