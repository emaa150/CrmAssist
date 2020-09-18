
namespace CRMmvc.Common
{
    public static class Enums
    {
        public static class EnumCacheItems
        {
            public const string PARAMETROS = "parametros";
            public const string MENUS = "menus";
        }

        public static class EnumParameters
        {
            public const string CRM_MVC_CACHE_TIMEOUT = "CRM_MVC_CACHE_TIMEOUT";
            public const string CRM_MVC_TOKEN_TIMEOUT = "CRM_MVC_TOKEN_TIMEOUT";
            

        }
        public enum ParameterType
        {
            DATE = 0,
            INT = 1,
            STRING = 2
        }
    }
}
