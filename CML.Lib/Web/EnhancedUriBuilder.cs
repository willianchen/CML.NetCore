using System;
using System.Collections.Specialized;
using System.Web;

namespace CML.Lib.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：EnhancedUriBuilder.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Url拼接
    /// 创建标识：yjq 2017/8/17 17:29:25
    /// </summary>
    public class EnhancedUriBuilder : System.UriBuilder
    {
        #region QueryItemCollection

        private class QueryItemCollection : NameValueCollection
        {
            private bool _isDirty = false;

            internal bool IsDirty
            {
                get { return _isDirty; }
                set { _isDirty = value; }
            }

            public override void Add(string name, string value)
            {
                _isDirty = true;
                base.Add(name, value);
            }

            public override void Remove(string name)
            {
                _isDirty = true;
                base.Remove(name);
            }

            public override void Set(string name, string value)
            {
                _isDirty = true;
                base.Set(name, value);
            }
        }

        #endregion QueryItemCollection

        private QueryItemCollection queryItems;
        private bool _queryIsDirty = false;

        public EnhancedUriBuilder()
        {
        }

        public EnhancedUriBuilder(string uri) : base(uri)
        {
            _queryIsDirty = true;
        }

        public EnhancedUriBuilder(Uri uri) : base(uri)
        {
            _queryIsDirty = true;
        }

        public EnhancedUriBuilder(string schemeName, string hostName) : base(schemeName, hostName)
        {
        }

        public EnhancedUriBuilder(string scheme, string host, int portNumber) : base(scheme, host, portNumber)
        {
        }

        public EnhancedUriBuilder(string scheme, string host, int port, string pathValue) : base(scheme, host, port, pathValue)
        {
        }

        public EnhancedUriBuilder(string scheme, string host, int port, string path, string extraValue) : base(scheme, host, port, path, extraValue)
        {
        }

        public NameValueCollection QueryItems
        {
            get
            {
                if (queryItems == null)
                    queryItems = new QueryItemCollection();

                SyncQueryItems();

                return queryItems;
            }
        }

        public new string Query
        {
            get
            {
                SyncQuery();
                return base.Query;
            }
            set
            {
                if (value != null && value.Length > 0 && value[0] == '?')
                    value = value.Substring(1);

                base.Query = value;
                _queryIsDirty = true;
            }
        }

        public override string ToString()
        {
            SyncQuery();
            return base.ToString();
        }

        public new Uri Uri
        {
            get
            {
                SyncQuery();
                return base.Uri;
            }
        }

        private void SyncQueryItems()
        {
            if (_queryIsDirty)
            {
                CreateItemsFromQuery();
                _queryIsDirty = false;
            }
        }

        private void CreateItemsFromQuery()
        {
            queryItems.Clear();

            if (base.Query.Length > 0)
            {
                string query = HttpUtility.UrlDecode(base.Query.Substring(1));

                string[] items = query.Split('&');
                foreach (string item in items)
                {
                    if (item.Length > 0)
                    {
                        string[] namevalue = item.Split('=');

                        if (namevalue.Length > 1)
                            queryItems.Add(namevalue[0], namevalue[1]);
                        else
                            queryItems.Add(namevalue[0], "");
                    }
                }
            }
        }

        private void SyncQuery()
        {
            if (queryItems != null)
            {
                if (queryItems.Count == 0)
                {
                    base.Query = "";
                }
                else if (queryItems.IsDirty)
                {
                    CreateQueryFromItems();
                }

                queryItems.IsDirty = false;
            }
        }

        private void CreateQueryFromItems()
        {
            string query = "";
            foreach (string key in queryItems.AllKeys)
            {
                string[] values = queryItems.GetValues(key);
                foreach (string value in values)
                {
                    query += (key + "=" + value + "&");
                }
            }

            if (query.Length > 0)
                query = query.Substring(0, query.Length - 1);

            base.Query = query;
        }
    }
}