namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

public class DeleteUserResponse : ApiResponse<DeleteUserData>;

public class DeleteUserData
{
    public long Id { get; set; }
}
