namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

public class UpdateUserResponse : ApiResponse<UpdateUserData>;

public class UpdateUserData
{
    public long Id { get; set; }
}
