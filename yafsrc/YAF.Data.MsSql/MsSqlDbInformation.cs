/* Yet Another Forum.NET
 * Copyright (C) 2003-2005 Bjørnar Henden
 * Copyright (C) 2006-2013 Jaben Cargman
 * Copyright (C) 2014 Ingo Herbote
 * http://www.yetanotherforum.net/
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at

 * http://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

namespace YAF.Data.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    using YAF.Classes;
    using YAF.Core.Data;
    using YAF.Types;
    using YAF.Types.Interfaces.Data;

    /// <summary>
    /// MS SQL DB Information
    /// </summary>
    public class MsSqlDbInformation : IDbInformation
    {
        /// <summary>
        /// The DB parameters
        /// </summary>
        protected DbConnectionParam[] _dbParameters =
            {
                new DbConnectionParam(0, "Password", string.Empty),
                new DbConnectionParam(1, "Data Source", "(local)"),
                new DbConnectionParam(2, "Initial Catalog", string.Empty),
                new DbConnectionParam(11, "Use Integrated Security", "true")
            };

        /// <summary>
        /// The azure script list
        /// </summary>
        private static readonly string[] _AzureScriptList =
            {
                "mssql/azure/InstallCommon.sql",
                "mssql/azure/InstallMembership.sql",
                "mssql/azure/InstallProfile.sql",
                "mssql/azure/InstallRoles.sql"
            };

        /// <summary>
        /// The script list
        /// </summary>
        private static readonly string[] _ScriptList =
            {
                "mssql/tables.sql", 
                "mssql/indexes.sql", 
                "mssql/views.sql",
                "mssql/constraints.sql", 
                "mssql/triggers.sql",
                "mssql/functions.sql", 
                "mssql/procedures.sql",
                "mssql/forum_ns.sql"
            };

        /// <summary>
        /// The YAF Provider script list
        /// </summary>
        private static readonly string[] _YAFProviderScriptList =
            {
                "mssql/providers/tables.sql",
                "mssql/providers/indexes.sql", 
                "mssql/providers/procedures.sql"
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlDbInformation"/> class.
        /// </summary>
        public MsSqlDbInformation()
        {
            this.ConnectionString = () => Config.ConnectionString;
            this.ProviderName = MsSqlDbAccess.ProviderTypeName;
        }

        /// <summary>
        /// Gets or sets the DB Connection String
        /// </summary>
        public Func<string> ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the DB Provider Name
        /// </summary>
        public string ProviderName { get; protected set; }

        /// <summary>
        /// Gets Full Text Script.
        /// </summary>
        public string FullTextScript
        {
            get
            {
                return "mssql/fulltext.sql";
            }
        }

        /// <summary>
        /// Gets the Azure Script List.
        /// </summary>
        public IEnumerable<string> AzureScripts
        {
            get
            {
                return _AzureScriptList;
            }
        }

        /// <summary>
        /// Gets the Script List.
        /// </summary>
        public IEnumerable<string> Scripts
        {
            get
            {
                return _ScriptList;
            }
        }

        /// <summary>
        /// Gets the YAF Provider Script List.
        /// </summary>
        public IEnumerable<string> YAFProviderScripts
        {
            get
            {
                return _YAFProviderScriptList;
            }
        }

        /// <summary>
        /// Gets the DB Connection Parameters.
        /// </summary>
        public IDbConnectionParam[] DbConnectionParameters
        {
            get
            {
                return this._dbParameters.OfType<IDbConnectionParam>().ToArray();
            }
        }

        /// <summary>
        /// Builds a connection string.
        /// </summary>
        /// <param name="parameters">The Connection Parameters</param>
        /// <returns>Returns the Connection String</returns>
        public string BuildConnectionString([NotNull] IEnumerable<IDbConnectionParam> parameters)
        {
            CodeContracts.VerifyNotNull(parameters, "parameters");

            var connBuilder = new SqlConnectionStringBuilder();

            foreach (var param in parameters)
            {
                connBuilder[param.Name] = param.Value;
            }

            return connBuilder.ConnectionString;
        }
    }
}