using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using TP.Core;
using TP.Core.Runtime.Session;

namespace TP.Web.Core.Runtime.Session
{
    public class HttpContextBasedDomainSession : IDomainSession
    {
        private readonly IHttpContextAccessor _accessor;

        public HttpContextBasedDomainSession(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int? UserId
        {
            get
            {
                if (Int32.TryParse(GetSessionValue(Consts.CurrentDomainSessionUserIdKey), out int userId))
                {
                    return userId;
                }

                return null;
            }
            internal set
            {
                if (value.HasValue)
                {

                    try
                    {
                        SetSessionValue(Consts.CurrentDomainSessionUserIdKey, JsonConvert.SerializeObject(value));
                    }
                    catch
                    {
                        RemoveSessionValue(Consts.CurrentDomainSessionUserIdKey);
                    }
                }
                else
                {
                    RemoveSessionValue(Consts.CurrentDomainSessionUserIdKey);
                }
            }
        }

        public string Username
        {
            get
            {
                return GetSessionValue(Consts.CurrentDomainSessionUsernameKey);
            }
            internal set
            {
                if (value != null)
                {
                    SetSessionValue(Consts.CurrentDomainSessionUsernameKey, value);
                }
                else
                {
                    RemoveSessionValue(Consts.CurrentDomainSessionUsernameKey);
                }
            }
        }

        public string[] Permissions
        {
            get
            {
                string[] permissions = null;
                try
                {
                    string permissionsString = GetSessionValue(Consts.CurrentDomainSessionPermissionsKey);

                    if (!String.IsNullOrEmpty(permissionsString))
                    {
                        permissions = JsonConvert.DeserializeObject<string[]>(permissionsString);
                    }
                }
                catch
                {
                    permissions = null;
                }

                return permissions;
            }

            internal set
            {
                if (value != null)
                {
                    try
                    {
                        string permissionsString = JsonConvert.SerializeObject(value);
                        SetSessionValue(Consts.CurrentDomainSessionPermissionsKey, permissionsString);
                    }
                    catch
                    {
                        RemoveSessionValue(Consts.CurrentDomainSessionPermissionsKey);
                    }
                }
                else
                {
                    RemoveSessionValue(Consts.CurrentDomainSessionPermissionsKey);
                }
            }
        }

        public string UserEmail
        {
            get
            {
                return GetSessionValue(Consts.CurrentDomainSessionUserEmailKey);
            }

            internal set
            {
                if (value != null)
                {
                    SetSessionValue(Consts.CurrentDomainSessionUserEmailKey, value);
                }
                else
                {
                    RemoveSessionValue(Consts.CurrentDomainSessionUserEmailKey);
                }
            }
        }

        public string UserFullName
        {
            get
            {
                return GetSessionValue(Consts.CurrentDomainSessionUserFullNameKey);
            }
            internal set
            {
                if (value != null)
                {
                    SetSessionValue(Consts.CurrentDomainSessionUserFullNameKey, value);
                }
                else
                {
                    RemoveSessionValue(Consts.CurrentDomainSessionUserFullNameKey);
                }
            }
        }

        private string GetSessionValue(string key)
        {
            string value = null;
            try
            {
                value = _accessor?.HttpContext?.Session?.GetString(key);
            }
            catch
            {
                value = null;
            }
            return value;
        }

        private void SetSessionValue(string key, string value)
        {
            try
            {
                _accessor?.HttpContext?.Session?.SetString(key, value);
            }
            catch
            { }
        }

        private void RemoveSessionValue(string key)
        {
            try
            {
                _accessor?.HttpContext?.Session?.Remove(key);
            }
            catch
            { }
        }
    }
}
