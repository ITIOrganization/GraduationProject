using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlumniSystem.Models
{
    [NotMapped]
    public static class _RemoteCheck
    {
        /// <summary>
        /// CheckNameRemoteDynamic
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="currentName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<bool> CheckNameRemoteDynamic(string newName, string currentName, dynamic obj)
        {
            if (currentName != null)
            {
                if (newName.ToLower() == currentName.ToLower())
                {
                    return true;
                }
            }
            if (await obj.IsExi
                stByName(newName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CheckNameRemote - Normal Function
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="currentName"></param>
        /// <param name="isExistFunction"></param>
        /// <returns></returns>
        public static bool CheckNameRemote(string newName, string currentName, Predicate<string> isExistFunction)
        {
            if (currentName != null)
            {
                if (newName.ToLower() == currentName.ToLower())
                {
                    return true;
                }
            }
            if (isExistFunction(newName))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// CheckNameRemoteAsync
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="currentName"></param>
        /// <param name="isExistFunctionAsync"></param>
        /// <returns></returns>
        public static async Task<bool> CheckNameRemoteAsync(string newName, string currentName, Func<string, Task<bool>> isExistFunctionAsync)
        {
            if (currentName != null)
            {
                if (newName.ToLower() == currentName.ToLower())
                {
                    return true;
                }
            }
            if (await isExistFunctionAsync(newName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CheckNameRemote - Normal Function
        /// </summary>
        /// <param name="newPhone"></param>
        /// <param name="currentPhone"></param>
        /// <param name="isExistFunction"></param>
        /// <returns></returns>
        public static bool CheckPhoneRemote(string newPhone, string currentPhone, Predicate<string> isExistFunction)
        {
            if (isExistFunction(newPhone))
            {
                return false;
            }
            return true;

            
        }

    }
}