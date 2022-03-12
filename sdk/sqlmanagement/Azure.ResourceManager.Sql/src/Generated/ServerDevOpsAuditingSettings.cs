// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a ServerDevOpsAuditingSettings along with the instance operations that can be performed on it. </summary>
    public partial class ServerDevOpsAuditingSettings : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ServerDevOpsAuditingSettings"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string devOpsAuditingSettingsName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/devOpsAuditingSettings/{devOpsAuditingSettingsName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsClientDiagnostics;
        private readonly ServerDevOpsAuditSettingsRestOperations _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsRestClient;
        private readonly ServerDevOpsAuditingSettingsData _data;

        /// <summary> Initializes a new instance of the <see cref="ServerDevOpsAuditingSettings"/> class for mocking. </summary>
        protected ServerDevOpsAuditingSettings()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ServerDevOpsAuditingSettings"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ServerDevOpsAuditingSettings(ArmClient client, ServerDevOpsAuditingSettingsData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ServerDevOpsAuditingSettings"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ServerDevOpsAuditingSettings(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string serverDevOpsAuditingSettingsServerDevOpsAuditSettingsApiVersion);
            _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsRestClient = new ServerDevOpsAuditSettingsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serverDevOpsAuditingSettingsServerDevOpsAuditSettingsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/devOpsAuditingSettings";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ServerDevOpsAuditingSettingsData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a server&apos;s DevOps audit settings.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/devOpsAuditingSettings/{devOpsAuditingSettingsName}
        /// Operation Id: ServerDevOpsAuditSettings_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ServerDevOpsAuditingSettings>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsClientDiagnostics.CreateScope("ServerDevOpsAuditingSettings.Get");
            scope.Start();
            try
            {
                var response = await _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDevOpsAuditingSettings(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a server&apos;s DevOps audit settings.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/devOpsAuditingSettings/{devOpsAuditingSettingsName}
        /// Operation Id: ServerDevOpsAuditSettings_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerDevOpsAuditingSettings> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsClientDiagnostics.CreateScope("ServerDevOpsAuditingSettings.Get");
            scope.Start();
            try
            {
                var response = _serverDevOpsAuditingSettingsServerDevOpsAuditSettingsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDevOpsAuditingSettings(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
