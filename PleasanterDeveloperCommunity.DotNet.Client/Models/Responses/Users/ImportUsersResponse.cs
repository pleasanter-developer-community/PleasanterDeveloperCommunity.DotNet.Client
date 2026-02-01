namespace PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Users;

public class ImportUsersResponse : ApiResponse<ImportUsersData>;

public class ImportUsersData
{
    public int Imported { get; set; }
    public int Updated { get; set; }
}
