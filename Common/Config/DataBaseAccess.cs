using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO.Config
{
    public class DataBaseAccess
    {

        public DataBaseAccess()
        {
        }

        /// <summary>
        /// Obtiene Nombre del Stored Procedure a Ejecutar
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //public static string GetCommand(string sp, List<SqlParameter> parameters)
        //{
        //    return string.Format("{0} {1}", sp, parameters != null ? string.Join(",", parameters.Select(x => string.Format("@{0}", x.ParameterName)).ToArray()) : null);
        //}

        /// <summary>
        /// Crea un arreglo de SqlParameters apartir de un diccionario de datos
        /// </summary>
        /// <param name="parameters">Parámetro / Valor</param>
        /// <returns>object[]</returns>
        //public static object[] Parameters(Dictionary<string, object> parameters)
        //{
        //    object[] sql = parameters.Select(
        //        p => new SqlParameter
        //        {
        //            ParameterName = p.Key,
        //            Value = p.Value
        //        }
        //        ).ToArray<object>();

        //    return sql;
        //}

        /// <summary>
        /// Ejecuta un SP sin parametros y regresa una lista de objetos
        /// </summary>
        /// <param name="sp">Stored procedure</param>
        /// <param name="context">Base de datos</param>
        /// <returns>Lista del tipo especidicado</returns>
        //public static List<T> Retrieve<T>(string sp, DbContext context)
        //{
        //    return context.Database.SqlQuery<T>(sp).ToList<T>();
        //}

        /// <summary>
        /// Ejecuta un SP con parametros y regresa una lista de objetos
        /// </summary>
        /// <typeparam name="T">tipo que tomará la lista de retorno</typeparam>
        /// <param name="sp">Nombre del sp</param>
        /// <param name="parameters">arreglo de parámetros para el sP</param>
        /// <param name="context">Base de datos donde ejecutará el SP</param>
        /// <returns>lista de objetos del tipo que recibe</returns>
        //public static List<T> Retrieve<T>(string sp, object[] parameters, DbContext context)
        //{
        //    return context.Query<T>().FromSql(sp, parameters).ToList<T>();
        //}

        ///// <summary>
        ///// Ejecuta un SP sin parametros y regresa un valor entero
        ///// </summary>
        ///// <param name="spCall">Nombre del sp</param>
        ///// <param name="db">Base de datos donde ejecutará el SP</param>
        ///// <returns>entero</returns>
        //public static List<T> Execute(string sp, DbContext context)
        //{
        //    return context.Query<T>();
        //}
    }
}
