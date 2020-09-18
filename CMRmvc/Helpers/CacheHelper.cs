using CMRmvc.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Threading.Tasks;
using static CRMmvc.Common.Enums;

namespace CRMmvc.Helpers
{
    public class CacheHelper
    {
        private readonly MemoryCache _cache;
        private readonly CRMContext _contexto;

        private ConcurrentDictionary<string, Parametros> listaParametros;
        private ConcurrentDictionary<string, List<MenuItemPadre>> _menu;

        private CacheItemPolicy cacheItemPolicy;
        private readonly ILogger<CacheHelper> _logger;
        public CacheHelper(ILogger<CacheHelper> logger, IOptions<ConnectionsStrings> connectionString)
        {
            _logger = logger;
            _cache = MemoryCache.Default;
            _contexto = new CRMContext(connectionString);
            _menu = new ConcurrentDictionary<string, List<MenuItemPadre>>();
            GetParameters();
        }

        /// <summary>
        /// Recupera los elementos necesarios de base de datos para ser guardados en caché y establece el tiempo de vida de la cache (parametro)
        /// </summary>
        private void GetParameters()
        {
            _logger.LogInformation("********** " + MethodBase.GetCurrentMethod().Name + " START **********");
            try
            {
                _logger.LogInformation("Cargando objetos en caché");
                LoadCache();
                _logger.LogInformation("Objetos en caché cargados");
                _logger.LogInformation("Recuperando parametro: "+ EnumParameters.CRM_MVC_CACHE_TIMEOUT);
                var param = _contexto.Parametros.FirstOrDefault(x => x.ParClave == EnumParameters.CRM_MVC_CACHE_TIMEOUT.ToString());
                if (param != null)
                {
                    var SlidingExpiration = Convert.ToInt32(param.ParValor);

                    _logger.LogInformation("SlidingExpiration: " + SlidingExpiration);
                    //policy necesaria para setear elementos en caché
                    cacheItemPolicy = new CacheItemPolicy
                    {
                        SlidingExpiration = new TimeSpan(0, SlidingExpiration, 0),
                        RemovedCallback = new CacheEntryRemovedCallback(RenewCache) //función que se ejecuta cuando se vence el tiempo de vida de un elemento en caché
                    };
                }
                else _logger.LogWarning("NO SE PUDO RECUEPERAR EL PARAMETRO!!!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
            }
            finally
            {
                _logger.LogInformation("********** " + MethodBase.GetCurrentMethod().Name + " END **********");
            }
        }

        /// <summary>
        /// Si los elementos en caché existen, los elimina y los vuelve a crear trayendolos de la base de datos
        /// </summary>
        /// <param name="cache"></param>        
        /// <summary>
        /// Obtiene un parametro en caché
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>        
        private void LoadCache()
        {
            var parameters = _contexto.Parametros.ToList();

            listaParametros = new ConcurrentDictionary<string, Parametros>();

            foreach (Parametros parametro in parameters)
            {
                listaParametros.TryAdd(parametro.ParClave, parametro);
            }
            _cache.Set(EnumCacheItems.PARAMETROS, listaParametros, cacheItemPolicy);
        }

        /// <summary>
        /// Carga en cache el menu a mostrar
        /// </summary>
        public void LoadMenu(List<MenuItemPadre> menus)
        {
            _menu.TryAdd(EnumCacheItems.MENUS, menus);            
            _cache.Set(EnumCacheItems.MENUS, _menu, cacheItemPolicy);
        }

        /// <summary>
        /// Obtiene el menu del usuario
        /// </summary>
        /// <param name="menus"></param>
        public List<MenuItemPadre> GetMenu()
        {
            var menu = (ConcurrentDictionary<string, List<MenuItemPadre>>)_cache.GetCacheItem(EnumCacheItems.MENUS).Value;
            var  padres =menu.Values.FirstOrDefault();
            return padres;
        }


        /// <summary>
        /// renueva todos los items en caché cuando expira cualquiera de ellos
        /// </summary>
        /// <param name="cache"></param>
        private void RenewCache(CacheEntryRemovedArguments cache)
        {
            _logger.LogInformation("Renovando " + cache.CacheItem.Key + " en caché");
            if (cache.RemovedReason == CacheEntryRemovedReason.Expired) LoadCache();
        }

        /// <summary>
        /// Obtiene un parámetro de la cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Parametros GetParameter(string key)
        {
            _logger.LogInformation("********** " + MethodBase.GetCurrentMethod().Name + " START **********");
            object parametersList = null;
            ConcurrentDictionary<string, Parametros> parameter = null;
            Parametros returnedParameter = null;
            try
            {
                parametersList = _cache.GetCacheItem(EnumCacheItems.PARAMETROS).Value;
                parameter = (ConcurrentDictionary<string, Parametros>)parametersList;
                returnedParameter = parameter.Values.Where(x => x.ParClave == key).FirstOrDefault();
                _logger.LogInformation("returnedParameter: " + JsonConvert.SerializeObject(returnedParameter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
            }
            finally
            {
                _logger.LogInformation("********** " + MethodBase.GetCurrentMethod().Name + " END **********");
            }
            return returnedParameter;
        }        
    }
}
