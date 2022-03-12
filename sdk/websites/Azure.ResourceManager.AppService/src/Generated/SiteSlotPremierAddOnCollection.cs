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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of SiteSlotPremierAddOn and their operations over its parent. </summary>
    public partial class SiteSlotPremierAddOnCollection : ArmCollection
    {
        private readonly ClientDiagnostics _siteSlotPremierAddOnWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotPremierAddOnWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotPremierAddOnCollection"/> class for mocking. </summary>
        protected SiteSlotPremierAddOnCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotPremierAddOnCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteSlotPremierAddOnCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotPremierAddOnWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotPremierAddOn.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SiteSlotPremierAddOn.ResourceType, out string siteSlotPremierAddOnWebAppsApiVersion);
            _siteSlotPremierAddOnWebAppsRestClient = new WebAppsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotPremierAddOnWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteSlot.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteSlot.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Updates a named add-on of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_AddPremierAddOnSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="premierAddOn"> A JSON representation of the edited premier add-on. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> or <paramref name="premierAddOn"/> is null. </exception>
        public virtual async Task<ArmOperation<SiteSlotPremierAddOn>> CreateOrUpdateAsync(WaitUntil waitUntil, string premierAddOnName, PremierAddOnData premierAddOn, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));
            Argument.AssertNotNull(premierAddOn, nameof(premierAddOn));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteSlotPremierAddOnWebAppsRestClient.AddPremierAddOnSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, premierAddOnName, premierAddOn, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<SiteSlotPremierAddOn>(Response.FromValue(new SiteSlotPremierAddOn(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates a named add-on of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_AddPremierAddOnSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="premierAddOn"> A JSON representation of the edited premier add-on. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> or <paramref name="premierAddOn"/> is null. </exception>
        public virtual ArmOperation<SiteSlotPremierAddOn> CreateOrUpdate(WaitUntil waitUntil, string premierAddOnName, PremierAddOnData premierAddOn, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));
            Argument.AssertNotNull(premierAddOn, nameof(premierAddOn));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteSlotPremierAddOnWebAppsRestClient.AddPremierAddOnSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, premierAddOnName, premierAddOn, cancellationToken);
                var operation = new AppServiceArmOperation<SiteSlotPremierAddOn>(Response.FromValue(new SiteSlotPremierAddOn(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets a named add-on of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_GetPremierAddOnSlot
        /// </summary>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> is null. </exception>
        public virtual async Task<Response<SiteSlotPremierAddOn>> GetAsync(string premierAddOnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotPremierAddOnWebAppsRestClient.GetPremierAddOnSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, premierAddOnName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotPremierAddOn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets a named add-on of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_GetPremierAddOnSlot
        /// </summary>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> is null. </exception>
        public virtual Response<SiteSlotPremierAddOn> Get(string premierAddOnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotPremierAddOnWebAppsRestClient.GetPremierAddOnSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, premierAddOnName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotPremierAddOn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_GetPremierAddOnSlot
        /// </summary>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string premierAddOnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(premierAddOnName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_GetPremierAddOnSlot
        /// </summary>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> is null. </exception>
        public virtual Response<bool> Exists(string premierAddOnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(premierAddOnName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_GetPremierAddOnSlot
        /// </summary>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> is null. </exception>
        public virtual async Task<Response<SiteSlotPremierAddOn>> GetIfExistsAsync(string premierAddOnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotPremierAddOnWebAppsRestClient.GetPremierAddOnSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, premierAddOnName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotPremierAddOn>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotPremierAddOn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
        /// Operation Id: WebApps_GetPremierAddOnSlot
        /// </summary>
        /// <param name="premierAddOnName"> Add-on name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="premierAddOnName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="premierAddOnName"/> is null. </exception>
        public virtual Response<SiteSlotPremierAddOn> GetIfExists(string premierAddOnName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(premierAddOnName, nameof(premierAddOnName));

            using var scope = _siteSlotPremierAddOnWebAppsClientDiagnostics.CreateScope("SiteSlotPremierAddOnCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotPremierAddOnWebAppsRestClient.GetPremierAddOnSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, premierAddOnName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotPremierAddOn>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotPremierAddOn(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
