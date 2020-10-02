
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
                       

        }
        public enum ParameterType
        {
            DATE = 1,
            INT = 2,
            STRING = 3
        }
        public enum Genero
        {
            MASCULINO = 1,
            FEMENINO = 2,
        }
    }
}
