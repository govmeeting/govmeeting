namespace GM.Application.AppCore.Entities
{
    public enum GovbodyPermissions : int
    {
        Create = 1,
        Edit = 2,
        Delete = 3,
        View = 4
    };

    class GovbodyPermission : AuditEntity
    {
        int GovbodyId { get; set; }
        string UserId { get; set; }
        GovbodyPermission Permission { get; set; }
    }
}
