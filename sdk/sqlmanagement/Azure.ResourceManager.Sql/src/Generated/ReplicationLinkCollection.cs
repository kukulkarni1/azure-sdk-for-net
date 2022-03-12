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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ReplicationLink and their operations over its parent. </summary>
    public partial class ReplicationLinkCollection : ArmCollection, IEnumerable<ReplicationLink>, IAsyncEnumerable<ReplicationLink>
    {
        private readonly ClientDiagnostics _replicationLinkClientDiagnostics;
        private readonly ReplicationLinksRestOperations _replicationLinkRestClient;

        /// <summary> Initializes a new instance of the <see cref="ReplicationLinkCollection"/> class for mocking. </summary>
        protected ReplicationLinkCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ReplicationLinkCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ReplicationLinkCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _replicationLinkClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ReplicationLink.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ReplicationLink.ResourceType, out string replicationLinkApiVersion);
            _replicationLinkRestClient = new ReplicationLinksRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, replicationLinkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabase.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabase.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a replication link.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}
        /// Operation Id: ReplicationLinks_Get
        /// </summary>
        /// <param name="linkId"> The name of the replication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="linkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="linkId"/> is null. </exception>
        public virtual async Task<Response<ReplicationLink>> GetAsync(string linkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(linkId, nameof(linkId));

            using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.Get");
            scope.Start();
            try
            {
                var response = await _replicationLinkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, linkId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ReplicationLink(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a replication link.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}
        /// Operation Id: ReplicationLinks_Get
        /// </summary>
        /// <param name="linkId"> The name of the replication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="linkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="linkId"/> is null. </exception>
        public virtual Response<ReplicationLink> Get(string linkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(linkId, nameof(linkId));

            using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.Get");
            scope.Start();
            try
            {
                var response = _replicationLinkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, linkId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ReplicationLink(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of replication links on database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks
        /// Operation Id: ReplicationLinks_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReplicationLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReplicationLink> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ReplicationLink>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _replicationLinkRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ReplicationLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ReplicationLink>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _replicationLinkRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ReplicationLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of replication links on database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks
        /// Operation Id: ReplicationLinks_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReplicationLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReplicationLink> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ReplicationLink> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _replicationLinkRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ReplicationLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ReplicationLink> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _replicationLinkRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ReplicationLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}
        /// Operation Id: ReplicationLinks_Get
        /// </summary>
        /// <param name="linkId"> The name of the replication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="linkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="linkId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string linkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(linkId, nameof(linkId));

            using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(linkId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}
        /// Operation Id: ReplicationLinks_Get
        /// </summary>
        /// <param name="linkId"> The name of the replication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="linkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="linkId"/> is null. </exception>
        public virtual Response<bool> Exists(string linkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(linkId, nameof(linkId));

            using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(linkId, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}
        /// Operation Id: ReplicationLinks_Get
        /// </summary>
        /// <param name="linkId"> The name of the replication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="linkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="linkId"/> is null. </exception>
        public virtual async Task<Response<ReplicationLink>> GetIfExistsAsync(string linkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(linkId, nameof(linkId));

            using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _replicationLinkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, linkId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ReplicationLink>(null, response.GetRawResponse());
                return Response.FromValue(new ReplicationLink(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}
        /// Operation Id: ReplicationLinks_Get
        /// </summary>
        /// <param name="linkId"> The name of the replication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="linkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="linkId"/> is null. </exception>
        public virtual Response<ReplicationLink> GetIfExists(string linkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(linkId, nameof(linkId));

            using var scope = _replicationLinkClientDiagnostics.CreateScope("ReplicationLinkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _replicationLinkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, linkId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ReplicationLink>(null, response.GetRawResponse());
                return Response.FromValue(new ReplicationLink(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ReplicationLink> IEnumerable<ReplicationLink>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ReplicationLink> IAsyncEnumerable<ReplicationLink>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
