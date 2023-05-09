namespace UniFi.Core.Models;

[Flags]
public enum RepositoryMethodAccess
{
    All,
    Get,
    GetAll,
    Add,
    Update,
    Delete
}