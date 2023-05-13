namespace UniFi.Core.Models;

[Flags]
public enum RepositoryMethodAccess
{
    None = 0,
    Get = 1,
    GetAll = 2,
    Add = 4,
    Update = 8,
    Delete = 16,
    All = Get | GetAll | Add | Update | Delete
}