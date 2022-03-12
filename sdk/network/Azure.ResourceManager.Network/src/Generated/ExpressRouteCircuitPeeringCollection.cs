// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of ExpressRouteCircuitPeering and their operations over its parent. </summary>
    public partial class ExpressRouteCircuitPeeringCollection : ArmCollection, IEnumerable<ExpressRouteCircuitPeering>, IAsyncEnumerable<ExpressRouteCircuitPeering>
    {
        private readonly ClientDiagnostics _expressRouteCircuitPeeringClientDiagnostics;
        private readonly ExpressRouteCircuitPeeringsRestOperations _expressRouteCircuitPeeringRestClient;

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteCircuitPeeringCollection"/> class for mocking. </summary>
        protected ExpressRouteCircuitPeeringCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteCircuitPeeringCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ExpressRouteCircuitPeeringCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _expressRouteCircuitPeeringClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ExpressRouteCircuitPeering.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ExpressRouteCircuitPeering.ResourceType, out string expressRouteCircuitPeeringApiVersion);
            _expressRouteCircuitPeeringRestClient = new ExpressRouteCircuitPeeringsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, expressRouteCircuitPeeringApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ExpressRouteCircuit.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ExpressRouteCircuit.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a peering in the specified express route circuits.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="peeringParameters"> Parameters supplied to the create or update express route circuit peering operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> or <paramref name="peeringParameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ExpressRouteCircuitPeering>> CreateOrUpdateAsync(WaitUntil waitUntil, string peeringName, ExpressRouteCircuitPeeringData peeringParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));
            Argument.AssertNotNull(peeringParameters, nameof(peeringParameters));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _expressRouteCircuitPeeringRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, peeringParameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<ExpressRouteCircuitPeering>(new ExpressRouteCircuitPeeringOperationSource(Client), _expressRouteCircuitPeeringClientDiagnostics, Pipeline, _expressRouteCircuitPeeringRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, peeringParameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates a peering in the specified express route circuits.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="peeringParameters"> Parameters supplied to the create or update express route circuit peering operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> or <paramref name="peeringParameters"/> is null. </exception>
        public virtual ArmOperation<ExpressRouteCircuitPeering> CreateOrUpdate(WaitUntil waitUntil, string peeringName, ExpressRouteCircuitPeeringData peeringParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));
            Argument.AssertNotNull(peeringParameters, nameof(peeringParameters));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _expressRouteCircuitPeeringRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, peeringParameters, cancellationToken);
                var operation = new NetworkArmOperation<ExpressRouteCircuitPeering>(new ExpressRouteCircuitPeeringOperationSource(Client), _expressRouteCircuitPeeringClientDiagnostics, Pipeline, _expressRouteCircuitPeeringRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, peeringParameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets the specified peering for the express route circuit.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_Get
        /// </summary>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> is null. </exception>
        public virtual async Task<Response<ExpressRouteCircuitPeering>> GetAsync(string peeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.Get");
            scope.Start();
            try
            {
                var response = await _expressRouteCircuitPeeringRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExpressRouteCircuitPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified peering for the express route circuit.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_Get
        /// </summary>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> is null. </exception>
        public virtual Response<ExpressRouteCircuitPeering> Get(string peeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.Get");
            scope.Start();
            try
            {
                var response = _expressRouteCircuitPeeringRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExpressRouteCircuitPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all peerings in a specified express route circuit.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings
        /// Operation Id: ExpressRouteCircuitPeerings_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExpressRouteCircuitPeering" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ExpressRouteCircuitPeering> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ExpressRouteCircuitPeering>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _expressRouteCircuitPeeringRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ExpressRouteCircuitPeering>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _expressRouteCircuitPeeringRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all peerings in a specified express route circuit.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings
        /// Operation Id: ExpressRouteCircuitPeerings_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExpressRouteCircuitPeering" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ExpressRouteCircuitPeering> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ExpressRouteCircuitPeering> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _expressRouteCircuitPeeringRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ExpressRouteCircuitPeering> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _expressRouteCircuitPeeringRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitPeering(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_Get
        /// </summary>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string peeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(peeringName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_Get
        /// </summary>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> is null. </exception>
        public virtual Response<bool> Exists(string peeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(peeringName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_Get
        /// </summary>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> is null. </exception>
        public virtual async Task<Response<ExpressRouteCircuitPeering>> GetIfExistsAsync(string peeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _expressRouteCircuitPeeringRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ExpressRouteCircuitPeering>(null, response.GetRawResponse());
                return Response.FromValue(new ExpressRouteCircuitPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{circuitName}/peerings/{peeringName}
        /// Operation Id: ExpressRouteCircuitPeerings_Get
        /// </summary>
        /// <param name="peeringName"> The name of the peering. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="peeringName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringName"/> is null. </exception>
        public virtual Response<ExpressRouteCircuitPeering> GetIfExists(string peeringName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peeringName, nameof(peeringName));

            using var scope = _expressRouteCircuitPeeringClientDiagnostics.CreateScope("ExpressRouteCircuitPeeringCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _expressRouteCircuitPeeringRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, peeringName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ExpressRouteCircuitPeering>(null, response.GetRawResponse());
                return Response.FromValue(new ExpressRouteCircuitPeering(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ExpressRouteCircuitPeering> IEnumerable<ExpressRouteCircuitPeering>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ExpressRouteCircuitPeering> IAsyncEnumerable<ExpressRouteCircuitPeering>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
