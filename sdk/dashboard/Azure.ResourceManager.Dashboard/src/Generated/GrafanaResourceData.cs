// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dashboard.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dashboard
{
    /// <summary> A class representing the GrafanaResource data model. </summary>
    public partial class GrafanaResourceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of GrafanaResourceData. </summary>
        /// <param name="location"> The location. </param>
        public GrafanaResourceData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of GrafanaResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The Sku of the grafana resource. </param>
        /// <param name="properties"> Properties specific to the grafana resource. </param>
        /// <param name="identity"> The managed identity of the grafana resource. </param>
        internal GrafanaResourceData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ResourceSku sku, GrafanaResourceProperties properties, ManagedIdentity identity) : base(id, name, type, systemData, tags, location)
        {
            Sku = sku;
            Properties = properties;
            Identity = identity;
        }

        /// <summary> The Sku of the grafana resource. </summary>
        internal ResourceSku Sku { get; set; }
        /// <summary> Gets or sets the sku name. </summary>
        public string SkuName
        {
            get => Sku is null ? default : Sku.Name;
            set => Sku = new ResourceSku(value);
        }

        /// <summary> Properties specific to the grafana resource. </summary>
        public GrafanaResourceProperties Properties { get; set; }
        /// <summary> The managed identity of the grafana resource. </summary>
        public ManagedIdentity Identity { get; set; }
    }
}
