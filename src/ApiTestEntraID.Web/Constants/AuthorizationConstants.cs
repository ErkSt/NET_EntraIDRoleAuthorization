namespace ApiTestEntraID.Web.Constants;

public static class AppRoles
{
    public const string Admin = "admin";
    public const string DocUser = "doc_user";
    public const string DocManager = "doc_manager";
    public const string HrUser = "hr_user";
    public const string HrManager = "hr_manager";
    public const string SupportUser = "support_user";
    public const string SupportManager = "support_manager";
}

public static class AppPolicies
{
    public const string DocsGeneral = "Docs.General";
    public const string DocsTasks = "Docs.Tasks";
    public const string DocsReport = "Docs.Report";
    
    public const string HRGeneral = "HR.General";
    public const string HRTasks = "HR.Tasks";
    public const string HRReport = "HR.Report";
    
    public const string ITGeneral = "IT.General";
    public const string ITTasks = "IT.Tasks";
    public const string ITReport = "IT.Report";
}